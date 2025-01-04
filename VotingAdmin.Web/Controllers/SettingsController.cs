using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using VotingAdmin.Web.Common.Helpers;
using VotingAdmin.Web.Dtos.GlobalSetting;
using VotingAdmin.Web.Extensions;
using VotingAdmin.Web.Helper;
using VotingAdmin.Web.Services.GlobalSetting;

namespace VotingAdmin.Web.Controllers
{
    [Authorize]
    public class SettingsController : Controller
    {
        private readonly IGlobalSettingServices _settingServices;
        private readonly IMapper _mapper;
        private readonly INotyfService _notyfService;
        public SettingsController(IGlobalSettingServices settingServices, IMapper mapper, INotyfService notyfService)
        {
            _settingServices = settingServices;
            _mapper = mapper;
            _notyfService = notyfService;
        }

        #region Globalsetting-Update
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _settingServices.GetGlobalSetting();
            // ViewBag.Error = result.Errors is not null ? result.Errors : null;
            return View(result.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(GlobalsettingDto settingUpdate)
        {
            if (!ModelState.IsValid)
            {
                _notyfService.Error("Failed to Updated Global Setting");
                return View(settingUpdate);
            }
            else
            {
                var result = await _settingServices.UpdateGlobalSetting(settingUpdate);
                if (result.Success)
                {
                    _notyfService.Success("Setting Updated Successfully!");
                    return RedirectToAction("Index");
                }
                else
                {
                    // Response.StatusCode = (int)HttpStatusCode.BadRequest;                  
                    ViewBag.Error = result.Message.ToString();
                    return View(settingUpdate);
                }
            }

        }

        #endregion

        #region SettingHistory-Details
        [HttpGet]
        public async Task<IActionResult> SettingHistory([FromQuery] GlobalSettingFilter globalSettingFilter)
        {
            var result = await _settingServices.GetGlobalSettingHistory(globalSettingFilter);
            if (WebHelper.IsAjaxRequest(Request))
                return PartialView("_Settinghistory", result.Data);

            return View(result.Data);
        }

        #endregion

        #region export-Option
        [HttpPost]
        public async Task<IActionResult> ExportsettingToExcel()
        {
            // Get data from database or wherever it's stored
            var result = await _settingServices.GetGlobalSettingHistory(new GlobalSettingFilter());
            var data = result.Data.Items;
            //   var htmlContent = JsonToHtml.RenderRazorViewToString(this, "_Settinghistory",result.Data);
            List<DataTable> dataTables = await data.ToDataTablesAsync(500000);
            var (excelFileByteArr, fileFormat, fileName) = await ExportHelper.ToExcelAsync(dataTables, "settinghistory", true);

            return File(excelFileByteArr, fileFormat, fileName);
        }


        public async Task<IActionResult> ExportsettingToCSV()
        {
            var result = await _settingServices.GetGlobalSettingHistory(new GlobalSettingFilter());
            var data = result.Data.Items;

            var (bytes, fileformate, filename) = ExportHelper.GenerateCsv(data, new string[] { }, null, "settinghistoryCsv", true);
            return File(bytes, fileformate, filename);
        }


        public async Task<IActionResult> PrintTable()
        {
            var result = await _settingServices.GetGlobalSettingHistory(new GlobalSettingFilter());
            var data = result.Data.Items;

            var htmlContent = JsonToHtml.RenderRazorViewToString(this, "_Settinghistory", result.Data);
            //using (MemoryStream pdfStream = new MemoryStream())
            //{
            //    HtmlToPdfConverter converter = new HtmlToPdfConverter();
            //    PdfDocument document = converter.Convert(htmlContent, baseUrl: "");
            //    PdfPage page = document.Pages.Add();
            //    PdfGraphics graphics = page.Graphics;
            //    PdfBitmap bmp = new PdfBitmap(pdfStream);
            //    graphics.DrawImage(bmp, PointF.Empty, new SizeF(page.GetClientSize().Width, page.GetClientSize().Height));
            //    document.Save(pdfStream);
            //    document.Close(true);

            //    byte[] bytes = pdfStream.ToArray();

            //    // Save the PDF file to disk
            //    File.WriteAllBytes(fileName, bytes);
            //}

            return View();
        }
        #endregion
    }
}
