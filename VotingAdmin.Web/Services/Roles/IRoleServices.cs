using VotingAdmin.Web.Dtos;
using VotingAdmin.Web.Dtos.Roles;
using VotingAdmin.Web.Models.Roles;

namespace VotingAdmin.Web.Services.Roles
{
    public interface IRoleServices
    {
        Task<RoleList> GetAllRole();
        Task<BaseDgApiResponse<RoleDto>> GetRoleById(int Roleid);

        Task<BaseDgApiResponse<CreateRole>> AddRole(RoleDto role);
        Task<BaseDgApiResponse<UpdateRole>> UpdateRole(RoleDto role);
        Task<BaseDgApiResponse<RoleDto>> DeleteRole(int roleid);


    }
}
