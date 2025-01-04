using System.Security.Claims;
using VotingAdmin.Web.Domain;
using VotingAdmin.Web.Dtos.Auth;

namespace VotingAdmin.Web.Services
{
    public interface IAuthService
    {
        Task<AuthResult> MerchantLoginWithPasswordAsync(MerchantLoginRequest loginRequestDto);
        Task<AuthResult> MerchantLoginWithRefreshTokenAsync(string refreshToken);
        Task<AuthResult> UserLoginWithPasswordAsync(UserLoginRequest loginRequestDto);
        Task<AuthResult> UserLoginWithRefreshTokenAsync(string refreshToken);
        bool IsUserAuthenticated();
        Task LogoutAsync();
        DateTimeOffset GetAccessTokenExpirationDateTime(string token);
        List<Claim> GetClaimsFromAccessToken(string accessToken);
    }
}
