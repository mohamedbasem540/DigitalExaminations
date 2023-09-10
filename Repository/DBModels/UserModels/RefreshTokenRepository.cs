using Contracts.Repository.DBModels.UserModels;
using Entities.CoreServicesModels.UserModels;

namespace Repository.DBModels.UserModels
{
    public class RefreshTokenRepository : RepositoryBase<RefreshToken>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(BaseContext dBContext) : base(dBContext)
        {
        }

        public IQueryable<RefreshToken> FindAll(
          RefreshTokenParameters parameters,
          bool trackChanges)
        {
            return FindByCondition(a => true, trackChanges)
                   .Filter(parameters.Fk_User, parameters.RefreshTokenTTL);
        }
    }

    public static class RefreshTokenRepositoryExtensions
    {
        public static IQueryable<RefreshToken> Filter(
            this IQueryable<RefreshToken> tokens,
            int fk_User, int refreshTokenTTL)
        {
            return tokens.Where(a => a.Fk_User == fk_User &&
            (refreshTokenTTL == 0 || a.CreatedAt.AddDays(refreshTokenTTL) >= DateTime.UtcNow));
        }
    }
}
