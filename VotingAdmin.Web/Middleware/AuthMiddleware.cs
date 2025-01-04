using Microsoft.AspNetCore.Authentication;
using VotingAdmin.Web.Domain;
using VotingAdmin.Web.Extensions;
using VotingAdmin.Web.Services;
using VotingAdmin.Web.Services.Http.Voting;

namespace VotingAdmin.Web.Middleware
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;


        public AuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, IAuthService authService)
        {
            if (!authService.IsUserAuthenticated())
            {
                await _next(httpContext);
                return;
            }

            var accessToken = httpContext.User.FindFirst(UserClaimTypes.AccessToken)?.Value;
            if (string.IsNullOrWhiteSpace(accessToken))
            {
                await authService.LogoutAsync();
                await httpContext.ChallengeAsync(new AuthenticationProperties
                {
                    RedirectUri = httpContext.Request.Path,
                });
                return;
            }

            var accessTokenExpirationDateTime = authService.GetAccessTokenExpirationDateTime(accessToken);
            if (accessTokenExpirationDateTime.AddSeconds(-5) > DateTime.UtcNow)
            {
                if (!httpContext.Request.Headers.ContainsKey(VotingApiDefaults.HeaderVotingApiAccessToken))
                    httpContext.Request.Headers.Add(VotingApiDefaults.HeaderVotingApiAccessToken, accessToken);

                await _next(httpContext);
                return;
            }

            var refreshToken = httpContext.User.FindFirst(UserClaimTypes.RefreshToken)?.Value;
            if (string.IsNullOrWhiteSpace(refreshToken))
            {
                await authService.LogoutAsync();
                await httpContext.ChallengeAsync(new AuthenticationProperties
                {
                    RedirectUri = httpContext.Request.Path,
                });
                return;
            }

            AuthResult authResult = httpContext.User.IsMerchant()
                ? await authService.MerchantLoginWithRefreshTokenAsync(refreshToken)
                : await authService.UserLoginWithRefreshTokenAsync(refreshToken);

            if (!authResult.Success)
            {
                await authService.LogoutAsync();
                await httpContext.ChallengeAsync(new AuthenticationProperties
                {
                    RedirectUri = httpContext.Request.Path,
                });
                return;
            }

            await _next(httpContext);
        }
    }
}
