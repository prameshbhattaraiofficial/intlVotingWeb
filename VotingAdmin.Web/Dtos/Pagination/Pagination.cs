using VotingAdmin.Web.Dtos.PageModel;
using VotingAdmin.Web.Models.Pagination;

namespace VotingAdmin.Web.Dtos.Pagination
{
    public class Pagination : ActionSpecs
    {
        public int TotalItems { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPage { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }
        public int Showingfrom { get; set; }
        public int ShowingTo { get; set; }

        public List<PageSizer> PageSizeOptions { get; set; } = new List<PageSizer>()

            {
                new() {Id=5,Text="5"},
                new() {Id=10,Text="10"},
                new() {Id=10,Text="20"},
                new() { Id = 30, Text = "30" },
                new() { Id = 40, Text = "40" },
                new() { Id = 50, Text = "50" }
            };
        public string SearchName { get; set; }


        public Pagination()
        {

        }
        public Pagination(int totalItems, int page, int pageSize = 10)
        {
            int totalpage = (int)Math.Ceiling(totalItems / (decimal)pageSize);
            int currentpage = page;
            int startpage = currentpage - 5;
            int endpage = currentpage + 4;
            if (startpage <= 0)
            {
                endpage = endpage - (startpage - 1);
                startpage = 1;

            }
            if (endpage > totalpage)
            {
                endpage = totalpage;
                if (endpage > 10)
                {
                    startpage = endpage - 9;
                }
            }
            // 
            TotalItems = totalItems;
            CurrentPage = currentpage;
            PageSize = pageSize;
            TotalPage = totalpage;
            StartPage = startpage;
            EndPage = endpage;
        }

    }


}

