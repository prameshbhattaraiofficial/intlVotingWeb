using DocumentFormat.OpenXml.Office2016.Excel;
using Voting.Core.Models.Contest;
using VotingAdmin.Web.Common.Paging;
using VotingAdmin.Web.Dtos;
using VotingAdmin.Web.Dtos.contest;
using VotingAdmin.Web.Dtos.Roles;
using VotingAdmin.Web.Models.Contest;
using VotingAdmin.Web.Models.Merchants;
using VotingAdmin.Web.Services.Http.Voting;

namespace VotingAdmin.Web.Data.Repository.VotingContest
{
    public class VotingContestRepository : BaseRepository, IVotingContestRepository
    {
        private readonly IDgHttpClient _dgHttpClient;

        public VotingContestRepository(IDgHttpClient dgHttpClient)
        {
            _dgHttpClient = dgHttpClient;
        }
        public async Task<BaseDgApiResponse<PagedResponse<ContestList>>> GetContestListAsync(ContestRequestDto request)
        {
            var bodyContent = GetJsonStringContent(request);
            var (_, Contestlist) = await _dgHttpClient.PostAsync<BaseDgApiResponse<PagedResponse<ContestList>>>(DgApiUris.VotingContestUrl, bodyContent);
            Contestlist.Data.SortBy = request.SortBy;
            Contestlist.Data.SortOrder = request.SortOrder;
            return Contestlist;
        }
        public async Task<BaseDgApiResponse<PagedResponse<ContestDetail>>> GetContestdetailListAsync(ContestRequestDto request)
        {
            var bodyContent = GetJsonStringContent(request);
            var (_, ContestDetaillist) = await _dgHttpClient.PostAsync<BaseDgApiResponse<PagedResponse<ContestDetail>>>(DgApiUris.VotingContestDetailUrl, bodyContent);
            ContestDetaillist.Data.SortBy = request.SortBy;
            ContestDetaillist.Data.SortOrder = request.SortOrder;
            return ContestDetaillist;
        }
        public async Task<BaseDgApiResponse<AddContestDto>> AddContestAsync(AddContestDto ContestDto)
        {
            var bodyContent = AddContestContent(ContestDto);
            var (_, contest) = await _dgHttpClient.PostAsync<BaseDgApiResponse<AddContestDto>>(DgApiUris.VotingContestAddlUrl, bodyContent);
            return contest;
        }
        public async Task<BaseDgApiResponse<AddSubContest>> AddSubContestAsync(AddSubContest ContestDto)
        {
            var bodyContent = AddSubContestContent(ContestDto);
            var (_, contest) = await _dgHttpClient.PostAsync<BaseDgApiResponse<AddSubContest>>(DgApiUris.VotingContestAddSubUrl, bodyContent);
            return contest;
        }
        public async Task<BaseDgApiResponse<UpdateContestDto>> UpdateContestAsync(UpdateContest ContestDto)
        {
            var bodyContent = ToFormContent(ContestDto);
            var (_, contest) = await _dgHttpClient.PostAsync<BaseDgApiResponse<UpdateContestDto>>(DgApiUris.VotingContestUpdateUrl, bodyContent);
            return contest;
        }
        public async Task<BaseDgApiResponse<UpdateSubContestDto>> UpdateSubContestAsync(UpdateSubContest ContestDto)
        {
            var bodyContent = ToFormContent(ContestDto);
            var (_, contest) = await _dgHttpClient.PostAsync<BaseDgApiResponse<UpdateSubContestDto>>(DgApiUris.VotingSubContestUpdateUrl, bodyContent);
            return contest;
        }

        public async Task<BaseDgApiResponse<string>> DeleteContestAsync(long ContestId)
        {
            var (_, contest) = await _dgHttpClient.DeleteAsync<BaseDgApiResponse<string>>(DgApiUris.VotingContestDeleteUrl +"?ContestId=" + ContestId);
            return contest;
        }

        public async Task<BaseDgApiResponse<string>> PublishContestAsync(long ContestId)
        {
            var data = new DeleteContest
            {
                ContestId = ContestId
            };
            var bodyContent = GetJsonStringContent(data);
            var (_, contest) = await _dgHttpClient.PostAsync<BaseDgApiResponse<string>>(DgApiUris.VotingContestPublishUrl, bodyContent);
            return contest;
        }
        public async Task<BaseDgApiResponse<string>> UnPublishContestAsync(long ContestId)
        {
            var data = new DeleteContest
            {
                ContestId = ContestId
            };
            var bodyContent = GetJsonStringContent(data);
            var (_, contest) = await _dgHttpClient.PostAsync<BaseDgApiResponse<string>>(DgApiUris.VotingContestUnPublishUrl, bodyContent);
            return contest;
        }
        public async Task<BaseDgApiResponse<string>> DeleteSubContestAsync(long ContestId,long SubContestId)
        {
            var (_, contest) = await _dgHttpClient.DeleteAsync<BaseDgApiResponse<string>>(DgApiUris.VotingSubContestDeleteUrl + "?CustomerId=" + ContestId + "&SubContestId=" + SubContestId);
            return contest;
        }

        public async  Task<BaseDgApiResponse<ContestByID>> GetContestByIdAsync(long ContestId)
        {
            var (_, contest) = await _dgHttpClient.GetAsync<BaseDgApiResponse<ContestByID>>(DgApiUris.VotingContestByIDUrl + "?ContestId=" + ContestId);
            return contest;
        }
        public async Task<BaseDgApiResponse<SubContestById>> GetSubContestByIdAsync(long SubContestId)
        {
            var (_, contest) = await _dgHttpClient.GetAsync<BaseDgApiResponse<SubContestById>>(DgApiUris.VotingSubContestByIDUrl + "?SubContestId=" + SubContestId);
            return contest;
        }
        
        public async Task<BaseDgApiResponse<IEnumerable<MerchantDdl>>> GetMerchantDdlAsync()
        {
            var (_, Merchant) = await _dgHttpClient.GetAsync<BaseDgApiResponse<IEnumerable<MerchantDdl>>>(DgApiUris.VotingMerchantDdl);
            return Merchant;
        }
    }
}
