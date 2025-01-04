using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Net;
using Voting.Api.Features.Auth.Policies;
using Voting.Core.Models.Merchants;
using VotingAdmin.Web.Common.Helpers;
using VotingAdmin.Web.Dtos;
using VotingAdmin.Web.Dtos.Contestant;
using VotingAdmin.Web.Dtos.Merchants;
using VotingAdmin.Web.Dtos.ResetPassword;
using VotingAdmin.Web.Dtos.Users.UserDetails;
using VotingAdmin.Web.Models.Merchants;
using VotingAdmin.Web.Models.Users;
using VotingAdmin.Web.Services.CommonDDl;
using VotingAdmin.Web.Services.Merchants;
using VotingAdmin.Web.Services.Users;

namespace VotingAdmin.Web.Controllers
{
    //[Route("[controller]")]
    [Authorize(Policy = UserPolicies.VotingUser)]
    public class MerchantsController : Controller
    {
        private readonly ICommonddlServices _commonddlServices;
        private readonly INotyfService _notyfService;
        private readonly IMerchantsService _merchantsService;
        private readonly IMapper _mapper;
        private readonly IUsersServices _usersServices;

        public MerchantsController(
            ICommonddlServices commonddlServices,
            INotyfService notyfService,
            IMerchantsService merchantsService,
            IMapper mapper,
            IUsersServices usersServices)
        {
            _commonddlServices = commonddlServices;
            _notyfService = notyfService;
            _merchantsService = merchantsService;
            _mapper = mapper;
            _usersServices = usersServices;
        }

        [Route("merchants")]
        public async Task<IActionResult> Index(MerchantListRequest request)
        {
            try
            {
                var response = await _merchantsService.GetMerchantsAsync(request);

                if (WebHelper.IsAjaxRequest(Request))
                    return PartialView("_MerchantList", response.Data);

                return View(response);
            }
            catch
            {
                return View("_UnAutherized");
            }
            
        }

        [HttpGet("AddMerchant")]
        public async Task<IActionResult> AddMerchant()
        {
            var genderdetails = await _commonddlServices.GetAllGender();
            ViewBag.Gender = new SelectList(genderdetails.Data, "id", "lookup", "Male");

           return PartialView("_AddMerchant");
        }

        [HttpPost("AddMerchant")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> AddMerchant(MerchantAdd request)
        {
            
            if (!ModelState.IsValid)
            {
                var genderdetails = await _commonddlServices.GetAllGender();
                ViewBag.Gender = new SelectList(genderdetails.Data, "id", "lookup", "Male");

                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return PartialView("_AddMerchant");
            }

            var response = await _merchantsService.AddMerchantAsync(request);

            if (!response.Success)
            {
                var genderdetails = await _commonddlServices.GetAllGender();
                ViewBag.Gender = new SelectList(genderdetails.Data, "id", "lookup", "Male");

                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                ViewBag.Error = response.Errors;
                return PartialView("_AddMerchant");
            }

            _notyfService.Success(response.Message);
            return RedirectToAction("Index");
        }

        [HttpGet("UpdateMerchant")]
        public async Task<IActionResult> UpdateMerchant([Required(ErrorMessage = "MerchantId is required")] string merchantId)
        {
            var genderdetails = await _commonddlServices.GetAllGender();
            ViewBag.Gender = new SelectList(genderdetails.Data, "id", "lookup", "Male");

            var merchantdetails = await _merchantsService.GetMerchantByMerchantIdAsync(merchantId);
            var merchantdetail = merchantdetails.Data;
            var merchant = new UpdateMerchant();

            if (merchantdetail != null)
            {
                merchant.Id = merchantdetail.Id;
                merchant.UserName = merchantdetail.UserName;
                merchant.FullName = merchantdetail.FullName;
                merchant.Email = merchantdetail.Email;
                merchant.Mobile = merchantdetail.Mobile;
                merchant.Address = merchantdetail.Address;
                merchant.GenderId = 1;
                merchant.Department = merchantdetail.Department;
                merchant.DateOfBirth = merchantdetail.DateOfBirth;
                merchant.DateOfJoining = merchantdetail.DateOfJoining;
                merchant.ProfileImagePath = merchantdetail.ProfileImagePath;
                merchant.MerchantId = merchantId;
                merchant.PANNumber = merchantdetail.PANNumber;
                merchant.OrganizationName = merchantdetail.OrganizationName;
                merchant.RegistrationNumber = merchantdetail.RegistrationNumber;
                merchant.DirectorName = merchantdetail.DirectorName;
                merchant.PANDocumentPath = merchantdetail.PANDocumentPath;
                merchant.IsActive = merchantdetail.IsActive;

            }

            return await Task.FromResult(PartialView("_UpdateMerchant", merchant));
        }

        [HttpPost("UpdateMerchant")]
        public async Task<IActionResult> UpdateMerchant(UpdateMerchant request)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                var genderdetails = await _commonddlServices.GetAllGender();
                ViewBag.Gender = new SelectList(genderdetails.Data, "id", "lookup", "Male");
                return PartialView("_UpdateMerchant", request);
            }
            else
            {
                var data = _mapper.Map<MerchantUpdate>(request);
                var Contest = await _merchantsService.UpdateMerchantAsync(data);
                if (Contest.Success)
                {
                    _notyfService.Success(Contest.Message);
                    return Ok();
                }
                else
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    ViewBag.Error = Contest.Errors;
                    var genderdetails = await _commonddlServices.GetAllGender();
                    ViewBag.Gender = new SelectList(genderdetails.Data, "id", "lookup", "Male");
                    return PartialView("_UpdateMerchant", request);
                }
            }
        }

        [HttpGet("ResetPassword")]
        public async Task<IActionResult> ResetPassword(int UserId)
        {
            BaseDgApiResponse<UserDetails> user = await _usersServices.GetUserById(UserId);
            if (!user.Success)
            {
                ViewBag.Error = user.Errors;
            }
            ResetPasswordDto resetPassword = new ResetPasswordDto() { userId = user.Data.Id };
            //ViewBag.Error = TempData["Error"] == null ? "" : TempData["Error"];
            return PartialView(resetPassword);
        }


        [HttpPost("ResetPassword")]
       
        public async Task<IActionResult> ResetPassword([FromForm] ResetPasswordDto resetPassword)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return PartialView();
            }
            else
            {
                var reset = await _usersServices.ResetUserPassword(resetPassword);
                if (reset.Success)
                {
                    _notyfService.Success(reset.Message);
                    return Ok();
                }
                else
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    ViewBag.Error = reset.Errors.ToString();
                    return PartialView();
                }
            }


        }
       

        [HttpGet("MerchantDetail")]
        public async Task<IActionResult> MerchantDetail([Required(ErrorMessage = "MerchantId is required")] string merchantId)
        {
            var detail = await _merchantsService.GetMerchantByMerchantIdAsync(merchantId);

            if (detail?.Data is null)
                return NotFound();

            return PartialView("_MerchantDetail", detail.Data);
        }
    }
}
