using DocumentFormat.OpenXml.Office2016.Excel;
using System.IO.Packaging;
using VotingAdmin.Web.Common.Paging;
using VotingAdmin.Web.Dtos;
using VotingAdmin.Web.Dtos.contest;
using VotingAdmin.Web.Dtos.Contestant;
using VotingAdmin.Web.Models.Contest;
using VotingAdmin.Web.Models.Contestant;
using VotingAdmin.Web.Services.Http.Voting;

namespace VotingAdmin.Web.Data.Repository.VotingContestant
{
    public class ContestantRepository :BaseRepository, IContestantRepository
    {
        private readonly IDgHttpClient _dgHttpClient;

        public ContestantRepository(IDgHttpClient dgHttpClient)
        {
            _dgHttpClient = dgHttpClient;
        }
        public async Task<BaseDgApiResponse<PagedResponse<ContestantList>>> GetContestantListAsync(ContestantRequestDto request)
        {
            var bodyContent = GetJsonStringContent(request);
            var (_, Contestantlist) = await _dgHttpClient.PostAsync<BaseDgApiResponse<PagedResponse<ContestantList>>>(DgApiUris.VotingContestantUrl, bodyContent);
            Contestantlist.Data.SortBy = request.SortBy;
            Contestantlist.Data.SortOrder = request.SortOrder;
            return Contestantlist;
        }

        public async Task<BaseDgApiResponse<CreateContestantDto>> AddContestantAsync(CreateContestantDto ContestDto)
        {
            var bodyContent = ToFormContent(ContestDto);
            var (_, contestant) = await _dgHttpClient.PostAsync<BaseDgApiResponse<CreateContestantDto>>(DgApiUris.VotingContestantAddUrl, bodyContent);
            return contestant;
        }
          public async Task<BaseDgApiResponse<UpdateContestant>> UpdateContestantAsync(UpdateContestant ContestantDto)
        {
            var bodyContent = ToFormContent(ContestantDto);
            var (_, contestant) = await _dgHttpClient.PostAsync<BaseDgApiResponse<UpdateContestant>>(DgApiUris.VotingContestantUpdateUrl, bodyContent);
            return contestant;
        }

        public async Task<BaseDgApiResponse<string>> DeleteContestantAsync(DeleteContestant ContestantDto)
        {
            //var bodyContent = GetJsonStringContent(ContestantDto);
            var (_, contestant) = await _dgHttpClient.DeleteAsync<BaseDgApiResponse<string>>(DgApiUris.VotingContestantDeleteUrl+ "?ContestantId="+ ContestantDto.ContestantId + "&contestId="+ ContestantDto.ContestId + "&SubContestId=" + ContestantDto.SubContestId);
            return contestant;
        }

        public async Task<BaseDgApiResponse<ContestantDetail>> GetContestantByIdAsync(long ContestantId)
        {
            var (_, contestant) = await _dgHttpClient.GetAsync<BaseDgApiResponse<ContestantDetail>>(DgApiUris.VotingContestantByIDUrl + "?ContestantId=" + ContestantId);
            return contestant;
        }
    }
}
