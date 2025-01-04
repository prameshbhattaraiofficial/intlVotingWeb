namespace VotingAdmin.Web.Models.Contest
{
    public class ContestByID
    {

        public long ContestId { get; set; }
        public string ContestName { get; set; }
        public string ContestDesc { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string BannerImgPath { get; set; }
        public decimal PricePerVote { get; set; }
        public int PriorityOrder { get; set; }
        public string SliderImgPath { get; set; }
        public bool ContestIsActive { get; set; }
        public bool IsPublished { get; set; }
        public DateTime PublishedDateTime { get; set; }

    }
}
