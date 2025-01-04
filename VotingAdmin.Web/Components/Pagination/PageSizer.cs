using Microsoft.AspNetCore.Mvc;
using VotingAdmin.Web.Models.Pagination;

namespace VotingAdmin.Web.Components.Pagination
{
    public class PageSizer : ViewComponent
    {
        public PageSizer()
        {
        }

        public IViewComponentResult Invoke(PageSizeDdl model)
        {
            return View(model);
        }

    }
}
