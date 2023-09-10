﻿using Entities.AuthenticationModels;
using Entities.CoreServicesModels.StudentModels;
using Entities.DBModels.UserModels;

namespace StudentPortal.Utility
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly IJwtUtils _jwtUtils;
        private User _user;
        public AuthenticationManager(
            IUnitOfWork unitOfWork,
            IConfiguration configuration,
            IJwtUtils jwtUtils)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _jwtUtils = jwtUtils;
        }

        public async Task<UserAuthenticatedDto> Authenticate(UserForAuthenticationDto userForAuth, string ipAddress)
        {
            if (!await ValidateUser(userForAuth))
            {
                throw new Exception("login failed. Wrong user name or password.");
            }

            TokenResponse jwtToken = _jwtUtils.GenerateJwtToken(_user.Id);

            RefreshToken refreshToken = await _unitOfWork.User.FindValidRefreshToken(userForAuth.UserName, GetRefreshTokenTTL());

            if (refreshToken == null || !refreshToken.IsActive)
            {
                refreshToken = _jwtUtils.GenerateRefreshToken(ipAddress);
                _user.RefreshTokens.Add(refreshToken);
            }


            // remove old refresh tokens from account
            RemoveOldRefreshTokens(_user);

            // save changes to db
            await _unitOfWork.Save();

            return GetAuthenticatedUser(_user, jwtToken, new TokenResponse(refreshToken.Token, refreshToken.Expires));
        }

        public async Task<UserAuthenticatedDto> Authenticate(string token, string ipAddress)
        {
            _user = await _unitOfWork.User.FindByRefreshToken(token, trackChanges: true);

            if (_user == null)
            {
                throw new Exception("Login expired, please login again!");
            }

            RefreshToken refreshToken = _user.RefreshTokens.Single(x => x.Token == token);

            if (refreshToken.IsRevoked)
            {
                // revoke all descendant tokens in case this token has been compromised
                RevokeDescendantRefreshTokens(refreshToken, _user, ipAddress, $"Attempted reuse of revoked ancestor token: {token}");
                await _unitOfWork.Save();
            }

            if (!refreshToken.IsActive)
            {
                throw new Exception("Login expired, please login again!");
            }


            int refreshTokenTTL = GetRefreshTokenTTL();

            if (refreshToken.CreatedAt.AddDays(refreshTokenTTL) <= DateTime.UtcNow)
            {
                RefreshToken newRefreshToken = RotateRefreshToken(refreshToken, ipAddress);
                _user.RefreshTokens.Add(newRefreshToken);
                refreshToken = newRefreshToken;
            }

            // remove old refresh tokens from account
            RemoveOldRefreshTokens(_user);

            // save changes to db
            await _unitOfWork.Save();

            // generate new jwt
            TokenResponse jwtToken = _jwtUtils.GenerateJwtToken(_user.Id);

            return GetAuthenticatedUser(_user, jwtToken, new TokenResponse(refreshToken.Token, refreshToken.Expires));
        }

        public async Task RevokeToken(string token, string ipAddress)
        {
            _user = await _unitOfWork.User.FindByRefreshToken(token, trackChanges: true);

            RefreshToken refreshToken = _user.RefreshTokens.Single(x => x.Token == token);

            if (!refreshToken.IsActive)
            {
                throw new Exception("Login expired, please login again!");
            }

            // revoke token and save
            RevokeRefreshToken(refreshToken, ipAddress, "Revoked without replacement");

            // remove old refresh tokens from account
            RemoveOldRefreshTokens(_user);

            await _unitOfWork.Save();
        }

        public async Task<bool> ValidateUser(UserForAuthenticationDto userForAuth)
        {
            _user = await _unitOfWork.User.FindByUserName(userForAuth.UserName, trackChanges: true);
            return _user != null && _unitOfWork.User.CheckUserPassword(_user, userForAuth.Password);
        }

        public async Task<UserAuthenticatedDto> GetById(int id)
        {
            _user = await _unitOfWork.User.FindById(id, trackChanges: false);

            return _user == null ? null : GetAuthenticatedUser(_user, token: null, refreshToken: null);
        }

        // helper methods

        private UserAuthenticatedDto GetAuthenticatedUser(User user, TokenResponse token, TokenResponse refreshToken)
        {
            StudentModel student = _unitOfWork.Student.GetStudentByUserId(user.Id);

            UserAuthenticatedDto userAuthenticated = new()
            {
                RefreshToken = refreshToken,
                Token = token,
                FullName = user.FullName,
                Id = user.Id,
                Fk_Student = student.Id
            };

            return userAuthenticated;
        }

        private RefreshToken RotateRefreshToken(RefreshToken refreshToken, string ipAddress)
        {
            RefreshToken newRefreshToken = _jwtUtils.GenerateRefreshToken(ipAddress);
            RevokeRefreshToken(refreshToken, ipAddress, "Replaced by new token", newRefreshToken.Token);
            return newRefreshToken;
        }

        private void RemoveOldRefreshTokens(User user)
        {
            int refreshTokenTTL = GetRefreshTokenTTL();

            // remove old inactive refresh tokens from account based on TTL in app settings
            _ = user.RefreshTokens.RemoveAll(x => x.CreatedAt.AddDays(refreshTokenTTL) <= DateTime.UtcNow);
        }

        private void RevokeDescendantRefreshTokens(RefreshToken refreshToken, User user, string ipAddress, string reason)
        {
            // recursively traverse the refresh token chain and ensure all descendants are revoked
            if (!string.IsNullOrEmpty(refreshToken.ReplacedByToken))
            {
                RefreshToken childToken = user.RefreshTokens.SingleOrDefault(x => x.Token == refreshToken.ReplacedByToken);
                if (childToken != null)
                {
                    if (childToken.IsActive)
                    {
                        RevokeRefreshToken(childToken, ipAddress, reason);
                    }
                    else
                    {
                        RevokeDescendantRefreshTokens(childToken, user, ipAddress, reason);
                    }
                }
            }
        }

        private void RevokeRefreshToken(RefreshToken token, string ipAddress, string reason = null, string replacedByToken = null)
        {
            token.Revoked = DateTime.UtcNow;
            token.RevokedByIp = ipAddress;
            token.ReasonRevoked = reason;
            token.ReplacedByToken = replacedByToken;
        }

        private int GetRefreshTokenTTL()
        {
            IConfigurationSection appSettings = _configuration.GetSection("AppSettings");
            return int.Parse(appSettings.GetSection("refreshTokenTTL").Value);
        }
    }
}
