namespace VotingAdmin.Web.Dtos.Pagination
{
    public class TblPagination
    {
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
        public int filteredCount { get; set; }
        public int totalCount { get; set; }
        public int totalPages { get; set; }
    }
}
