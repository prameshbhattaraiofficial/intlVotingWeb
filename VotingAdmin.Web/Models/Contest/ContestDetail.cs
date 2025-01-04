using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voting.Core.Models.Contest
{
    public class ContestDetail
    {
        public long ContestId { get; set; }
        public long SubContestId { get; set; }
        public string ContestName { get; set; }
        public string ContestDesc { get; set; }
        public string SubContestBannerImgPath {get;set;}
        public string SubContestSliderImgPath { get; set; }
        public string SubContestName { get; set; }
        public string SubContestDesc { get; set; }
        public string StartDateTime { get; set; }
        public string EndDateTime { get; set; }
        public string IsPublished { get; set; }
        public string PublishedDateTime { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public int TotalFreeVotes { get; set; }
        public int TotalPaidVotes { get; set; }
        public int TotalVotes { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }

    }
}
