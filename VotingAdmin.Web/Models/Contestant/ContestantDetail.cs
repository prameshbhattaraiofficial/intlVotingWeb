namespace VotingAdmin.Web.Models.Contestant
{
    public class ContestantDetail
    {
        public long ContestantId { get; set; }
        public long ContestId { get; set; }
        public long SubContestId { get; set; }
        public string ContestName { get; set; }
        public string SubContestName { get; set; }
        public string ContestantName { get; set; }
        public string ContestantNumber { get; set; }
        public string Description { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int Age { get; set; }
        public int GenderId { get; set; }
        public string Gender { get; set; }
        public string PhotoImagePath { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
        public string CountryCode { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedLocalDate { get; set; }
        public string CreatedUtcDate { get; set; }
        public string CreatedNepaliDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedLocalDate { get; set; }
        public string UpdatedUtcDate { get; set; }
        public string UpdatedNepaliDate { get; set; }
        public bool isActive { get; set; }
    }
}
