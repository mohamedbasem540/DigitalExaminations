using Entities.AuthenticationModels;
using Entities.CoreServicesModels.UserModels;
using Entities.DBModels.UserModels;
using Entities.RequestFeatures;

namespace Contracts.CoreServices.Logic
{
    public interface IUserServices
    {
        Task ChangePassword(int id, ChangePasswordDto model);
        string ChangePassword(string newPassword);
        bool CheckUserPassword(User user, string password);
        Task CreateUser(User user);
        Task DeleteUser(int id);
        Task<User> FindByEmailAddress(string emailAddress, bool trackChanges);
        Task<User> FindById(int id, bool trackChanges);
        Task<User> FindByRefreshToken(string token, bool trackChanges);
        Task<User> FindByUserName(string userName, bool trackChanges);
        Task<RefreshToken> FindValidRefreshToken(string userName, int refreshTokenTTL);
        IQueryable<RefreshTokenModel> GetRefreshTokens(RefreshTokenParameters parameters, bool trackChanges);
        int GetRefreshTokensCount();
        Task<PagedList<RefreshTokenModel>> GetRefreshTokensPaged(RefreshTokenParameters parameters, bool trackChanges);
        UserModel GetUserbyId(int id, bool trackChanges);
        IQueryable<UserModel> GetUsers(UserParameters parameters, bool trackChanges);
        int GetUsersCount();
        Task<PagedList<UserModel>> GetUsersPaged(UserParameters parameters, bool trackChanges);
    }
}