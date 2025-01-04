using VotingAdmin.Web.Dtos;
using VotingAdmin.Web.Dtos.Roles;
using VotingAdmin.Web.Models.Roles;

namespace VotingAdmin.Web.Data.Repository.Roles
{
    public interface IRoleRepo
    {
        Task<RoleList> GetAllRole();
        Task<BaseDgApiResponse<RoleDto>> GetRoleById(int Roleid);
        Task<BaseDgApiResponse<CreateRole>> AddRole(CreateRole role);
        Task<BaseDgApiResponse<UpdateRole>> UpdateRole(UpdateRole role);
        Task<BaseDgApiResponse<RoleDto>> DeleteRole(int roleid);
    }
}
