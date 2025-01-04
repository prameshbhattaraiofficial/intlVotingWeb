using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VotingAdmin.Web.Dtos.Roles
{
    public class RoleList : BaseDgApiResponse<List<RoleDto>>
    {
        public override List<RoleDto> Data { get; set; }
    }
    public class RoleDto
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Enter Role Name")]
        public string roleName { get; set; }
        public string description { get; set; }
        public bool isActive { get; set; }
        [NotMapped]
        public int user_id { get; set; }
        public int[] roleid { get; set; }

    }
}
