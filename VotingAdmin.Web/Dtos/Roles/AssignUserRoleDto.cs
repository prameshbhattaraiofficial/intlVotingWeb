namespace VotingAdmin.Web.Dtos.Roles
{
    public class AssignUserRoleDto
    {
        public int user_id { get; set; }
        public int[] roleid { get; set; }
    }
}
