namespace VotingAdmin.Web.Common.Paging
{
    public class PagedRequest
    {
        protected int MaxPageSize = 500;
        protected int DefaultPageSize = 20;

        private int _pageSize;
        private int _pageNumber;
        private string _searchVal = string.Empty;
        private string _sortOrder = "ASC";
        private string _sortBy = string.Empty;

        public virtual int PageSize
        {
            get => _pageSize;
            set => _pageSize = value < 1 ? DefaultPageSize : Math.Min(Math.Max(value, 1), MaxPageSize);
        }

        public virtual int PageNumber
        {
            get => _pageNumber;
            set => _pageNumber = Math.Max(value, 1);
        }

        public virtual string SearchVal
        {
            get => _searchVal;
            set => _searchVal = string.IsNullOrWhiteSpace(value) ? string.Empty : value;
        }

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
