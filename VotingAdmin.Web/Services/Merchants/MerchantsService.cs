using Voting.Core.Models.Merchants;
using VotingAdmin.Web.Common.Paging;
using VotingAdmin.Web.Dtos.Merchants;
using VotingAdmin.Web.Dtos;
using VotingAdmin.Web.Models.Merchants;
using VotingAdmin.Web.Data.Repository.Merchants;

namespace VotingAdmin.Web.Services.Merchants
{
    public class MerchantsService : IMerchantsService
    {
        private readonly IMerchantsRepository _merchantsRepository;

        public MerchantsService(IMerchantsRepository merchantsRepository)
        {
            _merchantsRepository = merchantsRepository;
        }

        public Task<DgApiResponse> AddMerchantAsync(MerchantAdd request)
        {
            return _merchantsRepository.AddMerchantAsync(request);
        }

        public Task<BaseDgApiResponse<MerchantWithoutCreds>> GetMerchantByIdAsync(int id)
        {
            return _merchantsRepository.GetMerchantByIdAsync(id);
        }

        public Task<BaseDgApiResponse<MerchantWithoutCreds>> GetMerchantByMerchantIdAsync(string merchantId)
        {
            return _merchantsRepository.GetMerchantByMerchantIdAsync(merchantId);
        }

        public Task<BaseDgApiResponse<PagedResponse<MerchantListItem>>> GetMerchantsAsync(MerchantListRequest request)
        {
            return _merchantsRepository.GetMerchantsAsync(request);
        }

        public Task<DgApiResponse> UpdateMerchantAsync(MerchantUpdate request)
        {
            return _merchantsRepository.UpdateMerchantAsync(request);
        }
    }
}
