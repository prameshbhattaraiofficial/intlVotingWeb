using VotingAdmin.Web.Common.Paging;
using VotingAdmin.Web.Data.Repository.Report;
using VotingAdmin.Web.Dtos;
using VotingAdmin.Web.Dtos.Reports;
using VotingAdmin.Web.Models.Reports;

namespace VotingAdmin.Web.Services.Report
{
    public class VotingReportService : IVotingReportService
    {
        private readonly IVotingReportRepository _votingReport;

        public VotingReportService(IVotingReportRepository votingReport)
        {
            _votingReport = votingReport;
        }

        public async Task<BaseDgApiResponse<PagedResponse<VotingTransactinReport>>> GetTransectionReport(VotingReportRequestDto request)
        {
            var result = await _votingReport.GetTransectionReportAsync(request);
            return result;
        }
    }
}
