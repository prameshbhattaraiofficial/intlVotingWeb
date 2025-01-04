using Voting.Core.Models.Merchants;
using VotingAdmin.Web.Common.Paging;
using VotingAdmin.Web.Dtos.Merchants;
using VotingAdmin.Web.Dtos;
using VotingAdmin.Web.Models.Merchants;

namespace VotingAdmin.Web.Services.Merchants
{
    public interface IMerchantsService
    {
        Task<DgApiResponse> AddMerchantAsync(MerchantAdd request);
        Task<DgApiResponse> UpdateMerchantAsync(MerchantUpdate request);
        Task<BaseDgApiResponse<MerchantWithoutCreds>> GetMerchantByIdAsync(int id);
        Task<BaseDgApiResponse<MerchantWithoutCreds>> GetMerchantByMerchantIdAsync(string merchantId);
        Task<BaseDgApiResponse<PagedResponse<MerchantListItem>>> GetMerchantsAsync(MerchantListRequest request);
    }
}
