using Entities.AuthenticationModels;
using Entities.CoreServicesModels.UserModels;
using Entities.DBModels.UserModels;
using Microsoft.EntityFrameworkCore;
using BC = BCrypt.Net.BCrypt;

namespace CoreServices.Logic
{
    public class UserServices : IUserServices
    {
        private readonly IRepositoryManager _repository;

        public UserServices(IRepositoryManager repository)
        {
            _repository = repository;
        }

        #region User

        public IQueryable<UserModel> GetUsers(UserParameters parameters,
            bool trackChanges)
        {
            return _repository.User
                       .FindAll(parameters, trackChanges)
                       .Select(a => new UserModel
                       {
                           Id = a.Id,
                           CreatedAt = a.CreatedAt,
                           UserName = a.UserName,
                           EmailAddress = a.EmailAddress,
                           PhoneNumber = a.PhoneNumber,
                           FirstName = a.FirstName,
                           LastName = a.LastName,
                           FullName = a.FullName
                       })
                       .Search(parameters.SearchColumns, parameters.SearchTerm)
                       .Sort(parameters.OrderBy);
        }

        public async Task<PagedList<UserModel>> GetUsersPaged(
                 UserParameters parameters,
                 bool trackChanges)
        {
            return await PagedList<UserModel>.ToPagedList(GetUsers(parameters, trackChanges), parameters.PageNumber, parameters.PageSize);
        }

        public async Task CreateUser(User user)
        {
            if (await FindByUserName(user.UserName, trackChanges: false) != null)
            {
                throw new Exception("User name already registered");
            }

            user.Password = ChangePassword(user.Password);
            _repository.User.Create(user);
        }

        public async Task ChangePassword(int id, ChangePasswordDto model)
        {
            User user = await FindById(id, trackChanges: true);

            if (!CheckUserPassword(user, model.OldPassword))
            {
                throw new Exception("Old password is wrong!");
            }

            user.Password = ChangePassword(model.NewPassword);
        }

        public string ChangePassword(string newPassword)
        {
            return BC.HashPassword(newPassword);
        }

        public async Task<User> FindByRefreshToken(string token, bool trackChanges)
        {
            return await _repository.User.FindByRefreshToken(token, trackChanges);
        }

        public async Task<User> FindByUserName(string userName, bool trackChanges)
        {
            return await _repository.User.FindByUserName(userName, trackChanges);
        }

        public async Task<User> FindByEmailAddress(string emailAddress, bool trackChanges)
        {
            return await _repository.User.FindByEmailAddress(emailAddress, trackChanges);
        }

        public async Task<User> FindById(int id, bool trackChanges)
        {
            return await _repository.User.FindById(id, trackChanges);
        }

        public UserModel GetUserbyId(int id, bool trackChanges)
        {
            return GetUsers(new UserParameters { Id = id }, trackChanges).SingleOrDefault();
        }

        public bool CheckUserPassword(User user, string password)
        {
            return !string.IsNullOrWhiteSpace(password) &&
                    !string.IsNullOrWhiteSpace(user.Password) &&
                    BC.Verify(password, user.Password);
        }

        public async Task DeleteUser(int id)
        {
            User user = await FindById(id, trackChanges: false);
            _repository.User.Delete(user);
        }

        public int GetUsersCount()
        {
            return _repository.User.Count();
        }


        #endregion

        #region Refresh Token
        public IQueryable<RefreshTokenModel> GetRefreshTokens(RefreshTokenParameters parameters,
       bool trackChanges)
        {
            return _repository.RefreshToken
                       .FindAll(parameters, trackChanges)
                       .Select(a => new RefreshTokenModel
                       {
                           Id = a.Id,
                           CreatedAt = a.CreatedAt,
                           Token = a.Token,
                           Expires = a.Expires,
                           CreatedByIp = a.CreatedByIp,
                           Revoked = a.Revoked,
                           RevokedByIp = a.RevokedByIp,
                           ReplacedByToken = a.ReplacedByToken,
                           ReasonRevoked = a.ReasonRevoked,
                           IsExpired = a.IsExpired,
                           IsRevoked = a.IsRevoked,
                           IsActive = a.IsActive


                       })
                       .Search(parameters.SearchColumns, parameters.SearchTerm)
                       .Sort(parameters.OrderBy);
        }


        public async Task<PagedList<RefreshTokenModel>> GetRefreshTokensPaged(
                RefreshTokenParameters parameters,
                bool trackChanges)
        {
            return await PagedList<RefreshTokenModel>.ToPagedList(GetRefreshTokens(parameters, trackChanges), parameters.PageNumber, parameters.PageSize);
        }

        public async Task<RefreshToken> FindValidRefreshToken(string userName, int refreshTokenTTL)
        {
            int fk_user = FindByUserName(userName, trackChanges: false).Result.Id;

            return await _repository.RefreshToken.FindAll(new RefreshTokenParameters { Fk_User = fk_user, RefreshTokenTTL = refreshTokenTTL }, trackChanges: false).OrderBy(a => a.CreatedAt).LastOrDefaultAsync();


        }
        public int GetRefreshTokensCount()
        {
            return _repository.RefreshToken.Count();
        }


        #endregion
    }
}
