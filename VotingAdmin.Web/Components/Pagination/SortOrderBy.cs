using Microsoft.AspNetCore.Mvc;
using VotingAdmin.Web.Models.Pagination;

namespace VotingAdmin.Web.Components.Pagination
{
    public class SortOrderViewComponent : ViewComponent
    {
        public SortOrderViewComponent()
        {

        }

        public IViewComponentResult Invoke(SortOrderModel sortOrderModel)
        {
            return View(sortOrderModel);
        }
    }
}
