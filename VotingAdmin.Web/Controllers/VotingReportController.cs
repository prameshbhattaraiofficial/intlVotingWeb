using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using VotingAdmin.Web.Common.Helpers;
using VotingAdmin.Web.Dtos.Reports;
using VotingAdmin.Web.Extensions;
using VotingAdmin.Web.Filter;
using VotingAdmin.Web.Helper;
using VotingAdmin.Web.Models.Reports;
using VotingAdmin.Web.Services.CommonDDl;
using VotingAdmin.Web.Services.Contest;
using VotingAdmin.Web.Services.Report;

namespace VotingAdmin.Web.Controllers
{
    public class VotingReportController : Controller
    {
        private readonly IVotingReportService _votingReport;
        private readonly IVotingContestService _votingContestService;
        private readonly ICommonddlServices _commonddlServices;
        private readonly IMapper _mapper;

        public VotingReportController(IVotingReportService votingReport,
            IVotingContestService votingContestService,
            ICommonddlServices commonddlServices,
            IMapper mapper)
        {
            _votingReport = votingReport;
            _votingContestService = votingContestService;
            _commonddlServices = commonddlServices;
            _mapper = mapper;
        }

        [Route("Voting-Report")]
        public async Task<IActionResult> Index(VotingReportRequestDto request)
        {
            var merchant = await _votingContestService.GetMerchantDdl();
            ViewBag.merchant = merchant.Data;

            var status = await _commonddlServices.ContestStatus();
            ViewBag.Conteststatuslist = status.Data;

            var contest = await _commonddlServices.GetContestDdl();
            ViewBag.Contestlist = contest.Data;

            var Subcontest = await _commonddlServices.GetSubContestDdl();
            ViewBag.SubContestlist = new SelectList(Subcontest.Data, "Id", "Text");
            
            var Paymentmethod = await _commonddlServices.PaymentMethodDdl();
            ViewBag.Paymentmethod = new SelectList(Paymentmethod.Data, "Value", "Text");



            var reportdetail = await _votingReport.GetTransectionReport(request);
            if (WebHelper.IsAjaxRequest(Request))
                return PartialView("_ReportList", reportdetail.Data);

            return View(reportdetail.Data);
        }

        #region export-Option

        [HttpGet("ExportReportToCsv")]
        public async Task<IActionResult> ExportReportToCsv([FromQuery] VotingReportRequestDto request)
        {
            //var request = new KycListRequest();
            request.Export = 1;
            var result = await _votingReport.GetTransectionReport(request);
            var data = result.Data.Items.Select(s => _mapper.Map<ReportList>(s));

            var (bytes, fileformate, filename) = ExportHelper.GenerateCsv(data, new string[] { }, null, "VotingReport", true);
            return File(bytes, fileformate, filename);
        }

        [HttpGet("ExportReportWithFilter")]
        public async Task<IActionResult> ExportReportWithFilter(VotingReportRequestDto request)
        {
            request.Export = 1;
            var result = await _votingReport.GetTransectionReport(request);
            var data = result.Data.Items.Select(s => _mapper.Map<ReportList>(s));
            List<DataTable> dataTables = await IEnumerableExtensions.ToDataTablesAsync<ReportList>(data, 500000);
            var (excelFileByteArr, fileFormat, fileName) = await ExportHelper.ToExcelAsync(dataTables, "VotingReportList", true);

            return File(excelFileByteArr, fileFormat, fileName);
        }


        [HttpGet("ExportReporttoPdf")]
        public async Task<FileContentResult> ExportReporttoPdf([FromQuery] VotingReportRequestDto request)
        {
            //return View();
            request.Export = 1;
            var result = await _votingReport.GetTransectionReport(request);
           
            var data = result.Data.Items.Select(s => _mapper.Map<ReportList>(s));

            //var(bytedata , format ) = await ExportHelper.TopdfAsync(data);
            // return File(bytedata , format );
            var (bytedata, format) = await ExportHelper.TopdfAsync(data, "Voting Transection Report");
            return File(bytedata, format, "report.pdf");

        }
        #endregion
    }
}
