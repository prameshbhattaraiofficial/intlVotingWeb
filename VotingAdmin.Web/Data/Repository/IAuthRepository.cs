using VotingAdmin.Web.Dtos.Auth;

namespace VotingAdmin.Web.Data.Repository
{
    public interface IAuthRepository
    {
        Task<AuthTokenResponse> MerchantAuthTokenAsync(MerchantLoginRequest userLogin);
        Task<AuthTokenResponse> UserAuthTokenAsync(UserLoginRequest userLogin);
    }
}
