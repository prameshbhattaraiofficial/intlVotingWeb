using System.Security.Claims;
using VotingAdmin.Web.Domain;

namespace VotingAdmin.Web.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static bool IsSuperAdmin(this ClaimsPrincipal user)
        {
            return user.HasClaim(UserClaimTypes.IsSuperAdmin, true.ToString());
        }

        public static bool IsMerchant(this ClaimsPrincipal user)
        {
            return user.HasClaim(UserClaimTypes.IsMerchant, true.ToString());
        }
    }
}
