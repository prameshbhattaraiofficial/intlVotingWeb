using System.ComponentModel.DataAnnotations;

namespace VotingAdmin.Web.Dtos.Contestant
{
    public class CreateContestantDto
    {
        [Required]
        public long ContestId { get; set; }
        [Required]
        public long SubContestId { get; set; }
        [Required]
        public string ContestantName { get; set; }
        [Required]
        public string ContestantNo { get; set; }
        public string Description { get; set; }
        public DateTime? DateOfBirth { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public int GenderId { get; set; } = 1;
        public string Gender { get; set; }
        [Required]
        public IFormFile PhotoImage { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
        [Required]
        public string CountryCode { get; set; } = "NP";
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
    }
}
