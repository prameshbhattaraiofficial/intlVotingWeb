using VotingAdmin.Web.Common.Attributes;
using VotingAdmin.Web.Common.Paging;

namespace VotingAdmin.Web.Dtos.Reports
{
    public class VotingReportRequestDto  : PagedRequest
    {

        public DateTime? FromDate { get; set; } = null;


        public DateTime? ToDate { get; set; } = null;
        public string MerchantId { get; set; }
        /// <summary>
        /// 0 => All, 1 => Running, 2 => Scheduled, 3 => Closed
        /// </summary>
        public int Status { get; set; } = 0;
        public long ContestId { get; set; } = 0;
        public long SubContestId { get; set; } = 0;
        public string ContestantName { get; set; }
        public string MemberEmail { get; set; }
        public string PaymentMethodCode { get; set; }
        public int Export { get; set; }
    }
}
