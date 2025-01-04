namespace VotingAdmin.Web.Dtos.Pagination
{
    public class PaginationParameter
    {
        public int pageSize { get; set; } = 0;
        public int pageNumber { get; set; } = 1;
        public string searchVal { get; set; } = string.Empty;
        public string sortBy { get; set; } = string.Empty;
        public string sortOrder { get; set; } = string.Empty;
    }
}
