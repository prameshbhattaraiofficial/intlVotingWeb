namespace VotingAdmin.Web.Common.Paging
{
    public class PagedInfo
    {
        private string _sortBy;
        private string _sortOrder;

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int FilteredCount { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public int Showingfrom { get; set; }
        public int ShowingTo { get; set; }

        public virtual string SortBy
        {
            get => _sortBy;
            set => _sortBy = string.IsNullOrWhiteSpace(value) ? string.Empty : value;
        }

        public virtual string SortOrder
        {
            get => _sortOrder;
            set => _sortOrder = value is not null && value.Equals("DESC", StringComparison.InvariantCultureIgnoreCase)
                ? "DESC"
                : "ASC";
        }
    }
}
