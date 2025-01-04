namespace VotingAdmin.Web.Dtos.Roles
{
    public class PermissionDto
    {

        public string Name { get; set; }
        public bool viewper { get; set; }
        public bool Createper { get; set; }
        public bool Updateper { get; set; }
        public bool Deleteper { get; set; }
        public int RoleId { get; set; }
        public int menuid { get; set; }
    }
}
