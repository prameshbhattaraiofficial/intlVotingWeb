using VotingAdmin.Web.Data.Repository.CommonDDL;
using VotingAdmin.Web.Dtos;
using VotingAdmin.Web.Dtos.CommonDDl;
using VotingAdmin.Web.Models.Ddls;

namespace VotingAdmin.Web.Services.CommonDDl
{
    public class CommonddlServices : ICommonddlServices
    {
        private readonly ICommonddlRepo _commonddlRepo;
        public CommonddlServices(ICommonddlRepo commonddlRepo)
        {
            _commonddlRepo = commonddlRepo;
        }

        public async Task<BaseDgApiResponse<List<ContestStatus>>> ContestStatus()
        {
            var status = await _commonddlRepo.ContestStatusAsync();
            return status;

        }
        public async Task<BaseDgApiResponse<List<ContestDetail>>> GetContestDdl(int statuscode)
        {
            var Contest = await _commonddlRepo.ContestAsync(statuscode);
            return Contest;
        }
        public async Task<BaseDgApiResponse<List<ContestStatus>>> GetSubContestDdl(long ContestId)
        {
            var subContest = await _commonddlRepo.SubContestAsync(ContestId);
            return subContest;
        }

        public async Task<BaseDgApiResponse<List<commonDdl>>> PaymentMethodDdl()
        {
            var PaymentMethod = await _commonddlRepo.PaymentMethodDdlAsync();
            return PaymentMethod;
        }

        public async Task<ChargeTypeList> GetAllChargeTypeList()
        {
            var result = await _commonddlRepo.GetAllChargeTypeList();
            return result;
        }

        public async Task<CountryList> GetAllCountry()
        {
            var countrylist = await _commonddlRepo.GetAllCountry();
            return countrylist;
        }
        public async Task<ContryCallingCode> GetAllContryCallingCode()
        {
            var countrylist = await _commonddlRepo.GetAllContryCallingCode();
            return countrylist;
        }


        public async Task<GenderList> GetAllGender()
        {
            var Genderlist = await _commonddlRepo.GetAllGender();
            return Genderlist;
        }

        public async Task<GenderList> GetAllMaritalStatus()
        {
            var MaritalStatuslist = await _commonddlRepo.GetAllMaritalStatus();
            return MaritalStatuslist;
        }

        public async Task<CountryList> GetAllNationality()
        {
            var Nationalitylist = await _commonddlRepo.GetAllNationality();
            return Nationalitylist;
        }

        public async Task<BaseDgApiResponse<List<ProvinceDdlModel>>> GetAllProvisionList(string CountryCode)
        {
            var ProvisionList = await _commonddlRepo.GetAllProvisionListAsync(CountryCode);
            return ProvisionList;
        }
        public async Task<BaseDgApiResponse<List<DistrictDdlModel>>> GetAllDistrictList(string ProvinceCode)
        {
            var ProvisionList = await _commonddlRepo.GetAllDistrictListAsync(ProvinceCode);
            return ProvisionList;
        }
        public async Task<BaseDgApiResponse<List<LocalBodyDdlModel>>> GetAlllocallevelList(string DistrictCode)
        {
            var ProvisionList = await _commonddlRepo.GetAlllocallevelAsync(DistrictCode);
            return ProvisionList;
        }
        public async Task<BaseDgApiResponse<List<IdentificationTypeDdlModel>>> GetIdentificationTypeList()
        {
            var IdType = await _commonddlRepo.GetIdentificationTypeListAsync();
            return IdType;
        }
        public async Task<BaseDgApiResponse<List<commonDdl>>> GetKycStatusTypeList()
        {
            var IdType = await _commonddlRepo.GetKycStatusTypeListAsync();
            return IdType;
        }

        public async Task<BaseDgApiResponse<List<commonDdl>>> GetServicetypeUseForDDl()
        {
            var servicetypeusefor = await _commonddlRepo.GetServicetypeUseForDDl();
            return servicetypeusefor;
        }

        public async Task<BaseDgApiResponse<List<commonDdl>>> GettxnServicetypeDDl()
        {
            var servicetype = await _commonddlRepo.GettxnServicetypeDDl();
            return servicetype;
        }

        public async Task<BaseDgApiResponse<List<commonDdl>>> GetfeeServicetypeDDl()
        {
            var servicetype = await _commonddlRepo.GetfeeServicetypeDDl();
            return servicetype;
        }

        public async Task<BaseDgApiResponse<List<commonDdl>>> GetloaninterestServicetypeDDl()
        {
            var servicetype = await _commonddlRepo.GetloaninterestServicetypeDDl();
            return servicetype;
        }

        public async Task<BaseDgApiResponse<List<commonDdl>>> GetProductBalanceTypetypeDDl()
        {
            var productbalancetype = await _commonddlRepo.GetProductBalanceTypetypeDDl();
            return productbalancetype;
        }

        public async Task<BaseDgApiResponse<List<commonDdl>>> GetAdminApprovalStatusDDl()
        {
            var adminapprovalstatus = await _commonddlRepo.GetAdminApprovalStatusDDl();
            return adminapprovalstatus;
        }
    }
}
