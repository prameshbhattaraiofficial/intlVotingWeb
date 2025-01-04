using VotingAdmin.Web.Data.Repository.Roles;
using VotingAdmin.Web.Dtos;
using VotingAdmin.Web.Dtos.Roles;
using VotingAdmin.Web.Models.Roles;

namespace VotingAdmin.Web.Services.Roles
{
    public class RoleServices : IRoleServices
    {
        private readonly IRoleRepo _roleRepo;
        public RoleServices(IRoleRepo roleRepo)
        {
            _roleRepo = roleRepo;
        }

        public async Task<BaseDgApiResponse<CreateRole>> AddRole(RoleDto role)
        {
            CreateRole createRole = new CreateRole()
            {
                roleName = role.roleName,
                description = role.description,
                isActive = role.isActive
            };
            var result = await _roleRepo.AddRole(createRole);
            return result;
        }

        public async Task<BaseDgApiResponse<RoleDto>> DeleteRole(int roleid)
        {
            var result = await _roleRepo.DeleteRole(roleid);
            return result;
        }

        public async Task<RoleList> GetAllRole()
        {
            var result = await _roleRepo.GetAllRole();
            return result;
        }

        public Task<BaseDgApiResponse<RoleDto>> GetRoleById(int Roleid)
        {
            var result = _roleRepo.GetRoleById(Roleid);
            return result;
        }

        public async Task<BaseDgApiResponse<UpdateRole>> UpdateRole(RoleDto role)
        {
            UpdateRole updateRole = new UpdateRole()
            {
                id = role.id,
                roleName = role.roleName,
                description = role.description,
                isActive = role.isActive
            };
            var result = await _roleRepo.UpdateRole(updateRole);
            return result;
        }
    }
}
