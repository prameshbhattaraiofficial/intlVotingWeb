using VotingAdmin.Web.Common.Paging;
using VotingAdmin.Web.Dtos;
using VotingAdmin.Web.Dtos.GlobalSetting;
using VotingAdmin.Web.Models.GlobalSetting;
using VotingAdmin.Web.Services.Http.Voting;

namespace VotingAdmin.Web.Data.Repository.GlobalSetting
{
    public class GlobalSettingRepo : BaseRepository, IGlobalSettingRepo
    {
        private readonly IDgHttpClient _dgHttpClient;
        public GlobalSettingRepo(IDgHttpClient dgHttpClient)
        {
            _dgHttpClient = dgHttpClient;
        }
        public async Task<BaseDgApiResponse<GlobalsettingDto>> GetGlobalSetting()
        {
            var (_, globalsetting) = await _dgHttpClient.GetAsync<BaseDgApiResponse<GlobalsettingDto>>(DgApiUris.GetAllGlobalSettingurl);
            return globalsetting;
        }

        public async Task<BaseDgApiResponse<PagedResponse<GlobalsettingDto>>> GetGlobalSettingHistory(GlobalSettingFilter globalSettingFilter)
        {
            var (_, globalsetting) = await _dgHttpClient.GetAsync<BaseDgApiResponse<PagedResponse<GlobalsettingDto>>>(DgApiUris.GetGlobalSettinghistoryurl + "?pageNumber=" + globalSettingFilter.PageNumber + "&pageSize=" + globalSettingFilter.PageSize);
            //globalsetting.Data.PageNumber = globalSettingFilter.PageNumber;
            //globalsetting.Data.PageSize = globalSettingFilter.PageSize;
            return globalsetting;
        }

        public async Task<BaseDgApiResponse<GlobalSettingUpdate>> UpdateGlobalSetting(GlobalSettingUpdate globalSettingUpdate)
        {
            var bodyContent = GetJsonStringContent(globalSettingUpdate);
            var (_, globalsetting) = await _dgHttpClient.PostAsync<BaseDgApiResponse<GlobalSettingUpdate>>(DgApiUris.UpdateGlobalSettingurl, bodyContent);
            return globalsetting;
        }
    }
}
