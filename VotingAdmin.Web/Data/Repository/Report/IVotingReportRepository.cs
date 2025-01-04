using VotingAdmin.Web.Common.Paging;
using VotingAdmin.Web.Dtos.Reports;
using VotingAdmin.Web.Dtos;
using VotingAdmin.Web.Models.Reports;

namespace VotingAdmin.Web.Data.Repository.Report
{
    public interface IVotingReportRepository
    {
        Task<BaseDgApiResponse<PagedResponse<VotingTransactinReport>>> GetTransectionReportAsync(VotingReportRequestDto request);
    }
}
