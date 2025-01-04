using VotingAdmin.Web.Common.Paging;

namespace VotingAdmin.Web.Dtos.contest
{
    public class ContestRequestDto : PagedRequest
    {
          public DateTime? FromDate {get;set;}
          public DateTime? ToDate {get;set;}
          public int Status {get;set;}
          public long ContestId {get;set;}
          public int Export { get; set; }

    }
}
