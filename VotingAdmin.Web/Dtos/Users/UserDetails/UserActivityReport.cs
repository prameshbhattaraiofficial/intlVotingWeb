namespace VotingAdmin.Web.Dtos.Users.UserDetails
{
    public class UserActivityReport
    {
        public DateTime ActivityDate { get; set; }
        public string UserType { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string IPAddress { get; set; }
        public string Path { get; set; }
        public string UserAgent { get; set; }
        public string ActionPerformed { get; set; }
    }
}
