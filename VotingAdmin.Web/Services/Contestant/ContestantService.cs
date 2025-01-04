using AutoMapper;
using VotingAdmin.Web.Common.Paging;
using VotingAdmin.Web.Data.Repository.VotingContestant;
using VotingAdmin.Web.Dtos;
using VotingAdmin.Web.Dtos.Contestant;
using VotingAdmin.Web.Models.Contest;
using VotingAdmin.Web.Models.Contestant;

namespace VotingAdmin.Web.Services.Contestant
{
    public class ContestantService : IContestantService
    {
        private readonly IContestantRepository _contestantRepository;
        private readonly IMapper _mapper;

        public ContestantService(IContestantRepository contestantRepository,
            IMapper mapper)
        {
            _contestantRepository = contestantRepository;
            _mapper = mapper;
        }

        public async Task<BaseDgApiResponse<PagedResponse<ContestantList>>> GetContestantListAsync(ContestantRequestDto request)
        {
            var result = await _contestantRepository.GetContestantListAsync(request);
            return result;
        }
        public async Task<BaseDgApiResponse<CreateContestantDto>> AddContestantAsync(CreateContestantDto ContestantDto)
        {
            var AddContestantresponce = await _contestantRepository.AddContestantAsync(ContestantDto);
            return AddContestantresponce;
        }
         public async Task<BaseDgApiResponse<UpdateContestant>> UpdateContestantAsync(UpdateContestantDto ContestantDto)
        {
            var UpdateData = _mapper.Map<UpdateContestant>(ContestantDto);
            var UpdateContestantresponce = await _contestantRepository.UpdateContestantAsync(UpdateData);
            return UpdateContestantresponce;
        }

        public async Task<BaseDgApiResponse<string>> DeleteContestantAsync(DeleteContestant ContestantDto)
        {
            var DeleteContestant = await _contestantRepository.DeleteContestantAsync(ContestantDto);
            return DeleteContestant;
        }

        public async Task<BaseDgApiResponse<ContestantDetail>> GetContestantByIdAsync(long ContestantId)
        {
            var Contestant = await _contestantRepository.GetContestantByIdAsync(ContestantId);
            return Contestant;
        }
    }
}
