using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;
using VotingAdmin.Web.Common.Helpers;
using VotingAdmin.Web.Dtos;
using VotingAdmin.Web.Dtos.ResetPassword;
using VotingAdmin.Web.Dtos.Roles;
using VotingAdmin.Web.Dtos.Users.UserDetails;
using VotingAdmin.Web.Filter;
using VotingAdmin.Web.Models.Roles;
using VotingAdmin.Web.Models.Users;
using VotingAdmin.Web.Services.CommonDDl;
using VotingAdmin.Web.Services.Roles;
using VotingAdmin.Web.Services.Users;

namespace VotingAdmin.Web.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly IUsersServices _usersservices;
        private readonly ICommonddlServices _commonddlServices;
        private readonly IRoleServices _roleServices;
        private readonly INotyfService _notyfService;
        private readonly IMapper _mapper;

        public UsersController(IUsersServices usersservices,
          ICommonddlServices commonddlServices, IRoleServices roleServices, INotyfService notyfService, IMapper mapper)
        {
            _usersservices = usersservices;
            _commonddlServices = commonddlServices;
            _roleServices = roleServices;
            _notyfService = notyfService;
            _mapper = mapper;
        }

        #region user-Index
        [MenuAccess]
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] UserListRequest request)
        {
            ViewBag.view = HttpContext.Items["view"];
            ViewBag.create = HttpContext.Items["create"];
            ViewBag.delete = HttpContext.Items["delet"];
            ViewBag.update = HttpContext.Items["update"];
            
            try
            {
                var userList = await _usersservices.GetAllUsersAsync(request);
                if (WebHelper.IsAjaxRequest(Request))
                    return PartialView("_UserList", userList.Data);

                return View(userList.Data);
            }
            catch 
            {
                return View("_UnAutherized");
            }

          
           
        }

        //[HttpPost]
        //public async Task<IActionResult> Index([FromBody] UserListRequest request, bool ajaxcall = false)
        //{

        //    ViewBag.ajax = ajaxcall;
        //    var userlist = await _usersservices.GetAllUsersAsync(request);
        //    var Pager = new Pagination(userlist.Data.FilteredCount, userlist.Data.PageNumber, userlist.Data.PageSize);
        //    Pager.SearchName = request.SearchVal;
        //    ViewBag.pager = Pager;
        //    ViewBag.request = request;


        //    return View(userlist.Data);
        //}
        #endregion

        #region user-Details
        [HttpGet]
        public async Task<IActionResult> Details(int Id)
        {
            var user = await _usersservices.GetUserById(Id);
            return PartialView(user.Data);
        }
        [HttpGet]
        public async Task<IActionResult> DetailsByUsername(string name)
        {
            var filter = new UserListRequest { UserName = name };
            var userList = await _usersservices.GetAllUsersAsync(filter);
            return PartialView("Details", userList.Data.Items.FirstOrDefault());
        }

        #endregion

        #region user-Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var genderdetails = await _commonddlServices.GetAllGender();
            ViewBag.Gender = new SelectList(genderdetails.Data, "id", "lookup", "1");
            ViewBag.Error = TempData["Error"] == null ? "" : TempData["Error"];
            if (TempData["Error"] is not null)
            {
                return PartialView();
            }
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] UserDetails userDetails)
        {
            var genderdetails = await _commonddlServices.GetAllGender();
            ViewBag.Gender = new SelectList(genderdetails.Data, "id", "lookup", "Male");
            // ViewBag.Error = TempData["Error"] == null ? "" : TempData["Error"];

            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return PartialView();
            }

            var user = await _usersservices.AddUsers(userDetails);
            if (!user.Success)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                ViewBag.Error = user.Errors;
                return PartialView();
            }
            _notyfService.Success(user.Message);
            return Ok();
        }


        #endregion

        #region user-Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var user = await _usersservices.GetUserById(id);
            var model = new UpdateUserDetailsDto()
            {
                fullName = user.Data.FullName,
                ProfileImage = user.Data.ProfileImage,
                gender = user.Data.Gender,
                dateOfBirth = user.Data.DateOfBirth,
                dateOfJoining = user.Data.DateOfJoining,
                address = user.Data.Address,
                isActive = user.Data.IsActive
            };
            ViewBag.Error = TempData["Error"] == null ? "" : TempData["Error"];
            var genderdetails = await _commonddlServices.GetAllGender();
            ViewBag.Gender = new SelectList(genderdetails.Data, "id", "lookup");
            return PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromForm] UpdateUserDetailsDto userDetails)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return PartialView();
            }
            else
            {
                var user = await _usersservices.EditUsers(userDetails);
                if (user.Success)
                {
                    _notyfService.Success(user.Message);
                    return Ok();
                }
                else
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    ViewBag.Error = user.Errors;
                    return PartialView();
                }

            }


        }

        #endregion


        #region user-Delete
        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            var user = await _usersservices.GetUserById(Id);
            var userDto = new UpdateUserDetailsDto { id = user.Data.Id };

            return PartialView(userDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([FromForm] UpdateUserDetailsDto UserDetailsDto)
        {
            if (UserDetailsDto.id != 0)
            {
                var user = await _usersservices.DeleteUsers(UserDetailsDto.id);
                if (user.Success)
                {
                    _notyfService.Success(user.Message);
                    return Ok();
                }
                else
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    ViewBag.Error = user.Errors;
                }


            }
            return PartialView();
        }
        #endregion

        #region user-AssignUserToRole

        [HttpGet]
        public async Task<IActionResult> AssignUserToRole(int id)
        {
            ViewBag.Error = id is 0 ? "Id cann't be Zero" : "";
            BaseDgApiResponse<UserDetails> user = await _usersservices.GetUserById(id);
            ViewBag.Email = user.Data.Email;
            ViewBag.UserName = user.Data.UserName;
            ViewBag.UserId = user.Data.Id;
            var roleList = await _roleServices.GetAllRole();
            BaseDgApiResponse<UsersRoleResponse> UserRoleById = await _usersservices.GetUserRole(id);
            AssignUserRoleDto roleDto = new AssignUserRoleDto();
            if (UserRoleById.Data.userRoles.Count > 0)
            {
                roleDto.roleid = new int[UserRoleById.Data.userRoles.Count];
                int i = 0;
                foreach (var item in UserRoleById.Data.userRoles)
                {
                    roleDto.roleid[i] = item.roleId;
                    i++;
                }
            }

            var allRoles = new List<Role>();
            allRoles.AddRange(UserRoleById.Data.availableRoles);
            allRoles.AddRange(UserRoleById.Data.userRoles);

            ViewBag.Roles = new SelectList(allRoles, "roleId", "roleName");
            ViewBag.Error = TempData["Error"] == null ? "" : TempData["Error"];
            return PartialView(roleDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignUserToRole([FromForm] AssignUserRoleDto AssignuserroleDto)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return PartialView();
            }
            else
            {
                var result = await _usersservices.AssignUserRole(AssignuserroleDto.user_id, AssignuserroleDto.roleid);
                if (result.Success)
                {
                    _notyfService.Success(result.Message);
                    return Ok();

                }
                else
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    ViewBag.Error = result.Errors;
                    return PartialView();
                }
            }

        }
        #endregion

        #region user-ResetPassword
        [HttpGet]
        public async Task<IActionResult> ResetPassword(int Id)
        {
            BaseDgApiResponse<UserDetails> user = await _usersservices.GetUserById(Id);
            if (!user.Success)
            {
                ViewBag.Error = user.Errors;
            }
            ResetPasswordDto resetPassword = new ResetPasswordDto() { userId = user.Data.Id };
            //ViewBag.Error = TempData["Error"] == null ? "" : TempData["Error"];
            return PartialView(resetPassword);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword([FromForm] ResetPasswordDto resetPassword)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return PartialView();
            }
            else
            {
                var reset = await _usersservices.ResetUserPassword(resetPassword);
                if (reset.Success)
                {
                    _notyfService.Success(reset.Message);
                    return Ok();
                }
                else
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    ViewBag.Error = reset.Errors;
                    return PartialView();
                }
            }


        }


        [HttpGet]
        public IActionResult ChangePassword()
        {
            ViewBag.error = TempData["changepassword"] == null ? "" : TempData["changepassword"];
            return PartialView();
        }
        [HttpPost]

        public async Task<IActionResult> ChangePassword([FromForm] ChangePassword changePassword)
        {
            var reset = await _usersservices.ChangePassword(changePassword);
            if (reset.Success)
            {
                _notyfService.Success(reset.Message);
                return Ok();

            }
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            ViewBag.error = reset.Errors;
            return PartialView();
        }

        #endregion

        #region ChangeAccessCode
        [HttpGet]
        public IActionResult ResetAccessCode()
        {
            //ViewBag.Error = TempData["Error"] == null ? "" : TempData["Error"];
            return PartialView();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetAccessCode([FromForm] ChangeAccessCode ResetAccessCode)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return PartialView();
            }
            else
            {
                var reset = await _usersservices.ChangeAccessCodeAsync(ResetAccessCode);
                if (reset.Success)
                {
                    _notyfService.Success(reset.Message);
                    return Ok();
                }
                else
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    ViewBag.Error = reset.Errors;
                    return PartialView();
                }
            }


        }
        #endregion
    }
}
