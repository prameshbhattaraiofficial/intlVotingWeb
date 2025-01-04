using AutoMapper;
using Voting.Core.Models.Contest;
using VotingAdmin.Web.Common.Paging;
using VotingAdmin.Web.Data.Repository.VotingContest;
using VotingAdmin.Web.Dtos;
using VotingAdmin.Web.Dtos.contest;
using VotingAdmin.Web.Models.Contest;
using VotingAdmin.Web.Models.Merchants;

namespace VotingAdmin.Web.Services.Contest
{
    public class VotingContestService : IVotingContestService
    {
        private readonly IVotingContestRepository _contestRepository;
        private readonly IMapper _mapper;

        public VotingContestService(IVotingContestRepository contestRepository
            ,IMapper mapper)
        {
            _contestRepository = contestRepository;
            _mapper = mapper;
        }
        public async Task<BaseDgApiResponse<IEnumerable<MerchantDdl>>> GetMerchantDdl()
        {
            var Merchant = await _contestRepository.GetMerchantDdlAsync();
            return Merchant;
        }

        public async Task<BaseDgApiResponse<AddContestDto>> AddContestAsync(AddContestDto ContestDto)
        {
            var AddContestresponce = await _contestRepository.AddContestAsync(ContestDto);
            return AddContestresponce;
        }
        public async Task<BaseDgApiResponse<AddSubContest>> AddSubContestAsync(AddSubContest ContestDto)
        {
            var AddSubContestresponce = await _contestRepository.AddSubContestAsync(ContestDto);
            return AddSubContestresponce;
        }
        public async Task<BaseDgApiResponse<UpdateContestDto>> UpdateContestAsync(UpdateContestDto ContestDto)
        {
            var updateRequest = _mapper.Map<UpdateContest>(ContestDto);

            var UpdateContestresponce = await _contestRepository.UpdateContestAsync(updateRequest);
            return UpdateContestresponce;
        }
         public async Task<BaseDgApiResponse<UpdateSubContestDto>> UpdateSubContestAsync(UpdateSubContestDto SubContestDto)
        {
            var updateRequest = _mapper.Map<UpdateSubContest>(SubContestDto);

            var UpdateContestresponce = await _contestRepository.UpdateSubContestAsync(updateRequest);
            return UpdateContestresponce;
        }

        public async Task<BaseDgApiResponse<string>> DeleteContestAsync(long ContestId)
        {
            var Delete = await _contestRepository.DeleteContestAsync(ContestId);
            return Delete;
        }
        public async Task<BaseDgApiResponse<string>> PublishContestAsync(long ContestId)
        {
            var Publish = await _contestRepository.PublishContestAsync(ContestId);
            return Publish;
        }
        public async Task<BaseDgApiResponse<string>> UnPublishContestAsync(long ContestId)
        {
            var Publish = await _contestRepository.UnPublishContestAsync(ContestId);
            return Publish;
        }
        public async Task<BaseDgApiResponse<string>> DeleteSubContestAsync(long ContestId,long SubContestId)
        {
            var Delete = await _contestRepository.DeleteSubContestAsync(ContestId, SubContestId);
            return Delete;
        }

        public async  Task<BaseDgApiResponse<ContestByID>> GetContestByIdAsync(long ContestId)
        {
            var contest = await _contestRepository.GetContestByIdAsync(ContestId);
            return contest;
        }
         public async  Task<BaseDgApiResponse<SubContestById>> GetSubContestByIdAsync(long SubContestId)
        {
            var contest = await _contestRepository.GetSubContestByIdAsync(SubContestId);
            return contest;
        }

        public async Task<BaseDgApiResponse<PagedResponse<ContestDetail>>> GetContestDetailListAsync(ContestRequestDto request)
        {
            var result = await _contestRepository.GetContestdetailListAsync(request);
            return result;
        }

        public async Task<BaseDgApiResponse<PagedResponse<ContestList>>> GetContestListAsync(ContestRequestDto request)
        {
            var result = await _contestRepository.GetContestListAsync(request);
            return result;
        }

       
    }
}
