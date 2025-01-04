using VotingAdmin.Web.Common.Paging;

namespace VotingAdmin.Web.Dtos.Contestant
{
    public class ContestantRequestDto : PagedRequest
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public long ContestId { get; set; }
        public long SubContestId { get; set; }
        public int Export { get; set; }
    }
}
