namespace VotingAdmin.Web.Dtos.CommonDDl
{
    public class CountryList : BaseDgApiResponse<List<CountryDto>>
    {
        public override List<CountryDto> Data { get; set; }
    }
    public class ContryCallingCode : BaseDgApiResponse<List<ContryCalling>>
    {
        public override List<ContryCalling> Data { get; set; }
    }

    public class ContryCalling
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Value { get; set; }
    }
    public class CountryDto
    {
        public int id { get; set; }
        public string countryCode { get; set; }
        public string country { get; set; }
        public string text { get; set; }
        public string value { get; set; }
    }
}
