using AutoMapper;
using Voting.Core.Models.Merchants;
using VotingAdmin.Web.Dtos.contest;
using VotingAdmin.Web.Dtos.Contestant;
using VotingAdmin.Web.Dtos.GlobalSetting;
using VotingAdmin.Web.Dtos.Menus;
using VotingAdmin.Web.Dtos.Merchants;
using VotingAdmin.Web.Dtos.Reports;
using VotingAdmin.Web.Models.Contest;
using VotingAdmin.Web.Models.Contestant;
using VotingAdmin.Web.Models.GlobalSetting;
using VotingAdmin.Web.Models.Reports;

namespace VotingAdmin.Web.Infrastructure.Mapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {


            CreateMap<GlobalSettingUpdate, GlobalsettingDto>().ReverseMap();
            CreateMap<UpdateContest, UpdateContestDto>().ReverseMap();
            CreateMap<UpdateSubContest, UpdateSubContestDto>().ReverseMap();
            CreateMap<UpdateContestant, UpdateContestantDto>().ReverseMap();
            CreateMap<UpdateMerchant, MerchantUpdate>().ReverseMap();
           
            CreateMap<ReportList, VotingTransactinReport>().ReverseMap();


            CreateMap<UpdateMenu, Menu>().ReverseMap();




        }
    }
}
