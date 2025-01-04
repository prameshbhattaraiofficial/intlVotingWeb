using VotingAdmin.Web.Dtos;
using VotingAdmin.Web.Dtos.CommonDDl;
using VotingAdmin.Web.Models.Ddls;

namespace VotingAdmin.Web.Services.CommonDDl
{
    public interface ICommonddlServices
    {
        Task<BaseDgApiResponse<List<ContestStatus>>> ContestStatus();
        Task<BaseDgApiResponse<List<ContestDetail>>> GetContestDdl(int statuscode = 0);
        Task<BaseDgApiResponse<List<ContestStatus>>> GetSubContestDdl(long ContestId = 0);
        Task<BaseDgApiResponse<List<commonDdl>>> PaymentMethodDdl();

        Task<CountryList> GetAllCountry();
        Task<ContryCallingCode> GetAllContryCallingCode();
        Task<CountryList> GetAllNationality();
        Task<GenderList> GetAllGender();
        Task<GenderList> GetAllMaritalStatus();
        Task<ChargeTypeList> GetAllChargeTypeList();
        Task<BaseDgApiResponse<List<ProvinceDdlModel>>> GetAllProvisionList(string CountryCode);
        Task<BaseDgApiResponse<List<DistrictDdlModel>>> GetAllDistrictList(string ProvinceCode);
        Task<BaseDgApiResponse<List<LocalBodyDdlModel>>> GetAlllocallevelList(string DistrictCode);
        Task<BaseDgApiResponse<List<IdentificationTypeDdlModel>>> GetIdentificationTypeList();
        Task<BaseDgApiResponse<List<commonDdl>>> GetKycStatusTypeList();
        Task<BaseDgApiResponse<List<commonDdl>>> GetServicetypeUseForDDl();
        Task<BaseDgApiResponse<List<commonDdl>>> GettxnServicetypeDDl();
        Task<BaseDgApiResponse<List<commonDdl>>> GetfeeServicetypeDDl();
        Task<BaseDgApiResponse<List<commonDdl>>> GetloaninterestServicetypeDDl();
        Task<BaseDgApiResponse<List<commonDdl>>> GetProductBalanceTypetypeDDl();
        Task<BaseDgApiResponse<List<commonDdl>>> GetAdminApprovalStatusDDl();



    }
}
