namespace VotingAdmin.Web.Models.Contest
{
    public class UpdateSubContest
    {
        public long ContestId { get; set; }
        public long SubContestId { get; set; }
        public string SubContestName { get; set; }
        public string SubContestDesc { get; set; }
        public IFormFile BannerImg { get; set; }
        public bool IsActive { get; set; }
    }
}
