using Entities.CoreServicesModels.UserModels;
using Entities.DBModels.UserModels;

namespace Contracts.Repository.DBModels.UserModels
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        IQueryable<User> FindAll(UserParameters parameters, bool trackChanges);
        Task<User> FindByEmailAddress(string emailAddress, bool trackChanges);
        Task<User> FindById(int id, bool trackChanges);
        Task<User> FindByRefreshToken(string token, bool trackChanges);
        Task<User> FindByUserName(string userName, bool trackChanges);
    }
}
