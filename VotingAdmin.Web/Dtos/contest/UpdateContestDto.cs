using System.ComponentModel.DataAnnotations;

namespace VotingAdmin.Web.Dtos.contest
{
    public class UpdateContestDto
    {
        [Required]
        public long ContestId { get; set; }
        [Required]
        public string MerchantId { get; set; }
        [Required]
        public string ContestName { get; set; }
        public string ContestDesc { get; set; }
        public IFormFile BannerImg { get; set; }
        public string BannerImgPath { get; set; }
        public IFormFile SliderImg { get; set; }
        [Required]
        public DateTime StartDateTime { get; set; }
        [Required]
        public DateTime EndDateTime { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int PriorityOrder { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public decimal PricePerVote { get; set; }
        public bool IsActive { get; set; }
    }
}
