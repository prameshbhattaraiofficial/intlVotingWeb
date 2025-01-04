using Voting.Core.Models.Contest;
using VotingAdmin.Web.Common.Paging;
using VotingAdmin.Web.Dtos;
using VotingAdmin.Web.Dtos.contest;
using VotingAdmin.Web.Dtos.Roles;
using VotingAdmin.Web.Models.Contest;
using VotingAdmin.Web.Models.Merchants;

namespace VotingAdmin.Web.Services.Contest
{
    public interface IVotingContestService
    {
        Task<BaseDgApiResponse<PagedResponse<ContestList>>> GetContestListAsync(ContestRequestDto request);
        Task<BaseDgApiResponse<ContestByID>> GetContestByIdAsync(long ContestId);
        Task<BaseDgApiResponse<SubContestById>> GetSubContestByIdAsync(long SubContestId);
        Task<BaseDgApiResponse<PagedResponse<ContestDetail>>> GetContestDetailListAsync(ContestRequestDto request);
        Task<BaseDgApiResponse<AddContestDto>> AddContestAsync(AddContestDto ContestDto);
        Task<BaseDgApiResponse<IEnumerable<MerchantDdl>>> GetMerchantDdl();

        Task<BaseDgApiResponse<AddSubContest>> AddSubContestAsync(AddSubContest ContestDto);
        Task<BaseDgApiResponse<UpdateContestDto>> UpdateContestAsync(UpdateContestDto ContestDto);
        Task<BaseDgApiResponse<UpdateSubContestDto>> UpdateSubContestAsync(UpdateSubContestDto ContestDto);
        Task<BaseDgApiResponse<String>> DeleteContestAsync(long contestId);
        Task<BaseDgApiResponse<String>> PublishContestAsync(long contestId);
        Task<BaseDgApiResponse<String>> UnPublishContestAsync(long contestId);
        Task<BaseDgApiResponse<String>> DeleteSubContestAsync(long contestId,long SubContestId);
    }
}
