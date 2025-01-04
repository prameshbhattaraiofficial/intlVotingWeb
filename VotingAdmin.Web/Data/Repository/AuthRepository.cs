using VotingAdmin.Web.Dtos.Auth;
using VotingAdmin.Web.Services.Http.Voting;

namespace VotingAdmin.Web.Data.Repository
{
    public class AuthRepository : BaseRepository, IAuthRepository
    {
        private readonly IDgHttpClient _dgHttpClient;

        public AuthRepository(IDgHttpClient dgHttpClient)
        {
            _dgHttpClient = dgHttpClient;
        }

        public async Task<AuthTokenResponse> MerchantAuthTokenAsync(MerchantLoginRequest userLogin)
        {
            var bodyContent = GetJsonStringContent(userLogin);
            var (statusCode, response) = await _dgHttpClient
                .PostAsync<AuthTokenResponse>(DgApiUris.MerchantAuthTokenRequestUri, bodyContent);

            return response;
        }

        public async Task<AuthTokenResponse> UserAuthTokenAsync(UserLoginRequest userLogin)
        {
            var bodyContent = GetJsonStringContent(userLogin);
            var (statusCode, response) = await _dgHttpClient
                .PostAsync<AuthTokenResponse>(DgApiUris.UserAuthTokenRequestUri, bodyContent);

            return response;
        }
    }
}
