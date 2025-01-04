using System.ComponentModel.DataAnnotations;

namespace VotingAdmin.Web.Dtos.ContestPackages
{
    public class AddPackageDto
    {
        [Required]
        public long ContestId { get; set; }
        [Required]
        public long SubContestId { get; set; }
        public string PackageName { get; set; }
        public string Description { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value greater than 1")]
        public int MinVote { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value greater than 1")]
        public int MaxVote { get; set; }
        [Required]
        [Range(0.1, int.MaxValue, ErrorMessage = "Please enter a value greater than {1}")]
        public decimal PricePerVote { get; set; }
        public bool IsPaid { get; set; }
    }


}
