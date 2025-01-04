using Microsoft.AspNetCore.Authorization;
using Voting.Api.Features.Auth.Policies;

namespace VotingAdmin.Web.Extensions
{
    public static class AuthorizationOptionsExtensions
    {
        public static AuthorizationOptions AddApplicationPolicies(this AuthorizationOptions options)
        {
            //foreach (var policy in GlobalPolicies.Policies)
            //    options.AddPolicy(policy.Key, policy.Value);

            foreach (var policy in UserPolicies.Policies)
                options.AddPolicy(policy.Key, policy.Value);

            //foreach (var policy in CustomerPolicies.Policies)
            //    options.AddPolicy(policy.Key, policy.Value);

            return options;
        }
    }
}
