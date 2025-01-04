using VotingAdmin.Web.Common.Paging;
using VotingAdmin.Web.Dtos.contest;
using VotingAdmin.Web.Dtos;
using VotingAdmin.Web.Models.Contest;
using VotingAdmin.Web.Dtos.Contestant;
using VotingAdmin.Web.Models.Contestant;

namespace VotingAdmin.Web.Services.Contestant
{
    public interface IContestantService
    {
        Task<BaseDgApiResponse<PagedResponse<ContestantList>>> GetContestantListAsync(ContestantRequestDto request);
        Task<BaseDgApiResponse<CreateContestantDto>> AddContestantAsync(CreateContestantDto ContestantDto);
        Task<BaseDgApiResponse<UpdateContestant>> UpdateContestantAsync(UpdateContestantDto ContestantDto);
        Task<BaseDgApiResponse<ContestantDetail>> GetContestantByIdAsync(long ContestantId);
        Task<BaseDgApiResponse<string>> DeleteContestantAsync(DeleteContestant ContestantDto);
    }
}
