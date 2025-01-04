using Microsoft.AspNetCore.Mvc;
using VotingAdmin.Web.Models.Pagination;

namespace VotingAdmin.Web.Components.Pagination
{
    public class SortByViewComponent : ViewComponent
    {
        public SortByViewComponent()
        {

        }

        public IViewComponentResult Invoke(SortByModel model)
        {
            return View(model);
        }
    }
}
