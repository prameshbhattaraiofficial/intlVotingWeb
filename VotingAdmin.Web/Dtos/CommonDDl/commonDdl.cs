namespace VotingAdmin.Web.Dtos.CommonDDl
{
    public class commonDdl
    {

        public int Id { get; set; }
        public string Text { get; set; }
        public string Value { get; set; }
    }

    public class CommonDdlModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Lookup { get; set; }
    }

    /////////////////////////////////////////////////////////////////////////////
    ///
    public class IdentificationTypeDdlModel : CommonDdlModel
    {
        public string IdentificationTypeCode { get; set; }
        public bool IsExpirable { get; set; }
    }
    public class DistrictDdlModel : commonDdl
    {
        public string ProvinceCode { get; set; }
    }
    public class ProvinceDdlModel : commonDdl
    {
        public string CountryCode { get; set; }
    }
    public class LocalBodyDdlModel : commonDdl
    {
        public string DistrictCode { get; set; }
        public string District { get; set; }
    }
    public class CountryDdlModel : commonDdl
    {
        public string CountryCode { get; set; }
        public string Nationality { get; set; }
    }

    public class NationalityDdlModel : commonDdl
    {
        public string CountryCode { get; set; }
        public string Country { get; set; }
    }

    public class LoanTypeDdlModel : CommonDdlModel
    {
        public string LoanTypeCode { get; set; }
    }
}

