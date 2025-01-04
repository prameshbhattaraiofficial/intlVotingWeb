namespace VotingAdmin.Web.Dtos
{
    public class BaseDgApiResponse<T>
    {
        public virtual bool Success { get; set; }
        public virtual string Message { get; set; }
        public virtual T Data { get; set; }
        public virtual List<string> Errors { get; set; }
    }
}
