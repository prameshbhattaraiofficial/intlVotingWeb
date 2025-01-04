using System.ComponentModel.DataAnnotations;

namespace VotingAdmin.Web.Dtos.contest
{
    public class AddSubContest
    {
        [Required]
        public long ContestId { get; set; }
        public List<AddSubContestDto> SubContestDtos { get; set; }
    }
    public class AddSubContestDto
    {
        public string SubContestName { get; set; }
        public string SubContestDesc { get; set; }
        public IFormFile BannerImg { get; set; }
        public IFormFile SliderImg { get; set; }

    }

}
