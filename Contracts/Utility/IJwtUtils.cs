using Entities.DBModels.UserModels;
using Entities.ResponseFeatures;

namespace Contracts.Utility
{
    public interface IJwtUtils
    {
        TokenResponse GenerateJwtToken(int userId);
        RefreshToken GenerateRefreshToken(string ipAddress);
        int? ValidateJwtToken(string token);
    }
}