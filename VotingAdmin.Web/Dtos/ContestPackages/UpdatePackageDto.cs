namespace VotingAdmin.Web.Dtos.ContestPackages
{
    public class UpdatePackageDto : AddPackageDto
    {
        public long PackageId { get; set; }
        public bool IsActive { get; set; }
    }
}
