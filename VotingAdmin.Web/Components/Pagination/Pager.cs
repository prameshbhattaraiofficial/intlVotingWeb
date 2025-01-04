using Microsoft.AspNetCore.Mvc;
using VotingAdmin.Web.Models.Pagination;

namespace VotingAdmin.Web.Components.Pagination
{
    public class Pager : ViewComponent
    {
        public Pager()
        {

        }

        public IViewComponentResult Invoke(PagerModel model)
        {
            return View(model);
        }
    }
}
