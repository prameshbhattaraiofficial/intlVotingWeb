namespace VotingAdmin.Web.Models.ResetPassword
{
    public class ResetPassword
    {
        public int userId { get; set; }
        public string newPassword { get; set; }
        public string confirmPassword { get; set; }
    }
}
