using Entities.CoreServicesModels.UserModels;
using Entities.DBModels.UserModels;

namespace Contracts.Repository.DBModels.UserModels
{
    public interface IRefreshTokenRepository : IRepositoryBase<RefreshToken>
    {
        IQueryable<RefreshToken> FindAll(RefreshTokenParameters parameters, bool trackChanges);
    }
}
