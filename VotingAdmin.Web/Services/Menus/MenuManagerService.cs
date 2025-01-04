using VotingAdmin.Web.Data.Repository.Menus;
using VotingAdmin.Web.Dtos;
using VotingAdmin.Web.Dtos.Menus;

namespace VotingAdmin.Web.Services.Menus
{
    public class MenuManagerService : IMenuManagerService
    {
        private readonly IMenuManagerRepository _menuManagerRepository;

        public MenuManagerService(
            IMenuManagerRepository menuManagerRepository)
        {
            _menuManagerRepository = menuManagerRepository;
        }

        public async Task<MenusByRoleList> GetMenuByRoleId(int roleid)
        {
            var result = await _menuManagerRepository.GetMenuByRoleId(roleid);
            return result;
        }

        public async Task<List<GetAllMenu>> GetMenusAllAsync()
        {
            var response = await _menuManagerRepository.GetMenusAllAsync();

            return response.Data;
        }

        public async Task<MenusList> GetMenusForCurrentUser()
        {
            return await _menuManagerRepository.GetMenusForCurrentUser();
        }

        public async Task<BaseDgApiResponse<MenuByRole>> UpdateMenuToRole(List<MenuByRole> Menus, int roleid)
        {
            var result = await _menuManagerRepository.UpdateMenuToRole(Menus, roleid);
            return result;
        }
        public async Task<List<Menu>> GetAllParentMenu()
        {
            var response = await _menuManagerRepository.GetAllParentMenuAsync();
            return response.Data;
        }

        public async Task<BaseDgApiResponse<string>> Addmenu(AddMenu menu)
        {
            var result = await _menuManagerRepository.AddMenuAsync(menu);
            return result;
        }
        public async Task<BaseDgApiResponse<string>> Updatemenu(UpdateMenu menu)
        {
            var result = await _menuManagerRepository.UpdateMenuAsync(menu);
            return result;
        }

        public async Task<BaseDgApiResponse<Menu>> GetMenusByIdAsync(int Id)
        {
            var result = await _menuManagerRepository.GetMenuByIdAsync(Id);
            return result;
        }
        public async Task<BaseDgApiResponse<string>> DeleteMenusByIdAsync(int Id)
        {
            var result = await _menuManagerRepository.DeleteMenuByIdAsync(Id);
            return result;
        }

        public async Task<BaseDgApiResponse<string>> UpdateMenuIsactive(MenuUpdateIsactive menuUpdate)
        {
            var result = await _menuManagerRepository.UpdateMenuIsActiveAsync(menuUpdate);
            return result;
        }
        public async Task<BaseDgApiResponse<string>> UpdateMenuDisplayOrder(UpdateMenuDisplayOrder updateMenu)
        {
            var result = await _menuManagerRepository.UpdateMenuDisplayOrderAsync(updateMenu);
            return result;
        }
    }
}
