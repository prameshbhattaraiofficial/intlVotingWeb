using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.CookiePolicy;
using VotingAdmin.Web.Configuration;
using VotingAdmin.Web.Domain;

namespace VotingAdmin.Web.Extensions
{
    public static class AuthenticationServiceExtensions
    {
        public static IServiceCollection AddAuthenticationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
                {
                    var cookieAuthOptions = config.GetSection(CookieAuthOptions.SectionName).Get<CookieAuthOptions>();

                    options.Cookie.Name = AuthDefaults.CookieAuthenticationName;
                    options.Cookie.HttpOnly = true;
                    options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                    options.Cookie.SameSite = SameSiteMode.Strict;
                    options.LoginPath = AuthDefaults.MerchantLoginPath;
                    options.LogoutPath = AuthDefaults.LogoutPath;
                    options.AccessDeniedPath = AuthDefaults.AccessDeniedPath;
                    options.ExpireTimeSpan = DateTime.Now
                        .AddDays(cookieAuthOptions.ExpirationDays)
                        .AddHours(cookieAuthOptions.ExpirationHours)
                        .AddMinutes(cookieAuthOptions.ExpirationMinutes)
                        .AddSeconds(cookieAuthOptions.ExpirationSeconds) - DateTime.Now;
                    options.SlidingExpiration = cookieAuthOptions.SlidingExpiration;
                });

            services.AddAuthorization(config =>
            {
                config.DefaultPolicy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .AddAuthenticationSchemes(CookieAuthenticationDefaults.AuthenticationScheme)
                .Build();

                // Add application auth policies defined in Features/Auth/Policies directory
                config.AddApplicationPolicies();
            });

            services.Configure<CookieAuthOptions>(config.GetSection(CookieAuthOptions.SectionName));

            services.Configure<CookiePolicyOptions>(options =>
            {
                // prevent access from javascript 
                options.HttpOnly = HttpOnlyPolicy.Always;

                // If the URI that provides the cookie is HTTPS, 
                // cookie will be sent ONLY for HTTPS requests 
                // (refer mozilla docs for details) 
                options.Secure = CookieSecurePolicy.SameAsRequest;

                // refer "SameSite cookies" on mozilla website 
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromDays(2);
            });

            return services;
        }
    }
}
