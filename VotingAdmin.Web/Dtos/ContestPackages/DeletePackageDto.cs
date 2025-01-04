namespace VotingAdmin.Web.Dtos.ContestPackages
{
    public class DeletePackageDto
    {
        public long PackageId { get; set; }
        public long ContestId { get; set; }
        public long SubContestId { get; set; }

    }
}
