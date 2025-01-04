using Voting.Core.Models.Contest;
using VotingAdmin.Web.Common.Paging;
using VotingAdmin.Web.Dtos;
using VotingAdmin.Web.Dtos.contest;
using VotingAdmin.Web.Models.Contest;
using VotingAdmin.Web.Models.Merchants;

namespace VotingAdmin.Web.Data.Repository.VotingContest
{
    public interface IVotingContestRepository
    {
        Task<BaseDgApiResponse<PagedResponse<ContestList>>> GetContestListAsync(ContestRequestDto request);
        Task<BaseDgApiResponse<PagedResponse<ContestDetail>>> GetContestdetailListAsync(ContestRequestDto request);
        Task<BaseDgApiResponse<AddContestDto>> AddContestAsync(AddContestDto ContestDto);
        Task<BaseDgApiResponse<IEnumerable<MerchantDdl>>> GetMerchantDdlAsync();
        Task<BaseDgApiResponse<AddSubContest>> AddSubContestAsync(AddSubContest ContestDto);
        Task<BaseDgApiResponse<UpdateContestDto>> UpdateContestAsync(UpdateContest ContestDto);
        Task<BaseDgApiResponse<UpdateSubContestDto>> UpdateSubContestAsync(UpdateSubContest ContestDto);
        Task<BaseDgApiResponse<String>> DeleteContestAsync(long ContestId);
        Task<BaseDgApiResponse<String>> PublishContestAsync(long ContestId);
        Task<BaseDgApiResponse<String>> UnPublishContestAsync(long ContestId);
        Task<BaseDgApiResponse<String>> DeleteSubContestAsync(long ContestId,long SubContestId);
        Task<BaseDgApiResponse<ContestByID>> GetContestByIdAsync(long ContestId);
        Task<BaseDgApiResponse<SubContestById>> GetSubContestByIdAsync(long SubContestId);
    }
}

