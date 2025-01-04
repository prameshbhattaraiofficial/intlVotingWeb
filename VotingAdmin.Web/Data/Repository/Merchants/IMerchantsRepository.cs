using Voting.Core.Models.Merchants;
using VotingAdmin.Web.Common.Paging;
using VotingAdmin.Web.Dtos;
using VotingAdmin.Web.Dtos.Merchants;
using VotingAdmin.Web.Models.Merchants;

namespace VotingAdmin.Web.Data.Repository.Merchants
{
    public interface IMerchantsRepository
    {
        Task<DgApiResponse> AddMerchantAsync(MerchantAdd request);
        Task<DgApiResponse> UpdateMerchantAsync(MerchantUpdate request);
        Task<BaseDgApiResponse<MerchantWithoutCreds>> GetMerchantByIdAsync(int id);
        Task<BaseDgApiResponse<MerchantWithoutCreds>> GetMerchantByMerchantIdAsync(string merchantId);
        Task<BaseDgApiResponse<PagedResponse<MerchantListItem>>> GetMerchantsAsync(MerchantListRequest request);
    }
}
