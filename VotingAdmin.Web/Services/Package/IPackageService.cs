using VotingAdmin.Web.Common.Paging;
using VotingAdmin.Web.Dtos.contest;
using VotingAdmin.Web.Dtos;
using VotingAdmin.Web.Models.Contest;
using VotingAdmin.Web.Models.Package;
using VotingAdmin.Web.Dtos.Contestant;
using VotingAdmin.Web.Dtos.ContestPackages;

namespace VotingAdmin.Web.Services.Package
{
    public interface IPackageService
    {
        Task<BaseDgApiResponse<PagedResponse<PackageList>>> GetPackageListAsync(PackageRequestDto request);
        Task<BaseDgApiResponse<AddPackageDto>> AddPackageAsync(AddPackageDto PackageDto);
        Task<BaseDgApiResponse<String>> DeletePackageAsync(long PackageId,long ContestId,long SubContestId);
        Task<BaseDgApiResponse<PackageDetail>> GetPackageByIdAsync(long PackageId);
        Task<BaseDgApiResponse<UpdatePackageDto>> UpdatePackageAsync(UpdatePackageDto PackageDto);

    }
}
