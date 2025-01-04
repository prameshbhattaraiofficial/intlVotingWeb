using VotingAdmin.Web.Dtos;
using VotingAdmin.Web.Dtos.Menus;

namespace VotingAdmin.Web.Data.Repository.Menus
{
    public interface IMenuManagerRepository
    {
        Task<MenusList> GetMenusForCurrentUser();
        Task<BaseDgApiResponse<MenuByRole>> UpdateMenuToRole(IEnumerable<MenuByRole> Menus, int roleid);
        Task<MenusByRoleList> GetMenuByRoleId(int roleid);
        Task<BaseDgApiResponse<List<GetAllMenu>>> GetMenusAllAsync();
        Task<BaseDgApiResponse<List<Menu>>> GetAllParentMenuAsync();
        Task<BaseDgApiResponse<string>> AddMenuAsync(AddMenu menu);
        Task<BaseDgApiResponse<string>> UpdateMenuAsync(UpdateMenu menu);
        Task<BaseDgApiResponse<Menu>> GetMenuByIdAsync(int Id);
        Task<BaseDgApiResponse<string>> DeleteMenuByIdAsync(int Id);
        Task<BaseDgApiResponse<string>> UpdateMenuIsActiveAsync(MenuUpdateIsactive menuUpdate);
        Task<BaseDgApiResponse<string>> UpdateMenuDisplayOrderAsync(UpdateMenuDisplayOrder menuUpdate);
    }
}
