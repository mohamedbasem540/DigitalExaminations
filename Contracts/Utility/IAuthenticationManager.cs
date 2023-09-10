using Entities.AuthenticationModels;

namespace Contracts.Utility
{
    public interface IAuthenticationManager
    {
        Task<UserAuthenticatedDto> Authenticate(string token, string ipAddress);
        Task<UserAuthenticatedDto> Authenticate(UserForAuthenticationDto userForAuth, string ipAddress);
        Task<UserAuthenticatedDto> GetById(int id);
        Task RevokeToken(string token, string ipAddress);
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);
    }
}