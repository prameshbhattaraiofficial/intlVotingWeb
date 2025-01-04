using VotingAdmin.Web.Common.Paging;

namespace VotingAdmin.Web.Dtos.Users.UserDetails
{
    public class UserActivityFilter : PagedRequest
    {
        private DateTime? _activityfromDate = DateTime.Today;
        private DateTime? _activitytoDate = DateTime.Today;
        private string email = "";
        private string userName = "";
        private string userAction = "";

        public int UserType { get; set; }
        public string UserName { get => userName; set => userName = value; }
        public string Email { get => email; set => email = value; }
        public string UserAction { get => userAction; set => userAction = value; }
        public DateTime? FromDate { get => _activityfromDate ?? DateTime.Today; set => _activityfromDate = value; }
        public DateTime? ToDate { get => _activitytoDate ?? DateTime.Today; set => _activitytoDate = value; }
        public int Export { get; set; }
    }
}
