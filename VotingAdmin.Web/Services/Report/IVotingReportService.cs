using VotingAdmin.Web.Common.Paging;
using VotingAdmin.Web.Dtos;
using VotingAdmin.Web.Dtos.Reports;
using VotingAdmin.Web.Models.Reports;

namespace VotingAdmin.Web.Services.Report
{
    public interface IVotingReportService
    {
        Task<BaseDgApiResponse<PagedResponse<VotingTransactinReport>>> GetTransectionReport(VotingReportRequestDto request);
    }
}
