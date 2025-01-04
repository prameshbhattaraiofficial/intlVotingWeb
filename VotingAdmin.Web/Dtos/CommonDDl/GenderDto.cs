namespace VotingAdmin.Web.Dtos.CommonDDl
{
    public class GenderList : BaseDgApiResponse<List<GenderDto>>
    {
        public override List<GenderDto> Data { get; set; }
    }
    public class GenderDto
    {
        public int id { get; set; }
        public string text { get; set; }
        public string lookup { get; set; }
    }
}
