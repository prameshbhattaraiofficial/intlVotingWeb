using VotingAdmin.Web.Dtos;
using VotingAdmin.Web.Dtos.CommonDDl;
using VotingAdmin.Web.Models.Ddls;
using VotingAdmin.Web.Services.Http.Voting;

namespace VotingAdmin.Web.Data.Repository.CommonDDL
{
    public class CommonddlRepo : ICommonddlRepo
    {
        private readonly IDgHttpClient _dgHttpClient;
        public CommonddlRepo(IDgHttpClient dgHttpClient)
        {
            _dgHttpClient = dgHttpClient;
        }

        public async Task<ChargeTypeList> GetAllChargeTypeList()
        {
            var (_, chargetypelist) = await _dgHttpClient.GetAsync<ChargeTypeList>(DgApiUris.GetAllChargeTypeUrl);
            return chargetypelist;
        }

        public async Task<CountryList> GetAllCountry()
        {
            var (_, CountryList) = await _dgHttpClient.GetAsync<CountryList>(DgApiUris.GetAllCountryddlUri);
            return CountryList;
        }
        public async Task<ContryCallingCode> GetAllContryCallingCode()
        {
            var (_, CountryList) = await _dgHttpClient.GetAsync<ContryCallingCode>(DgApiUris.GetAllContryCallingCodeUri);
            return CountryList;
        }


        public async Task<GenderList> GetAllGender()
        {
            var (_, GenderList) = await _dgHttpClient.GetAsync<GenderList>(DgApiUris.GetAllGenderddlUri);
            return GenderList;
        }

        public async Task<GenderList> GetAllMaritalStatus()
        {
            var (_, MaritalList) = await _dgHttpClient.GetAsync<GenderList>(DgApiUris.GetAllMaritalStatusddlUri);
            return MaritalList;
        }

        public async Task<CountryList> GetAllNationality()
        {
            var (_, NationalityList) = await _dgHttpClient.GetAsync<CountryList>(DgApiUris.GetAllNationalityddlUri);
            return NationalityList;
        }
        public async Task<BaseDgApiResponse<List<ProvinceDdlModel>>> GetAllProvisionListAsync(string CountryCode)
        {
            var (_, chargetypelist) = await _dgHttpClient.GetAsync<BaseDgApiResponse<List<ProvinceDdlModel>>>(DgApiUris.GetAllProvisionListUrl + "?countryCode=" + CountryCode);
            return chargetypelist;
        }
        public async Task<BaseDgApiResponse<List<DistrictDdlModel>>> GetAllDistrictListAsync(string ProvinceCode)
        {
            var (_, chargetypelist) = await _dgHttpClient.GetAsync<BaseDgApiResponse<List<DistrictDdlModel>>>(DgApiUris.GetAllDistrictListUrl + "?provinceCode=" + ProvinceCode);
            return chargetypelist;
        }
        public async Task<BaseDgApiResponse<List<LocalBodyDdlModel>>> GetAlllocallevelAsync(string DistrictCode)
        {
            var (_, chargetypelist) = await _dgHttpClient.GetAsync<BaseDgApiResponse<List<LocalBodyDdlModel>>>(DgApiUris.GetAllLoacllevalListUrl + "?districtCode=" + DistrictCode);
            return chargetypelist;
        }
        public async Task<BaseDgApiResponse<List<IdentificationTypeDdlModel>>> GetIdentificationTypeListAsync()
        {
            var (_, Idtypelist) = await _dgHttpClient.GetAsync<BaseDgApiResponse<List<IdentificationTypeDdlModel>>>(DgApiUris.GetAllIdTypeListUrl);
            return Idtypelist;
        }
        public async Task<BaseDgApiResponse<List<commonDdl>>> GetKycStatusTypeListAsync()
        {
            var (_, kycstatustypelist) = await _dgHttpClient.GetAsync<BaseDgApiResponse<List<commonDdl>>>(DgApiUris.GetAllKycstatusListUrl);
            return kycstatustypelist;
        }

        public async Task<BaseDgApiResponse<List<commonDdl>>> GetServicetypeUseForDDl()
        {
            var (_, servicetypeusefor) = await _dgHttpClient.GetAsync<BaseDgApiResponse<List<commonDdl>>>(DgApiUris.GettxnservicetypeuseforddlUrl);
            return servicetypeusefor;
        }

        public async Task<BaseDgApiResponse<List<commonDdl>>> GettxnServicetypeDDl()
        {
            var (_, servicetypeusefor) = await _dgHttpClient.GetAsync<BaseDgApiResponse<List<commonDdl>>>(DgApiUris.GettxnservicetypeddlUrl);
            return servicetypeusefor;
        }

        public async Task<BaseDgApiResponse<List<commonDdl>>> GetfeeServicetypeDDl()
        {
            var (_, servicetypeusefor) = await _dgHttpClient.GetAsync<BaseDgApiResponse<List<commonDdl>>>(DgApiUris.GetfeeservicetypeddlUrl);
            return servicetypeusefor;
        }

        public async Task<BaseDgApiResponse<List<commonDdl>>> GetloaninterestServicetypeDDl()
        {
            var (_, servicetypeusefor) = await _dgHttpClient.GetAsync<BaseDgApiResponse<List<commonDdl>>>(DgApiUris.GetloaninterestservicetypeddlUrl);
            return servicetypeusefor;
        }

        public async Task<BaseDgApiResponse<List<commonDdl>>> GetProductBalanceTypetypeDDl()
        {
            var (_, Productbalancetype) = await _dgHttpClient.GetAsync<BaseDgApiResponse<List<commonDdl>>>(DgApiUris.GetproductbalancetypeddlUrl);
            return Productbalancetype;
        }

        public async Task<BaseDgApiResponse<List<commonDdl>>> GetAdminApprovalStatusDDl()
        {
            var (_, Adminapprovalstatus) = await _dgHttpClient.GetAsync<BaseDgApiResponse<List<commonDdl>>>(DgApiUris.GetAdminApprovalStatusddl);
            return Adminapprovalstatus;
        }

        public async  Task<BaseDgApiResponse<List<ContestStatus>>> ContestStatusAsync()
        {
            var (_, status) = await _dgHttpClient.GetAsync<BaseDgApiResponse<List<ContestStatus>>>(DgApiUris.GetAllStatusUrl);
            return status;
        }
        public async Task<BaseDgApiResponse<List<ContestDetail>>> ContestAsync(int Statuscode)
        {
            var (_, Contest) = await _dgHttpClient.GetAsync<BaseDgApiResponse<List<ContestDetail>>>(DgApiUris.GetcontestUrl+ "?ContestStatus=" + Statuscode);
            return Contest;
        }
        public async Task<BaseDgApiResponse<List<ContestStatus>>> SubContestAsync(long ContestId)
        {
            var (_, SubContest) = await _dgHttpClient.GetAsync<BaseDgApiResponse<List<ContestStatus>>>(DgApiUris.GetSubContestUrl + "?ContestId=" + ContestId);
            return SubContest;
        }
        public async Task<BaseDgApiResponse<List<commonDdl>>> PaymentMethodDdlAsync()
        {
            var (_, paymentmethod) = await _dgHttpClient.GetAsync<BaseDgApiResponse<List<commonDdl>>>(DgApiUris.paymentddlurl);
            return paymentmethod;
        }

    }
}
