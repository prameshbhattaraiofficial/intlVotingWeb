namespace VotingAdmin.Web.Models.Package
{
    public class PackageDetail
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
    }
}
