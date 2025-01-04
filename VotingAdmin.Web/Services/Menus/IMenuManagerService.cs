using VotingAdmin.Web.Dtos;
using VotingAdmin.Web.Dtos.Menus;

namespace VotingAdmin.Web.Services.Menus
{
    public interface IMenuManagerService
    {
        Task<MenusList> GetMenusForCurrentUser();
        Task<BaseDgApiResponse<MenuByRole>> UpdateMenuToRole(List<MenuByRole> Menus, int roleid);
        Task<MenusByRoleList> GetMenuByRoleId(int roleid);
        Task<List<GetAllMenu>> GetMenusAllAsync();
        Task<BaseDgApiResponse<Menu>> GetMenusByIdAsync(int Id);
        Task<BaseDgApiResponse<string>> DeleteMenusByIdAsync(int Id);
        Task<List<Menu>> GetAllParentMenu();
        Task<BaseDgApiResponse<string>> Addmenu(AddMenu menu);
        Task<BaseDgApiResponse<string>> Updatemenu(UpdateMenu menu);
        Task<BaseDgApiResponse<string>> UpdateMenuIsactive(MenuUpdateIsactive menuUpdate);
        Task<BaseDgApiResponse<string>> UpdateMenuDisplayOrder(UpdateMenuDisplayOrder updateMenu);

    }
}
