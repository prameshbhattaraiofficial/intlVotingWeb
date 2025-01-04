using VotingAdmin.Web.Dtos;
using VotingAdmin.Web.Dtos.CommonDDl;
using VotingAdmin.Web.Models.Ddls;

namespace VotingAdmin.Web.Data.Repository.CommonDDL
{
    public interface ICommonddlRepo
    {
        Task<BaseDgApiResponse<List<ContestStatus>>> ContestStatusAsync();
        Task<BaseDgApiResponse<List<ContestDetail>>> ContestAsync(int statuscode);
        Task<BaseDgApiResponse<List<ContestStatus>>> SubContestAsync(long ContestId);
        Task<BaseDgApiResponse<List<commonDdl>>> PaymentMethodDdlAsync();
        Task<CountryList> GetAllCountry();
        Task<ContryCallingCode> GetAllContryCallingCode();
        Task<CountryList> GetAllNationality();
        Task<GenderList> GetAllGender();
        Task<GenderList> GetAllMaritalStatus();
        Task<ChargeTypeList> GetAllChargeTypeList();
        Task<BaseDgApiResponse<List<ProvinceDdlModel>>> GetAllProvisionListAsync(string CountryCode);
        Task<BaseDgApiResponse<List<DistrictDdlModel>>> GetAllDistrictListAsync(string ProvinceCode);
        Task<BaseDgApiResponse<List<LocalBodyDdlModel>>> GetAlllocallevelAsync(string DistrictCode);
        Task<BaseDgApiResponse<List<IdentificationTypeDdlModel>>> GetIdentificationTypeListAsync();
        Task<BaseDgApiResponse<List<commonDdl>>> GetKycStatusTypeListAsync();
        Task<BaseDgApiResponse<List<commonDdl>>> GetServicetypeUseForDDl();
        Task<BaseDgApiResponse<List<commonDdl>>> GettxnServicetypeDDl();
        Task<BaseDgApiResponse<List<commonDdl>>> GetfeeServicetypeDDl();
        Task<BaseDgApiResponse<List<commonDdl>>> GetloaninterestServicetypeDDl();
        Task<BaseDgApiResponse<List<commonDdl>>> GetProductBalanceTypetypeDDl();
        Task<BaseDgApiResponse<List<commonDdl>>> GetAdminApprovalStatusDDl();

    }
}
