namespace VotingAdmin.Web.Configuration
{
    public class CookieAuthOptions
    {
        public const string SectionName = "Authentication:Cookie";
        public int ExpirationDays { get; set; }
        public int ExpirationHours { get; set; }
        public int ExpirationMinutes { get; set; }
        public int ExpirationSeconds { get; set; }
        public bool IsPersistent { get; set; }
        public bool SlidingExpiration { get; set; }
    }
}
