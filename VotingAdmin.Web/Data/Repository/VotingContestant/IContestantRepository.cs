using VotingAdmin.Web.Common.Paging;
using VotingAdmin.Web.Dtos.contest;
using VotingAdmin.Web.Dtos;
using VotingAdmin.Web.Models.Contest;
using VotingAdmin.Web.Models.Contestant;
using VotingAdmin.Web.Dtos.Contestant;

namespace VotingAdmin.Web.Data.Repository.VotingContestant
{
    public interface IContestantRepository
    {
        Task<BaseDgApiResponse<PagedResponse<ContestantList>>> GetContestantListAsync(ContestantRequestDto request);
        Task<BaseDgApiResponse<CreateContestantDto>> AddContestantAsync(CreateContestantDto ContestantDto);
        Task<BaseDgApiResponse<UpdateContestant>> UpdateContestantAsync(UpdateContestant ContestantDto);
        Task<BaseDgApiResponse<string>> DeleteContestantAsync(DeleteContestant ContestantDto);
        Task<BaseDgApiResponse<ContestantDetail>> GetContestantByIdAsync(long ContestantId);
    }
}
