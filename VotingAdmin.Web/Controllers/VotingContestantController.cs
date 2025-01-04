using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;
using VotingAdmin.Web.Common.Helpers;
using VotingAdmin.Web.Dtos.CommonDDl;
using VotingAdmin.Web.Dtos;
using VotingAdmin.Web.Dtos.contest;
using VotingAdmin.Web.Dtos.Contestant;
using VotingAdmin.Web.Filter;
using VotingAdmin.Web.Services.CommonDDl;
using VotingAdmin.Web.Services.Contestant;
using VotingAdmin.Web.Models.Contest;
using VotingAdmin.Web.Models.Contestant;

namespace VotingAdmin.Web.Controllers
{
    public class VotingContestantController : Controller
    {
        private readonly IContestantService _contestantService;
        private readonly ICommonddlServices _commonddlServices;
        private readonly INotyfService _notyfService;

        public VotingContestantController(IContestantService contestantService,
            ICommonddlServices commonddlServices
            , INotyfService notyfService)
        {
            _contestantService = contestantService;
            _commonddlServices = commonddlServices;
            _notyfService = notyfService;
        }

        [MenuAccess]
        [Route("Voting-Candidate")]
        public async Task<IActionResult> Index(ContestantRequestDto contestantRequest)
        {

            ViewBag.view = HttpContext.Items["view"];
            ViewBag.create = HttpContext.Items["create"];
            ViewBag.delete = HttpContext.Items["delet"];
            ViewBag.update = HttpContext.Items["update"];

            var contest = await _commonddlServices.GetContestDdl();
            ViewBag.Contestlist = contest.Data;
            var Subcontest = await _commonddlServices.GetSubContestDdl();
            ViewBag.SubContestlist = new SelectList(Subcontest.Data, "Id", "Text");

            var Contest = await _contestantService.GetContestantListAsync(contestantRequest);
            if (WebHelper.IsAjaxRequest(Request))
                return PartialView("_contestantList", Contest.Data);

            return View(Contest.Data);
        }
        [HttpGet("CreateContestant")]
        public async Task<IActionResult> CreateContestant()
        {
            var contest = await _commonddlServices.GetContestDdl();
            ViewBag.Contestlist = contest.Data;
            var Subcontest = await _commonddlServices.GetSubContestDdl();
            ViewBag.SubContestlist = new SelectList(Subcontest.Data, "Id", "Text");
            var Country = await _commonddlServices.GetAllCountry();
            ViewBag.countrylist = new SelectList(Country.Data, "Id", "Text");


            return PartialView();
        }
        [HttpPost("CreateContestant")]
        public async Task<IActionResult> CreateContestant(CreateContestantDto addContestantDto)
        {
            addContestantDto.GenderId = 1;
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return PartialView();
            }
            else
            {
                var Contest = await _contestantService.AddContestantAsync(addContestantDto);
                if (Contest.Success)
                {
                    _notyfService.Success(Contest.Message);
                    return Ok();
                }
                else
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    var contest = await _commonddlServices.GetContestDdl();
                    ViewBag.Contestlist = contest.Data;
                    var Subcontest = await _commonddlServices.GetSubContestDdl();
                    ViewBag.SubContestlist = new SelectList(Subcontest.Data, "Id", "Text");
                    //var Country = await _commonddlServices.GetAllCountry();
                    //ViewBag.countrylist = new SelectList(Country.Data, "Id", "Text");
                    ViewBag.Error = Contest.Errors.ToList();
                    return PartialView();
                }
            }
           

        }

        [HttpGet("UpdateContestant")]
        public async Task<IActionResult> UpdateContestant(long ContestantId)
        {
            var Contestant = await _contestantService.GetContestantByIdAsync(ContestantId);

            var contest = await _commonddlServices.GetContestDdl();
            ViewBag.Contestlist = new SelectList(contest.Data, "Id", "Text");
            var Subcontest = await _commonddlServices.GetSubContestDdl();
            ViewBag.SubContestlist = new SelectList(Subcontest.Data, "Id", "Text");
            //var Country = await _commonddlServices.GetAllCountry();
            //ViewBag.countrylist = new SelectList(Country.Data, "Id", "Text");
           
            if(Contestant.Data == null)
            {
                return PartialView();
            }

                var contestantdata = new UpdateContestantDto
            {
                ContestantId = Contestant.Data.ContestantId,
                ContestId = Contestant.Data.ContestId,
                SubContestId = Contestant.Data.SubContestId,
                ContestantName = Contestant.Data.ContestantName,
                ContestantNo = Contestant.Data.ContestantNumber,
                Description = Contestant.Data.Description,
                DateOfBirth = Contestant.Data.DateOfBirth,
                Age = Contestant.Data.Age,
                CountryCode = Contestant.Data.CountryCode,
                GenderId = Contestant.Data.GenderId,
                PhotoImagePath = Contestant.Data.PhotoImagePath,
                ContactNumber = Contestant.Data.ContactNumber,
                EmailAddress = Contestant.Data.EmailAddress,
                City = Contestant.Data.City,
                Address = Contestant.Data.Address,
                IsActive = Contestant.Data.isActive

            };
            return PartialView(contestantdata);
        }

        [HttpPost("UpdateContestant")]
        public async Task<IActionResult> UpdateContestant(UpdateContestantDto UpdateContestantDto)
        {
            //default value
            UpdateContestantDto.GenderId = 1;

            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return PartialView(UpdateContestantDto);
            }
            else
            {

                var Contest = await _contestantService.UpdateContestantAsync(UpdateContestantDto);
                if (Contest.Success)
                {
                    _notyfService.Success(Contest.Message);
                    return Ok();
                }
                else
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    ViewBag.Error = Contest.Errors;
                    var contest = await _commonddlServices.GetContestDdl();
                    ViewBag.Contestlist = new SelectList(contest.Data, "Id", "Text");
                    var Subcontest = await _commonddlServices.GetSubContestDdl();
                    ViewBag.SubContestlist = new SelectList(Subcontest.Data, "Id", "Text");
                    return PartialView(UpdateContestantDto);
                }
            }
           

        }

        [HttpGet("DeleteContestant")]
        public async Task<IActionResult> DeleteContestant(long ContestId,long SubContestId,long ContestantId)
        {
            var data = new DeleteContestant
            {
                ContestantId = ContestantId,
                ContestId = ContestId,
                SubContestId = SubContestId,

            };
            return PartialView(data);
        }
        [HttpPost("DeleteContestant")]
        public async Task<IActionResult> DeleteContestant(DeleteContestant Contestantdata)
        {
            var Contest = await _contestantService.DeleteContestantAsync(Contestantdata);
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




        [HttpGet("GetSubContest")]
        public async Task<JsonResult> GetSubContest(long ContestId)
        {
            var Subcontest = await _commonddlServices.GetSubContestDdl(ContestId);
            return Json(new SelectList(Subcontest.Data, "Id", "Text"));
        }
    }
}
