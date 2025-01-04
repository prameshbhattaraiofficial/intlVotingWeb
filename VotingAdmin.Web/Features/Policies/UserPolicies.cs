using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using VotingAdmin.Web.Domain;
using VotingAdmin.Web.Extensions;

namespace Voting.Api.Features.Auth.Policies
{
    public static class UserPolicies
    {
        #region policynames
        //public const string VotingSuperAdmin = "VotingSuperAdmin";
        //public const string VotingAdmin = "VotingAdmin";
        public const string VotingUser = "VotingUser";
        public const string VotingMerchant = "VotingMerchant";
        #endregion

        private static readonly Dictionary<string, AuthorizationPolicy> _policies =
            new()
            {
                //{
                //    VotingSuperAdmin,
                //    new AuthorizationPolicyBuilder()
                //    .AddAuthenticationSchemes(CookieAuthenticationDefaults.AuthenticationScheme)
                //    .RequireAuthenticatedUser()
                //    .RequireAssertion(c => c.User.IsSuperAdmin())
                //    .Build()
                //},
                //{
                //    VotingAdmin,
                //    new AuthorizationPolicyBuilder()
                //    .AddAuthenticationSchemes(CookieAuthenticationDefaults.AuthenticationScheme)
                //    .RequireAuthenticatedUser()
                //    .RequireAssertion(c => c.User.IsInRole(UserRoles.Admin) || c.User.IsSuperAdmin())
                //    .Build()
                //},
                {
                    VotingUser,
                    new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(CookieAuthenticationDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser()
                    .RequireAssertion(c => !c.User.HasClaim(UserClaimTypes.IsMerchant, true.ToString()))
                    .Build()
                },
                {
                    VotingMerchant,
                    new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(CookieAuthenticationDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser()
                    //.RequireAssertion(c => c.User.IsInRole(UserRoles.Merchant) || c.User.IsInRole(UserRoles.Admin) || c.User.IsSuperAdmin())
                    .RequireAssertion(c => c.User.IsInRole(UserRoles.Merchant) && c.User.HasClaim(UserClaimTypes.IsMerchant, true.ToString()))
                    .Build()
                }
            };

        public static Dictionary<string, AuthorizationPolicy> Policies { get => _policies; }
    }
}
