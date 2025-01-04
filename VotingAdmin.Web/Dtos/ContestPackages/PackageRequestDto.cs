using VotingAdmin.Web.Common.Paging;

namespace VotingAdmin.Web.Dtos.ContestPackages
{
    public class PackageRequestDto : PagedRequest

    {
        public int Status { get; set; }
        public long ContestId { get; set; }
        public long SubContestId { get; set; }
        public int Export { get; set; }
    }
}
