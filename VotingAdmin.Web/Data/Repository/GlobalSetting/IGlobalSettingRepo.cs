using VotingAdmin.Web.Common.Paging;
using VotingAdmin.Web.Dtos;
using VotingAdmin.Web.Dtos.GlobalSetting;
using VotingAdmin.Web.Models.GlobalSetting;

namespace VotingAdmin.Web.Data.Repository.GlobalSetting
{
    public interface IGlobalSettingRepo
    {
        Task<BaseDgApiResponse<GlobalsettingDto>> GetGlobalSetting();
        Task<BaseDgApiResponse<GlobalSettingUpdate>> UpdateGlobalSetting(GlobalSettingUpdate globalSettingUpdate);
        Task<BaseDgApiResponse<PagedResponse<GlobalsettingDto>>> GetGlobalSettingHistory(GlobalSettingFilter globalSettingFilter);

    }
}
