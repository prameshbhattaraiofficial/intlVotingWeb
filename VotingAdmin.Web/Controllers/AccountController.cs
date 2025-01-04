using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Voting.Api.Features.Auth.Policies;
using VotingAdmin.Web.Common.Alerts.Types;
using VotingAdmin.Web.Dtos.Auth;
using VotingAdmin.Web.Extensions;
using VotingAdmin.Web.Models.Users;
using VotingAdmin.Web.Services;
using VotingAdmin.Web.Services.Users;

namespace VotingAdmin.Web.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAuthService _authService;
        private readonly IUsersServices _usersServices;
        private readonly INotyfService _notyfService;

        public AccountController(IAuthService authService,
            IUsersServices usersServices,
            INotyfService notyfService)
        {
            _authService = authService;
            _usersServices = usersServices;
            _notyfService = notyfService;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("merchantLogin")]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("merchantLogin")]
        public async Task<IActionResult> Login(MerchantLoginRequest loginRequestDto)
        {
            try
            {
                var authResult = await _authService.MerchantLoginWithPasswordAsync(loginRequestDto);

                if (!authResult.Success)
                {
                    TempData["invalid"] = authResult.Errors.Count > 0 ? authResult.Errors[0].ToString() : "Invalid credentials!";
                    return RedirectToAction("Login", "Account");
                }

                return RedirectToAction("index", "Home");

            }
            catch (Exception)
            {
                Notify("Login Failed!", "Sorry!", notificationType: NotificationType.Error);
                return RedirectToAction("Login", "Account");
            }
        }
        //[Authorize(Policy = UserPolicies.VotingMerchant)]
        [HttpGet("MerchantChangePassword")]
        public IActionResult MerchantChangePassword()
        {
            //ViewBag.error = TempData["changepassword"] == null ? "" : TempData["changepassword"];
            return PartialView();
        }
        [HttpPost("MerchantChangePassword")]

        public async Task<IActionResult> MerchantChangePassword(ChangePassword changePassword)
        {
            var reset = await _usersServices.MerchantChangePassword(changePassword);
            if (reset.Success)
            {
                _notyfService.Success(reset.Message);
                return Ok();

            }
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            ViewBag.error = reset.Errors;
            return PartialView();
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("userLogin")]
        public IActionResult UserLogin()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("userLogin")]
        public async Task<IActionResult> UserLogin(UserLoginRequest loginRequestDto)
        {
            try
            {
                var authResult = await _authService.UserLoginWithPasswordAsync(loginRequestDto);

                if (!authResult.Success)
                {
                    TempData["invalid"] = authResult.Errors.Count > 0 ? authResult.Errors[0].ToString() : "Invalid credentials!";
                    return RedirectToAction("UserLogin", "Account");
                }

                return RedirectToAction("Index", "Home");

            }
            catch (Exception)
            {
                Notify("Login Failed!", "Sorry!", notificationType: NotificationType.Error);
                return RedirectToAction("UserLogin", "Account");
            }
        }

        //[Authorize(Policy = UserPolicies.VotingMerchant)]
        [HttpGet("UserChangePassword")]
        public IActionResult UserChangePassword()
        {
            //ViewBag.error = TempData["changepassword"] == null ? "" : TempData["changepassword"];
            return PartialView();
        }
        [HttpPost("UserChangePassword")]

        public async Task<IActionResult> UserChangePassword(ChangePassword changePassword)
        {
            var reset = await _usersServices.UserChangePassword(changePassword);
            if (reset.Success)
            {
                _notyfService.Success(reset.Message);
                return Ok();

            }
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            ViewBag.error = reset.Errors;
            return PartialView();
        }


        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            try
            {
                foreach (var cookie in Request.Cookies.Keys)
                    Response.Cookies.Delete(cookie);

                var redirectionResult = RedirectToAction("login");
                if (!_authService.IsUserAuthenticated())
                    return redirectionResult;

                redirectionResult = User.IsMerchant()
                    ? RedirectToAction("login")
                    : RedirectToAction("UserLogin");

                await HttpContext.SignOutAsync();

                return redirectionResult;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
