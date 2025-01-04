using VotingAdmin.Web.Common.Attributes;
using VotingAdmin.Web.Common.Paging;

namespace VotingAdmin.Web.Models.Merchants
{
    public class MerchantListRequest : PagedRequest
    {
        [NDateTime]
        public string FromDate { get; set; }

        [NDateTime]
        public string ToDate { get; set; }
        public string MerchantId { get; set; }
        public string UserName { get; set; }
        public int Export { get; set; }
    }
}
