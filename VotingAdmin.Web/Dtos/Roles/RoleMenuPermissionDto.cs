namespace VotingAdmin.Web.Dtos.Roles
{
    public class RoleMenuPermissionDto
    {
        public int RoleId { get; set; }
        public int MenuId { get; set; }
        public string ViewPer { get; set; }
        public string Createper { get; set; }
        public string EditPer { get; set; }
        public string DeletePer { get; set; }
    }
}
