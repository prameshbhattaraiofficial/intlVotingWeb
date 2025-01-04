using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO.Packaging;
using System.Net;
using VotingAdmin.Web.Common.Helpers;
using VotingAdmin.Web.Dtos.contest;
using VotingAdmin.Web.Dtos.Contestant;
using VotingAdmin.Web.Dtos.ContestPackages;
using VotingAdmin.Web.Filter;
using VotingAdmin.Web.Models.Contest;
using VotingAdmin.Web.Services.CommonDDl;
using VotingAdmin.Web.Services.Package;

namespace VotingAdmin.Web.Controllers
{
    public class VotingPackageController : Controller
    {
        private readonly IPackageService _packageService;
        private readonly INotyfService _notyfService;
        private readonly ICommonddlServices _commonddlServices;

        public VotingPackageController(IPackageService packageService,
            INotyfService notyfService,
            ICommonddlServices commonddlServices)
        {
            _packageService = packageService;
            _notyfService = notyfService;
            _commonddlServices = commonddlServices;
        }

        [MenuAccess]
        [Route("Voting-Package")]
        public async Task<IActionResult> Index(PackageRequestDto PackageRequest)
        {
            ViewBag.view = HttpContext.Items["view"];
            ViewBag.create = HttpContext.Items["create"];
            ViewBag.delete = HttpContext.Items["delet"];
            ViewBag.update = HttpContext.Items["update"];


            var status = await _commonddlServices.ContestStatus();
            ViewBag.Conteststatuslist = new SelectList(status.Data, "Id", "Text");

            var contest = await _commonddlServices.GetContestDdl();
            ViewBag.Contestlist = contest.Data;

            var Subcontest = await _commonddlServices.GetSubContestDdl();
            ViewBag.SubContestlist = new SelectList(Subcontest.Data, "Id", "Text");



            var packageList = await _packageService.GetPackageListAsync(PackageRequest);

            if (WebHelper.IsAjaxRequest(Request))
                return PartialView("_PackageList", packageList.Data);

            return View(packageList.Data);
        }

        [HttpGet("CreatePackage")]
        public async Task<IActionResult> CreatePackage()
        {
            int runningAndSedule = 4;
            var contest = await _commonddlServices.GetContestDdl(runningAndSedule);
            ViewBag.Contestlist = contest.Data;
            var Subcontest = await _commonddlServices.GetSubContestDdl();
            ViewBag.SubContestlist = new SelectList(Subcontest.Data, "Id", "Text");
           
            return PartialView();
        }
        [HttpPost("CreatePackage")]
        public async Task<IActionResult> CreatePackage(AddPackageDto addPackageDto)
        {
            int runningAndSedule = 4;
            if (!ModelState.IsValid)
            {
               
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                var contest = await _commonddlServices.GetContestDdl(runningAndSedule);
                ViewBag.Contestlist = contest.Data;
                var Subcontest = await _commonddlServices.GetSubContestDdl(addPackageDto.ContestId);
                ViewBag.SubContestlist = new SelectList(Subcontest.Data, "Id", "Text");
                return PartialView(addPackageDto);
            }
            else
            {
                var Contest = await _packageService.AddPackageAsync(addPackageDto);
                if (Contest.Success)
                {
                    _notyfService.Success(Contest.Message);
                    return Ok();
                }
                else
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    ViewBag.Error = Contest.Message;
                    var contest = await _commonddlServices.GetContestDdl(runningAndSedule);
                    ViewBag.Contestlist = contest.Data;
                    return PartialView(addPackageDto);
                }
            }

        }

        [HttpGet("DeletePackage")]
        public async Task<IActionResult> DeletePackage(long PackageId,long ContestId,long SubContestId)
        {
            var data = new DeletePackageDto
            {
                PackageId = PackageId,
                ContestId = ContestId,
                SubContestId = SubContestId

            };
            return PartialView(data);
        }
        [HttpPost("DeletePackage")]
        public async Task<IActionResult> DeletePackage(DeletePackageDto Packagedata)
        {
            var Contest = await _packageService.DeletePackageAsync(Packagedata.PackageId, Packagedata.ContestId, Packagedata.SubContestId);
            if (Contest.Success)
            {
                _notyfService.Success(Contest.Message);
                return Ok();
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                ViewBag.Error = Contest.Errors;
                return PartialView();

            }


        }

        [HttpGet("UpdatePackage")]
        public async Task<IActionResult> UpdatePackage(long PackageId)
        {
            var package = await _packageService.GetPackageByIdAsync(PackageId);
            if (package == null)
            {
                return View("Error");
            }
            var Packagedata = new UpdatePackageDto
            {
                PackageId = package.Data.PackageId,
                ContestId = package.Data.ContestId,
                SubContestId = package.Data.SubContestId,
                Description = package.Data.Description,
                MaxVote = package.Data.MaxVote,
                MinVote = package.Data.MinVote,
                PricePerVote = package.Data.PricePerVote,
                PackageName = package.Data.PackageName,
                IsActive = package.Data.IsActive,
                IsPaid = package.Data.IsPaid,

            };
            return PartialView(Packagedata);
        }

        [HttpPost("UpdatePackage")]
        public async Task<IActionResult> UpdateContest(UpdatePackageDto UpdatePackageDto)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return PartialView(UpdatePackageDto);
            }
            else
            {
                var Package = await _packageService.UpdatePackageAsync(UpdatePackageDto);
                if (Package.Success)
                {
                    _notyfService.Success(Package.Message);
                    return Ok();
                }
                else
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    ViewBag.Error = Package.Errors;
                    return PartialView(UpdatePackageDto);
                }
            }

        }
    }
}
