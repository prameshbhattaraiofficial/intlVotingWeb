namespace VotingAdmin.Web.Models.Contestant
{
    public class UpdateContestant
    {

        public long ContestantId { get; set; }
        public long ContestId { get; set; }
        public long SubContestId { get; set; }
        public string ContestantName { get; set; }
        public string ContestantNo { get; set; }
        public string Description { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int Age { get; set; }
        public int GenderId { get; set; }
        public string Gender { get; set; }
        public IFormFile PhotoImage { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
        public string CountryCode { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
    }
}
