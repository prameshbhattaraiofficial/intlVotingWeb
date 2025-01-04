namespace VotingAdmin.Web.Models.Roles
{
    public class UpdateRole
    {
        public int id { get; set; }
        public string roleName { get; set; }
        public string description { get; set; }
        public bool isActive { get; set; }
    }
}
