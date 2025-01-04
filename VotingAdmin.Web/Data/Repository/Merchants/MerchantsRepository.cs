using Voting.Core.Models.Merchants;
using VotingAdmin.Web.Common.Paging;
using VotingAdmin.Web.Dtos;
using VotingAdmin.Web.Dtos.Merchants;
using VotingAdmin.Web.Helper;
using VotingAdmin.Web.Models.Merchants;
using VotingAdmin.Web.Services.Http.Voting;

namespace VotingAdmin.Web.Data.Repository.Merchants
{
    public class MerchantsRepository : BaseRepository, IMerchantsRepository
    {
        private readonly IDgHttpClient _votingHttpClient;

        public MerchantsRepository(IDgHttpClient dgHttpClient)
        {
            _votingHttpClient = dgHttpClient;
        }

        public async Task<DgApiResponse> AddMerchantAsync(MerchantAdd request)
        {
            var addMerchantFormContent = new MultipartFormDataContent
            {
                { new StringContent(request.UserName ?? string.Empty), nameof(request.UserName) },
                { new StringContent(request.FullName ?? string.Empty), nameof(request.FullName) },
                { new StringContent(request.Email ?? string.Empty), nameof(request.Email) },
                { new StringContent(request.Mobile ?? string.Empty), nameof(request.Mobile) },
                { new StringContent(request.Address ?? string.Empty), nameof(request.Address) },
                { new StringContent(request.GenderId.ToString()), nameof(request.GenderId) },
                { new StringContent(request.Department ?? string.Empty), nameof(request.Department) },
                { new StringContent(request.DateOfBirth?.ToString("yyyy-MM-ddTHH:mm:ss.fff") ?? string.Empty), nameof(request.DateOfBirth) },
                { new StringContent(request.DateOfJoining?.ToString("yyyy-MM-ddTHH:mm:ss.fff") ?? string.Empty), nameof(request.FullName) },
                { new StringContent(request.AccessCode ?? string.Empty), nameof(request.AccessCode) },
                { new StringContent(request.Password ?? string.Empty), nameof(request.Password) },
                { new StringContent(request.ConfirmPassword ?? string.Empty), nameof(request.ConfirmPassword) },
                { new StringContent(request.IsActive.ToString()), nameof(request.IsActive) },
                { new StringContent(request.PANNumber ?? string.Empty), nameof(request.PANNumber) },
                { new StringContent(request.OrganizationName ?? string.Empty), nameof(request.OrganizationName) },
                { new StringContent(request.RegistrationNumber ?? string.Empty), nameof(request.RegistrationNumber) },
                { new StringContent(request.DirectorName ?? string.Empty), nameof(request.DirectorName) },
            };

            if (request.ProfileImage is not null && request.ProfileImage.Length > 0)
            {
                var bytes = FileHelper.GenerateByteArrayFromFile(request.ProfileImage);
                addMerchantFormContent.Add(bytes, nameof(request.ProfileImage), request.ProfileImage.FileName);
            }

            if (request.PANDocument is not null && request.PANDocument.Length > 0)
            {
                var bytes = FileHelper.GenerateByteArrayFromFile(request.PANDocument);
                addMerchantFormContent.Add(bytes, nameof(request.PANDocument), request.PANDocument.FileName);
            }

            var (_, response) = await _votingHttpClient
                .PostAsync<DgApiResponse>(VotingApiUris.MerchantAddUri, addMerchantFormContent);

            return response;
        }

        public async Task<BaseDgApiResponse<MerchantWithoutCreds>> GetMerchantByIdAsync(int id)
        {
            var (_, response) = await _votingHttpClient
                .GetAsync<BaseDgApiResponse<MerchantWithoutCreds>>($"{VotingApiUris.MerchantGetByIdUri}?id={id}");

            return response;
        }

        public async Task<BaseDgApiResponse<MerchantWithoutCreds>> GetMerchantByMerchantIdAsync(string merchantId)
        {
            var (_, response) = await _votingHttpClient
                .GetAsync<BaseDgApiResponse<MerchantWithoutCreds>>($"{VotingApiUris.MerchantGetByMerchantIdUri}?merchantId={merchantId}");

            return response;
        }

        public async Task<BaseDgApiResponse<PagedResponse<MerchantListItem>>> GetMerchantsAsync(MerchantListRequest request)
        {
            var requestPayload = GetJsonStringContent(request);

            var (_, response) = await _votingHttpClient
                .PostAsync<BaseDgApiResponse<PagedResponse<MerchantListItem>>>(VotingApiUris.MerchantGetListUri, requestPayload);

            return response;
        }

        public async Task<DgApiResponse> UpdateMerchantAsync(MerchantUpdate request)
        {
            var updateMerchantFormContent = new MultipartFormDataContent
            {
                { new StringContent(request.Id.ToString()), nameof(request.Id) },
                { new StringContent(request.FullName ?? string.Empty), nameof(request.FullName) },
                { new StringContent(request.Email ?? string.Empty), nameof(request.Email) },
                { new StringContent(request.Mobile ?? string.Empty), nameof(request.Mobile) },
                { new StringContent(request.Address ?? string.Empty), nameof(request.Address) },
                { new StringContent(request.GenderId.ToString()), nameof(request.GenderId) },
                { new StringContent(request.Department ?? string.Empty), nameof(request.Department) },
                { new StringContent(request.DateOfBirth?.ToString("yyyy-MM-ddTHH:mm:ss.fff") ?? string.Empty), nameof(request.DateOfBirth) },
                { new StringContent(request.DateOfJoining?.ToString("yyyy-MM-ddTHH:mm:ss.fff") ?? string.Empty), nameof(request.FullName) },
                { new StringContent(request.IsActive.ToString()), nameof(request.IsActive) },
                { new StringContent(request.PANNumber ?? string.Empty), nameof(request.PANNumber) },
                { new StringContent(request.OrganizationName ?? string.Empty), nameof(request.OrganizationName) },
                { new StringContent(request.RegistrationNumber ?? string.Empty), nameof(request.RegistrationNumber) },
                { new StringContent(request.DirectorName ?? string.Empty), nameof(request.DirectorName) },
            };

            if (request.ProfileImage is not null && request.ProfileImage.Length > 0)
            {
                var bytes = FileHelper.GenerateByteArrayFromFile(request.ProfileImage);
                updateMerchantFormContent.Add(bytes, nameof(request.ProfileImage), request.ProfileImage.FileName);
            }

            if (request.PANDocument is not null && request.PANDocument.Length > 0)
            {
                var bytes = FileHelper.GenerateByteArrayFromFile(request.PANDocument);
                updateMerchantFormContent.Add(bytes, nameof(request.PANDocument), request.PANDocument.FileName);
            }

            var (_, response) = await _votingHttpClient
                .PostAsync<DgApiResponse>(VotingApiUris.MerchantUpdateUri, updateMerchantFormContent);

            return response;
        }
    }
}
