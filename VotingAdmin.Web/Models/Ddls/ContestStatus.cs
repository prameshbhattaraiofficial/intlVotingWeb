namespace VotingAdmin.Web.Models.Ddls
{
    public class ContestStatus
    {
        public long? Id { get; set; }
        public string Text { get; set; }
    }
    public class ContestDetail :ContestStatus
    {
        //public DateTime startDateTime { get; set; }
        //public DateTime endDateTime {get;set;}
    }
}
