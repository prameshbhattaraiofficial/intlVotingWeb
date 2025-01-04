using Microsoft.AspNetCore.Mvc;
using VotingAdmin.Web.Models.Pagination;

namespace VotingAdmin.Web.Components.Pagination
{
    public class PaginationSummary : ViewComponent
    {
        public PaginationSummary()
        {

        }
        public IViewComponentResult Invoke(PaginationSummaryModel model)
        {
            return View(model);
        }

    }
}
