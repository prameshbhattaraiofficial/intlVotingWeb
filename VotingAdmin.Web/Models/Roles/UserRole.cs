namespace VotingAdmin.Web.Models.Roles
{
    public class UserRole
    {
        public int userId { get; set; }
        public List<Role> userRoles { get; set; }
    }

    public class UsersRoleResponse
    {
        public int UserId { get; set; }
        public List<Role> userRoles { get; set; }
        public List<Role> availableRoles { get; set; }
    }





}
