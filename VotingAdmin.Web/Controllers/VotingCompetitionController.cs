using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;
using VotingAdmin.Web.Common.Helpers;
using VotingAdmin.Web.Dtos.contest;
using VotingAdmin.Web.Dtos.Roles;
using VotingAdmin.Web.Filter;
using VotingAdmin.Web.Models.Contest;
using VotingAdmin.Web.Services.CommonDDl;
using VotingAdmin.Web.Services.Contest;

namespace VotingAdmin.Web.Controllers
{
    public class VotingCompetitionController : Controller
    {
        private readonly IVotingContestService _votingContestService;
        private readonly ICommonddlServices _commonddlServices;
        private readonly INotyfService _notyfService;

        public VotingCompetitionController(IVotingContestService votingContestService
            , ICommonddlServices commonddlServices
            , INotyfService notyfService
            )
        {
            _votingContestService = votingContestService;
            _commonddlServices = commonddlServices;
            _notyfService = notyfService;
        }

        [MenuAccess]
        [Route("Voting-Competition")]
        public async Task<IActionResult> Index(ContestRequestDto contestRequest)
        {
            ViewBag.view = HttpContext.Items["view"];
            ViewBag.create = HttpContext.Items["create"];
            ViewBag.delete = HttpContext.Items["delet"];
            ViewBag.update = HttpContext.Items["update"];

            var status = await _commonddlServices.ContestStatus();
            ViewBag.Conteststatuslist  = new SelectList(status.Data, "Id", "Text");
          
            var Contest = await _votingContestService.GetContestListAsync(contestRequest);
            if (WebHelper.IsAjaxRequest(Request))
                return PartialView("_contestList", Contest.Data);

            return View(Contest.Data);
        }
        #region Create
        [HttpGet("CreateContest")]
        public async Task<IActionResult> CreateContest()
        {
            var merchant = await _votingContestService.GetMerchantDdl();
            ViewBag.merchant = new SelectList(merchant.Data, "Value", "Text");
            return PartialView();
        }
        [HttpPost("CreateContest")]
        public async Task<IActionResult> CreateContest(AddContestDto addContestDto)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                var merchant = await _votingContestService.GetMerchantDdl();
                ViewBag.merchant = new SelectList(merchant.Data, "Value", "Text");
                return PartialView(addContestDto);
            }
            else
            {
              
             if (addContestDto.SubContests[0].SubContestName == null)
              {
                  addContestDto.SubContests[0].SubContestName = addContestDto.ContestName;
                  addContestDto.SubContests[0].SubContestDesc = addContestDto.ContestDesc;
                  addContestDto.SubContests[0].BannerImg = addContestDto.BannerImg;
                  addContestDto.SubContests[0].SliderImg = addContestDto.SliderImg;
              }

                var Contest = await _votingContestService.AddContestAsync(addContestDto);
                if (Contest.Success)
                {
                    _notyfService.Success(Contest.Message);
                    return Ok();
                }
                else
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    ViewBag.Error = Contest.Errors;
                    var merchant = await _votingContestService.GetMerchantDdl();
                    ViewBag.merchant = new SelectList(merchant.Data, "Value", "Text");
                    return PartialView(addContestDto);
                }
            }

        }

        [HttpGet("CreateSubContest")]
        public async Task<IActionResult> CreateSubContest()
        {
            var contest = await _commonddlServices.GetContestDdl();
            ViewBag.Contestlist = new SelectList(contest.Data, "Id", "Text");

            return PartialView();
        }
        [HttpPost("CreateSubContest")]
        public async Task<IActionResult> CreateSubContest(AddSubContest addContestDto)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                var contest = await _commonddlServices.GetContestDdl();
                ViewBag.Contestlist = new SelectList(contest.Data, "Id", "Text");
                return PartialView(addContestDto);
            }
            else
            {
                //if (addContestDto.SubContestDtos[1].SubContestName == null)
                //{
                //    addContestDto.SubContestDtos[1] = null;

                //}
                var Contest = await _votingContestService.AddSubContestAsync(addContestDto);
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
                    return PartialView(addContestDto);
                }
            }

        }
        #endregion

        [HttpGet("UpdateContest")]
        public async Task<IActionResult> UpdateContest(long ContestId)
        {
            var merchant = await _votingContestService.GetMerchantDdl();
            ViewBag.merchant = new SelectList(merchant.Data, "Value", "Text");

            var Contest = await _votingContestService.GetContestByIdAsync(ContestId);
            var contestdata = new UpdateContestDto { 
                ContestId = Contest.Data.ContestId,
                ContestName = Contest.Data.ContestName,
                ContestDesc = Contest.Data.ContestDesc,
                EndDateTime = Contest.Data.EndDateTime,
                StartDateTime = Contest.Data.StartDateTime,
                PricePerVote = Contest.Data.PricePerVote,
                PriorityOrder = Contest.Data.PriorityOrder,
                BannerImgPath = Contest.Data.BannerImgPath,
                IsActive = Contest.Data.ContestIsActive

            };
            return PartialView( contestdata);
        }

        [HttpPost("UpdateContest")]
        public async Task<IActionResult> UpdateContest(UpdateContestDto UpdateContestDto)
        {
            if (!ModelState.IsValid)
            {
                var merchant = await _votingContestService.GetMerchantDdl();
                ViewBag.merchant = new SelectList(merchant.Data, "Value", "Text");
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return PartialView(UpdateContestDto);
            }
            else
            {
                var Contest = await _votingContestService.UpdateContestAsync(UpdateContestDto);
                if (Contest.Success)
                {
                    _notyfService.Success(Contest.Message);
                    return Ok();
                }
                else
                {
                    var merchant = await _votingContestService.GetMerchantDdl();
                    ViewBag.merchant = new SelectList(merchant.Data, "Value", "Text");
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    ViewBag.Error = Contest.Errors;
                    return PartialView(UpdateContestDto);
                }
            }

        }

        [HttpGet("UpdateSubContest")]
        public async Task<IActionResult> UpdateSubContest(long SubContestId)
        {
            var Contest = await _votingContestService.GetSubContestByIdAsync(SubContestId);

            var contestdata = new UpdateSubContestDto
            {
                ContestId = Contest.Data.ContestId,
                SubContestId = Contest.Data.SubContestId,
                SubContestName = Contest.Data.SubContestName,
                SubContestDesc = Contest.Data.SubContestDesc,
                BannerImgPath = Contest.Data.BannerImgPath,
                IsActive = Contest.Data.IsActive

            };
            return PartialView(contestdata);
        }

        [HttpPost("UpdateSubContest")]
        public async Task<IActionResult> UpdateSubContest(UpdateSubContestDto UpdateSubContestDto)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return PartialView(UpdateSubContestDto);
            }
            else
            {
                var Contest = await _votingContestService.UpdateSubContestAsync(UpdateSubContestDto);
                if (Contest.Success)
                {
                    _notyfService.Success(Contest.Message);
                    return Ok();
                }
                else
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    ViewBag.Error = Contest.Errors;
                    return PartialView(UpdateSubContestDto);
                }
            }

        }

        [HttpGet("DeleteContest")]
        public async Task<IActionResult> DeleteContest(long ContestId)
        {
            var data = new DeleteContest
            {
                ContestId = ContestId
            };
            return PartialView(data);
        }
        [HttpPost("DeleteContest")]
        public async Task<IActionResult> DeleteContest(DeleteContest Contestdata)
        {
            var Contest = await _votingContestService.DeleteContestAsync(Contestdata.ContestId);
            if (Contest.Success)
            {
                _notyfService.Success(Contest.Message);
                return Ok();
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                ViewBag.Error = Contest.Errors;
                return PartialView(Contestdata);
               
            }

            
        }

        [HttpGet("PublishContest")]
        public async Task<IActionResult> PublishContest(long ContestId)
        {
            var data = new DeleteContest
            {
                ContestId = ContestId
            };
            return PartialView(data);
        }
        [HttpPost("PublishContest")]
        public async Task<IActionResult> PublishContest(DeleteContest Contestdata)
        {
            var Contest = await _votingContestService.PublishContestAsync(Contestdata.ContestId);
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

         [HttpGet("UnPublishContest")]
        public async Task<IActionResult> UnPublishContest(long ContestId)
        {
            var data = new DeleteContest
            {
                ContestId = ContestId
            };
            return PartialView(data);
        }
        [HttpPost("UnPublishContest")]
        public async Task<IActionResult> UnPublishContest(DeleteContest Contestdata)
        {
            var Contest = await _votingContestService.UnPublishContestAsync(Contestdata.ContestId);
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

        [HttpGet("DeleteSubContest")]
        public async Task<IActionResult> DeleteSubContest(long ContestId,long SubContestId)
        {
            var data = new DeleteSubContestRequest
            {
                ContestId = ContestId,
                SubContestId = SubContestId

            };
            return PartialView(data);
        }
        [HttpPost("DeleteSubContest")]
        public async Task<IActionResult> DeleteSubContest(DeleteSubContestRequest SubContestdata)
        {
            var Contest = await _votingContestService.DeleteSubContestAsync(SubContestdata.ContestId, SubContestdata.SubContestId);
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


        [MenuAccess]
        [Route("Voting-SubCompetition")]
        public async Task<IActionResult> SubCompitation(ContestRequestDto contestRequest)
        {
            ViewBag.view = HttpContext.Items["view"];
            ViewBag.create = HttpContext.Items["create"];
            ViewBag.delete = HttpContext.Items["delet"];
            ViewBag.update = HttpContext.Items["update"];

            ViewBag.requesteddata = contestRequest;

            var status = await _commonddlServices.ContestStatus();
            ViewBag.Conteststatuslist = new SelectList(status.Data, "Id", "Text");

            var contest = await _commonddlServices.GetContestDdl();
            ViewBag.Contestlist = new SelectList(contest.Data, "Id", "Text" );

            var Contest = await _votingContestService.GetContestDetailListAsync(contestRequest);
            if (WebHelper.IsAjaxRequest(Request))
                return PartialView("_SubCompitationList", Contest.Data);

            return View("_subContextIndex", Contest.Data);
        }
    }
}
