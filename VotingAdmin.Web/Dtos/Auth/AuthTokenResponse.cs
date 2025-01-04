namespace VotingAdmin.Web.Dtos.Auth
{
    public class AuthTokenResponse : DgApiResponse
    {
        public string Username { get; set; }
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
        public string RefreshToken { get; set; }
        public long ExpiresIn { get; set; }
    }
}
