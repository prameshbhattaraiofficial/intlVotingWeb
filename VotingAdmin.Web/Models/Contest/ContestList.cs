namespace VotingAdmin.Web.Models.Contest
{
    public class ContestList
    {
        public long ContestId { get; set; }
        public string ContestName { get; set; }
        public string ContestDesc { get; set; }
        public string ContestBannerImgPath { get; set; }
        public string ContestSliderImgPath { get; set; }
        public string StartDateTime { get; set; }
        public string EndDateTime { get; set; }
        public bool IsPublished { get; set; }
        public string PublishedDateTime { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public string Status { get; set; }
        public bool IsActive { get; set; }
        public int TotalFreeVotes { get; set; }
        public int TotalPaidVotes { get; set; }
        public int TotalVotes { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
