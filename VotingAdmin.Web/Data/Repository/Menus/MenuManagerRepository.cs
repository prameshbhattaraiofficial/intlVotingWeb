using VotingAdmin.Web.Dtos;
using VotingAdmin.Web.Dtos.Menus;
using VotingAdmin.Web.Services.Http.Voting;

namespace VotingAdmin.Web.Data.Repository.Menus
{
    public class MenuManagerRepository : BaseRepository, IMenuManagerRepository
    {
        private readonly IDgHttpClient _dgHttpClient;

        public MenuManagerRepository(IDgHttpClient dgHttpClient)
        {
            _dgHttpClient = dgHttpClient;
        }

        public async Task<MenusByRoleList> GetMenuByRoleId(int roleid)
        {
            var (_, responseData) = await _dgHttpClient.GetAsync<MenusByRoleList>(DgApiUris.GetMenuByRoleId + "?roleId=" + roleid);
            return responseData;
        }

        public async Task<BaseDgApiResponse<List<GetAllMenu>>> GetMenusAllAsync()
        {
            var (_, response) = await _dgHttpClient.GetAsync<BaseDgApiResponse<List<GetAllMenu>>>(DgApiUris.GetMenusAll);
            return response;
        }

        public async Task<MenusList> GetMenusForCurrentUser()
        {
            var (_, responseData) = await _dgHttpClient.GetAsync<MenusList>(DgApiUris.MenusSubmenusForCurrentUserUri);

            return responseData;
        }

        public async Task<BaseDgApiResponse<MenuByRole>> UpdateMenuToRole(IEnumerable<MenuByRole> Menus, int roleid)
        {
            var bodyContent = GetJsonStringContent(Menus);
            var (_, ratedata) = await _dgHttpClient.PutAsync<BaseDgApiResponse<MenuByRole>>(DgApiUris.UpdateMenuToRole + "?roleId=" + roleid, bodyContent);
            return ratedata;
        }

        public async Task<BaseDgApiResponse<List<Menu>>> GetAllParentMenuAsync()
        {
            var (_, response) = await _dgHttpClient.GetAsync<BaseDgApiResponse<List<Menu>>>(DgApiUris.GetParentMenusAll);
            return response;
        }

        public async Task<BaseDgApiResponse<string>> AddMenuAsync(AddMenu menu)
        {
            var bodyContent = AddMenuFormContent(menu);
            var (_, response) = await _dgHttpClient.PostAsync<BaseDgApiResponse<string>>(DgApiUris.AddMenu, bodyContent);
            return response;
        }
        public async Task<BaseDgApiResponse<string>> UpdateMenuAsync(UpdateMenu menu)
        {
            var bodyContent = updateMenuFormContent(menu);
            var (_, response) = await _dgHttpClient.PutAsync<BaseDgApiResponse<string>>(DgApiUris.UpdateMenu + "?id=" + menu.Id, bodyContent);
            return response;
        }

        public async Task<BaseDgApiResponse<Menu>> GetMenuByIdAsync(int Id)
        {

            var (_, responseData) = await _dgHttpClient.GetAsync<BaseDgApiResponse<Menu>>(DgApiUris.GetMenuById + "?id=" + Id);
            return responseData;
        }
        public async Task<BaseDgApiResponse<string>> DeleteMenuByIdAsync(int Id)
        {

            var (_, responseData) = await _dgHttpClient.DeleteAsync<BaseDgApiResponse<string>>(DgApiUris.DeleteMenuById + "?menuId=" + Id);
            return responseData;
        }

        public async Task<BaseDgApiResponse<string>> UpdateMenuIsActiveAsync(MenuUpdateIsactive menuUpdate)
        {
            var bodyContent = GetJsonStringContent(menuUpdate);
            var (_, response) = await _dgHttpClient.PutAsync<BaseDgApiResponse<string>>(DgApiUris.UpdateMenuIsActive, bodyContent);
            return response;
        }
        public async Task<BaseDgApiResponse<string>> UpdateMenuDisplayOrderAsync(UpdateMenuDisplayOrder menuUpdate)
        {
            var bodyContent = GetJsonStringContent(menuUpdate);
            var (_, response) = await _dgHttpClient.PutAsync<BaseDgApiResponse<string>>(DgApiUris.UpdateMenuDisplayOrder, bodyContent);
            return response;
        }
    }
}
