using VotingAdmin.Web.Common.Paging;
using VotingAdmin.Web.Dtos;
using VotingAdmin.Web.Dtos.GlobalSetting;
using VotingAdmin.Web.Models.GlobalSetting;

namespace VotingAdmin.Web.Services.GlobalSetting
{
    public interface IGlobalSettingServices
    {
        Task<BaseDgApiResponse<GlobalsettingDto>> GetGlobalSetting();
        Task<BaseDgApiResponse<GlobalSettingUpdate>> UpdateGlobalSetting(GlobalsettingDto globalsettingDto);
        Task<BaseDgApiResponse<PagedResponse<GlobalsettingDto>>> GetGlobalSettingHistory(GlobalSettingFilter globalSettingFilter);

    }
}
