using VotingAdmin.Web.Common.Paging;
using VotingAdmin.Web.Dtos;
using VotingAdmin.Web.Dtos.Contestant;
using VotingAdmin.Web.Dtos.ContestPackages;
using VotingAdmin.Web.Models.Contest;
using VotingAdmin.Web.Models.Package;
using VotingAdmin.Web.Services.Http.Voting;

namespace VotingAdmin.Web.Data.Repository.Package
{
    public class PackageRepository : BaseRepository, IPackageRepository
    {
        private readonly IDgHttpClient _dgHttpClient;

        public PackageRepository(IDgHttpClient dgHttpClient)
        {
            _dgHttpClient = dgHttpClient;
        }

        public async Task<BaseDgApiResponse<AddPackageDto>> AddPackageAsync(AddPackageDto PackageDto)
        {
            var bodyContent = ToFormContent(PackageDto);
            var (_, Package) = await _dgHttpClient.PostAsync<BaseDgApiResponse<AddPackageDto>>(DgApiUris.VotingPackageAddUrl, bodyContent);
            return Package;
        }

        public async Task<BaseDgApiResponse<string>> DeletePackageAsync(long PackageId, long ContestId, long SubContestId)
        {
            var (_, Package) = await _dgHttpClient.DeleteAsync<BaseDgApiResponse<string>>(DgApiUris.VotingPackageDeleteUrl + "?PackageId=" + PackageId + "&SubcontestId="+ SubContestId +"&ContestId=" + ContestId);
            return Package;
        }

        public async Task<BaseDgApiResponse<PackageDetail>> GetPackageByIdAsync(long PackageId)
        {
            var (_, Package) = await _dgHttpClient.GetAsync<BaseDgApiResponse<PackageDetail>>(DgApiUris.VotingPackageByIDUrl + "?PackageId=" + PackageId);
            return Package;
        }

        public async Task<BaseDgApiResponse<PagedResponse<PackageList>>> GetPackageListAsync(PackageRequestDto request)
        {
            var bodyContent = GetJsonStringContent(request);
            var (_, PackageList) = await _dgHttpClient.PostAsync<BaseDgApiResponse<PagedResponse<PackageList>>>(DgApiUris.VotingPackageListtUrl, bodyContent);
            PackageList.Data.SortBy = request.SortBy;
            PackageList.Data.SortOrder = request.SortOrder;
            return PackageList;
        }

        public async Task<BaseDgApiResponse<UpdatePackageDto>> UpdatePackageAsync(UpdatePackageDto PackageDto)
        {
            var bodyContent = ToFormContent(PackageDto);
            var (_, Package) = await _dgHttpClient.PostAsync<BaseDgApiResponse<UpdatePackageDto>>(DgApiUris.VotingPackageUpdateUrl, bodyContent);
            return Package;
        }
    }
}
