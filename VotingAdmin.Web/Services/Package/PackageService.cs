using VotingAdmin.Web.Common.Paging;
using VotingAdmin.Web.Data.Repository.Package;
using VotingAdmin.Web.Dtos;
using VotingAdmin.Web.Dtos.contest;
using VotingAdmin.Web.Dtos.ContestPackages;
using VotingAdmin.Web.Models.Contest;
using VotingAdmin.Web.Models.Package;

namespace VotingAdmin.Web.Services.Package
{
    public class PackageService : IPackageService
    {
        private readonly IPackageRepository _packageRepository;

        public PackageService(IPackageRepository packageRepository)
        {
            _packageRepository = packageRepository;
        }
        public async Task<BaseDgApiResponse<PagedResponse<PackageList>>> GetPackageListAsync(PackageRequestDto request)
        {
            var result = await _packageRepository.GetPackageListAsync(request);
            return result;
        }
        public async Task<BaseDgApiResponse<AddPackageDto>> AddPackageAsync(AddPackageDto PackageDto)
        {
            var AddPackageresponce = await _packageRepository.AddPackageAsync(PackageDto);
            return AddPackageresponce;
        }

        public async  Task<BaseDgApiResponse<string>> DeletePackageAsync(long PackageId, long ContestId, long SubContestId)
        {
            var Delete = await _packageRepository.DeletePackageAsync(PackageId,ContestId,SubContestId);
            return Delete;
        }

        public async  Task<BaseDgApiResponse<PackageDetail>> GetPackageByIdAsync(long PackageId)
        {
            var contest = await _packageRepository.GetPackageByIdAsync(PackageId);
            return contest;
        }

        public async  Task<BaseDgApiResponse<UpdatePackageDto>> UpdatePackageAsync(UpdatePackageDto PackageDto)
        {
           
            var UpdateContestresponce = await _packageRepository.UpdatePackageAsync(PackageDto);
            return UpdateContestresponce;
        }
    }
}
