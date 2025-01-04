using AutoMapper;
using VotingAdmin.Web.Common.Paging;
using VotingAdmin.Web.Data.Repository.GlobalSetting;
using VotingAdmin.Web.Dtos;
using VotingAdmin.Web.Dtos.GlobalSetting;
using VotingAdmin.Web.Models.GlobalSetting;

namespace VotingAdmin.Web.Services.GlobalSetting
{
    public class GlobalSettingServices : IGlobalSettingServices
    {
        private readonly IGlobalSettingRepo _globalSettingRepo;
        private readonly IMapper _mapper;

        public GlobalSettingServices(IGlobalSettingRepo globalSettingRepo, IMapper mapper)
        {
            _globalSettingRepo = globalSettingRepo;
            _mapper = mapper;

        }
        public async Task<BaseDgApiResponse<GlobalsettingDto>> GetGlobalSetting()
        {
            var globalSetting = await _globalSettingRepo.GetGlobalSetting();
            return globalSetting;
        }

        public async Task<BaseDgApiResponse<PagedResponse<GlobalsettingDto>>> GetGlobalSettingHistory(GlobalSettingFilter globalSettingFilter)
        {
            var globalSetting = await _globalSettingRepo.GetGlobalSettingHistory(globalSettingFilter);
            return globalSetting;
        }

        public async Task<BaseDgApiResponse<GlobalSettingUpdate>> UpdateGlobalSetting(GlobalsettingDto globalsettingDto)
        {
            var data = _mapper.Map<GlobalSettingUpdate>(globalsettingDto);
            var globalSetting = await _globalSettingRepo.UpdateGlobalSetting(data);
            return globalSetting;
        }
    }
}
