namespace VotingAdmin.Web.Dtos.CommonDDl
{
    public class ChargeTypeList : BaseDgApiResponse<List<ChargeType>>
    {
        public override List<ChargeType> Data { get; set; }
    }
    public class ChargeType
    {
        public int id { get; set; }
        public string text { get; set; }
        public string value { get; set; }

    }
}
