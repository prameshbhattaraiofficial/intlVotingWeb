using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using NuGet.Packaging;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using VotingAdmin.Web.Configuration;
using VotingAdmin.Web.Data.Repository;
using VotingAdmin.Web.Domain;
using VotingAdmin.Web.Dtos.Auth;
using VotingAdmin.Web.Services.Http.Voting;

namespace VotingAdmin.Web.Services
{
    public class AuthService : IAuthService
    {
        private readonly IOptions<CookieAuthOptions> _cookieAuthOptions;
        private readonly IAuthRepository _authRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(
            IOptions<CookieAuthOptions> cookieAuthOptions,
            IAuthRepository authRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _cookieAuthOptions = cookieAuthOptions;
            _authRepository = authRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<AuthResult> MerchantLoginWithPasswordAsync(MerchantLoginRequest loginRequestDto)
        {
            ArgumentNullException.ThrowIfNull(loginRequestDto);

            loginRequestDto.GrantType = AuthGrantTypes.Password;
            loginRequestDto.Source = "web";

            var authResponse = await _authRepository.MerchantAuthTokenAsync(loginRequestDto);

            return await SignInUserAsync(authResponse);
        }

        public async Task<AuthResult> MerchantLoginWithRefreshTokenAsync(string refreshToken)
        {
            ArgumentNullException.ThrowIfNull(refreshToken);

            var authTokenRequest = new MerchantLoginRequest
            {
                GrantType = AuthGrantTypes.RefreshToken,
                RefreshToken = refreshToken,
                Source = "web"
            };

            var authResponse = await _authRepository.MerchantAuthTokenAsync(authTokenRequest);

            return await SignInUserAsync(authResponse);
        }

        public async Task<AuthResult> UserLoginWithPasswordAsync(UserLoginRequest loginRequestDto)
        {
            ArgumentNullException.ThrowIfNull(loginRequestDto);

            loginRequestDto.GrantType = AuthGrantTypes.Password;
            loginRequestDto.Source = "web";

            var authResponse = await _authRepository.UserAuthTokenAsync(loginRequestDto);

            return await SignInUserAsync(authResponse);
        }

        public async Task<AuthResult> UserLoginWithRefreshTokenAsync(string refreshToken)
        {
            ArgumentNullException.ThrowIfNull(refreshToken);

            var authTokenRequest = new UserLoginRequest
            {
                GrantType = AuthGrantTypes.RefreshToken,
                RefreshToken = refreshToken,
                Source = "web"
            };

            var authResponse = await _authRepository.UserAuthTokenAsync(authTokenRequest);

            return await SignInUserAsync(authResponse);
        }

        private async Task<AuthResult> SignInUserAsync(AuthTokenResponse authResponse)
        {
            var authResult = new AuthResult();
            if (authResponse?.AccessToken is null)
            {
                if (authResponse.Errors is not null && authResponse.Errors.Any())
                    authResult.Errors.AddRange(authResponse.Errors);
                else
                    authResult.AddError("Authentication failed.");

                return authResult;
            }

            var userClaims = GetClaimsFromAccessToken(authResponse.AccessToken);
            userClaims.Add(new Claim(UserClaimTypes.AccessToken, authResponse.AccessToken));
            userClaims.Add(new Claim(UserClaimTypes.RefreshToken, authResponse.RefreshToken));

            var userIdentity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(userIdentity);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = _cookieAuthOptions.Value.IsPersistent,
                //AllowRefresh = true,
                //ExpiresUtc = AuthUtils.GetExpirationFromJwtToken(tokenData.AccessToken),
                IssuedUtc = DateTime.UtcNow
            };

            if (IsUserAuthenticated())
                await SignOutAsync();

            await _httpContextAccessor
                .HttpContext
                .SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authProperties);

            // Here we put access token in header because of immutability behavior of HttpContext for the current request
            if (_httpContextAccessor.HttpContext.Request.Headers.ContainsKey(VotingApiDefaults.HeaderVotingApiAccessToken))
                _httpContextAccessor.HttpContext.Request.Headers.Remove(VotingApiDefaults.HeaderVotingApiAccessToken);
            _httpContextAccessor.HttpContext.Request.Headers.Add(VotingApiDefaults.HeaderVotingApiAccessToken, authResponse.AccessToken);

            return authResult;
        }


        public bool IsUserAuthenticated()
        {
            return _httpContextAccessor.HttpContext.User.Identity.AuthenticationType == CookieAuthenticationDefaults.AuthenticationScheme
                 && _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
        }

        public async Task LogoutAsync()
        {
            await SignOutAsync();
        }

        private async Task SignOutAsync()
        {
            await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public List<Claim> GetClaimsFromAccessToken(string accessToken)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(accessToken);

            var claims = new List<Claim>();
            claims.AddRange(jwt.Claims);
            return claims;
        }

        public DateTimeOffset GetAccessTokenExpirationDateTime(string token)
        {
            if (token is null)
                throw new ArgumentNullException(nameof(token));

            var expDateTime = new JwtSecurityTokenHandler()
                .ReadJwtToken(token)
                .Claims
                .First(claim => claim.Type == JwtRegisteredClaimNames.Exp).Value;

            return DateTimeOffset.FromUnixTimeSeconds(long.Parse(expDateTime));
        }
    }
}
