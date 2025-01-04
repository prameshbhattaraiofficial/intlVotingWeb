namespace VotingAdmin.Web.Models.Package
{
    public class PackageList
    {
        public long PackageId { get; set; }
        public long ContestId { get; set; }
        public string ContestName { get; set; }
        public long SubContestId { get; set; }
        public string SubContestName { get; set; }
        public string PackageName { get; set; }
        public string Description { get; set; }
        public int MinVote { get; set; }
        public int MaxVote { get; set; }
        public decimal PricePerVote { get; set; }
        public bool IsPaid { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedDateString { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedLocalDateString { get; set; }
    }
}
