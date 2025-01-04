namespace VotingAdmin.Web.Models.Contest
{
    public class UpdateContest
    {

        public long ContestId { get; set; }
        public string MerchantId { get; set; }
        public string ContestName { get; set; }
        public string ContestDesc { get; set; }
        public IFormFile BannerImg { get; set; }
        public IFormFile SliderImg { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int PriorityOrder { get; set; }
        public decimal PricePerVote { get; set; }
        public bool IsActive { get; set; }
    }
}
