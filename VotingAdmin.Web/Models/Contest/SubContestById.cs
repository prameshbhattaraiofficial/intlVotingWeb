namespace VotingAdmin.Web.Models.Contest
{
    public class SubContestById
    {

        public long ContestId { get; set; }
        public long SubContestId { get; set; }
        public string SubContestName { get; set; }
        public string SubContestDesc { get; set; }
        public string BannerImgPath { get; set; }
        public string SliderImgPath { get; set; }
        public bool IsActive { get; set; }
    }
}
