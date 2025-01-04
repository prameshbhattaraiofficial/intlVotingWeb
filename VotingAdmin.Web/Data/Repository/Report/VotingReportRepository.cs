using VotingAdmin.Web.Common.Paging;
using VotingAdmin.Web.Dtos;
using VotingAdmin.Web.Dtos.Reports;
using VotingAdmin.Web.Models.Reports;
using VotingAdmin.Web.Services.Http.Voting;

namespace VotingAdmin.Web.Data.Repository.Report
{
    public class VotingReportRepository : BaseRepository, IVotingReportRepository
    {
        private readonly IDgHttpClient _dgHttpClient;

        public VotingReportRepository(IDgHttpClient dgHttpClient)
        {
            _dgHttpClient = dgHttpClient;
        }
        public async Task<BaseDgApiResponse<PagedResponse<VotingTransactinReport>>> GetTransectionReportAsync(VotingReportRequestDto request)
        {
            var bodyContent = GetJsonStringContent(request);
            var (_, ReportList) = await _dgHttpClient.PostAsync<BaseDgApiResponse<PagedResponse<VotingTransactinReport>>>(DgApiUris.VotingReportListUrl, bodyContent);
            ReportList.Data.SortBy = request.SortBy;
            ReportList.Data.SortOrder = request.SortOrder;
            return ReportList;
        }
    }
}
