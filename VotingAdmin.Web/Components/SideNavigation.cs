using Microsoft.AspNetCore.Mvc;
using VotingAdmin.Web.Services.Menus;

namespace VotingAdmin.Web.Components
{
    public class SideNavigation : ViewComponent
    {
        private readonly IMenuManagerService _menuManagerService;

        public SideNavigation(IMenuManagerService menuManagerService)
        {
            _menuManagerService = menuManagerService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var menusList = await _menuManagerService.GetMenusForCurrentUser();

            return View("Default", menusList);
        }
    }
}
