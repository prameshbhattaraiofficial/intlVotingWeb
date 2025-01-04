namespace VotingAdmin.Web.Domain
{
    public static class AuthDefaults
    {
        // Cookie Authentication Name
        public const string CookieAuthenticationName = "vauth";

        // Merchant login path
        public const string MerchantLoginPath = "/account/merchantLogin";

        // User login path
        public const string UserLoginPath = "/account/userLogin";

        // Account logout path
        public const string LogoutPath = "/account/logout";

        // User access denied/ forbidden path
        public const string AccessDeniedPath = "/errors/forbidden";
    }
}
