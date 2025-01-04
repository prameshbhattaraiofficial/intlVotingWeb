using VotingAdmin.Web.Dtos;
using VotingAdmin.Web.Dtos.Roles;
using VotingAdmin.Web.Models.Roles;
using VotingAdmin.Web.Services.Http.Voting;

namespace VotingAdmin.Web.Data.Repository.Roles
{
    public class RoleRepo : BaseRepository, IRoleRepo
    {
        private readonly IDgHttpClient _dgHttpClient;
        public RoleRepo(IDgHttpClient dgHttpClient)
        {
            _dgHttpClient = dgHttpClient;
        }

        public async Task<BaseDgApiResponse<CreateRole>> AddRole(CreateRole role)
        {
            var bodyContent = GetJsonStringContent(role);
            var (_, roledata) = await _dgHttpClient.PostAsync<BaseDgApiResponse<CreateRole>>(DgApiUris.CreateRoleurl, bodyContent);
            return roledata;
        }

        public async Task<RoleList> GetAllRole()
        {
            var (_, RoleList) = await _dgHttpClient.GetAsync<RoleList>(DgApiUris.GetAllRolesurl);
            return RoleList;
        }

        public async Task<BaseDgApiResponse<UpdateRole>> UpdateRole(UpdateRole role)
        {
            var bodyContent = GetJsonStringContent(role);
            var (_, roledata) = await _dgHttpClient.PutAsync<BaseDgApiResponse<UpdateRole>>(DgApiUris.UpdateRoleurl, bodyContent);
            return roledata;
        }

        public async Task<BaseDgApiResponse<RoleDto>> GetRoleById(int Roleid)
        {
            var (_, RoleData) = await _dgHttpClient.GetAsync<BaseDgApiResponse<RoleDto>>(DgApiUris.GetRoleByIdurl + "?roleId=" + Roleid);
            return RoleData;
        }

        public async Task<BaseDgApiResponse<RoleDto>> DeleteRole(int roleid)
        {
            var (_, RoleData) = await _dgHttpClient.DeleteAsync<BaseDgApiResponse<RoleDto>>(DgApiUris.DeleteRoleurl + "?roleId=" + roleid);
            return RoleData;
        }
    }
}
