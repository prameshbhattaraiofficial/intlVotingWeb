using VotingAdmin.Web.Common.Paging;

namespace VotingAdmin.Web.Dtos.Users.UserDetails
{
    public class UserListRequest : PagedRequest
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
    }
}
