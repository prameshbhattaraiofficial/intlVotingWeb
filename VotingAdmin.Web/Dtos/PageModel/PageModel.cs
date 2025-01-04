using VotingAdmin.Web.Models.Pagination;

namespace VotingAdmin.Web.Dtos.PageModel
{
    public class PageModel : ActionSpecs
    {
        public enum sortOrder { Ascending = 0, Descending = 1 }
        public PageModel()
        {

        }
        public string SearchName { get; set; }
        public string CurrentPageValue { get; set; }
        public string PageSizer { get; set; }
        public string sortExpression { get; set; }
    }
}
