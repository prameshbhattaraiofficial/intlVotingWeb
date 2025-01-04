using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using VotingAdmin.Web.Common.Helpers;
using VotingAdmin.Web.Domain;
using VotingAdmin.Web.Dtos;
using VotingAdmin.Web.Dtos.Menus;
using VotingAdmin.Web.Dtos.Roles;
using VotingAdmin.Web.Filter;
using VotingAdmin.Web.Services.Menus;
using VotingAdmin.Web.Services.Roles;

namespace VotingAdmin.Web.Controllers
{
    [Authorize]
    [Route("Roles")]
    public class RolesController : Controller
    {
        private readonly IRoleServices _roleServices;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMenuManagerService _menuManagerService;
        private readonly INotyfService _notyfService;

        public RolesController(IRoleServices roleServices, IHttpContextAccessor httpContextAccessor,
            IMenuManagerService menuManagerService, INotyfService notyfService)
        {
            _roleServices = roleServices;
            _httpContextAccessor = httpContextAccessor;
            _menuManagerService = menuManagerService;
            _notyfService = notyfService;
        }

        #region RolesIndex
        [MenuAccess]
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.view = HttpContext.Items["view"];
            ViewBag.create = HttpContext.Items["create"];
            ViewBag.delete = HttpContext.Items["delet"];
            ViewBag.update = HttpContext.Items["update"];

            // ViewBag.ajax = ajaxcall;
            var result = await _roleServices.GetAllRole();

            if(result.Data == null)
            {
                return View("_UnAutherized");

            }

            if (WebHelper.IsAjaxRequest(Request))
                return PartialView("_RoleIndex", result);

            return View(result);
        }
        #endregion

        #region RolesCreate

        [HttpGet("Create")]
        public IActionResult Create()
        {
            ViewBag.Error = TempData["Error"] == null ? "" : TempData["Error"];
            return PartialView();
        }
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoleDto roleDto)
        {
            if (roleDto.roleName is not null)
            {
                var roledetails = await _roleServices.AddRole(roleDto);
                if (roledetails.Success)
                {
                    _notyfService.Success(roledetails.Message);
                    return Ok();
                }
                else
                {
                    _notyfService.Error(roledetails.Message);
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    ViewBag.Error = roledetails.Errors;
                    return PartialView();
                }
            }

            return RedirectToAction("Create");

        }

        #endregion

        #region RolesUpdate
        [HttpGet("Update")]
        public async Task<IActionResult> Update(int Id)
        {
            ViewBag.Error = TempData["Error"] == null ? "" : TempData["Error"];
            var roleDetails = await _roleServices.GetRoleById(Id);
            return PartialView(roleDetails.Data);
        }
        [HttpPost("Update")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(RoleDto roleDto)
        {
            if (roleDto.roleName is not null)
            {
                var roledetails = await _roleServices.UpdateRole(roleDto);
                if (roledetails.Success)
                {
                    _notyfService.Success(roledetails.Message);
                    //    return Json(new { isvalid = true, html = JsonToHtml.RenderRazorViewToString(this, "_RoleIndex", await _roleServices.GetAllRole()) });
                    return Ok();
                }
                else
                {
                    _notyfService.Error(roledetails.Message);
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    ViewBag.Error = roledetails.Errors;
                    return PartialView();
                }
            }
            return PartialView();
        }

        #endregion

        #region Roles Delete
        [HttpGet("Delete")]
        public async Task<IActionResult> Delete(int Id)
        {
            var roleDetails = await _roleServices.GetRoleById(Id);
            return PartialView(roleDetails.Data);
        }
        [HttpPost("DeleteAction")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAction(int id)
        {
            if (id != 0)
            {
                var roledetails = await _roleServices.DeleteRole(id);
                if (roledetails.Success)
                {
                    _notyfService.Success(roledetails.Message);
                    return Ok();
                }
                else
                {
                    _notyfService.Error(roledetails.Message);
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    ViewBag.Error = roledetails.Errors;
                    return PartialView("Delete");

                }
            }
            return PartialView("Delete");

        }

        #endregion

        #region Roles-Setting
        [HttpGet("Setting")]
        public async Task<IActionResult> Setting(int Id)
        {
            BaseDgApiResponse<RoleDto> roleDetails = await _roleServices.GetRoleById(Id);
            int roleId = roleDetails.Data.id;
            ViewBag.roleid = roleId;
            var menulist = await _menuManagerService.GetMenuByRoleId(roleId);
            var menuListwithchield = new List<MenuRoleWithchild>();
            foreach (var menu in menulist.Data)
            {
                if (menu.parentId == 0)
                {
                    var parentmenu = new MenuRoleWithchild()
                    {
                        Child = new List<MenuByRole>(),
                        menuId = menu.menuId,
                        title = menu.title,
                        parentId = menu.parentId,
                        menuUrl = menu.menuUrl,
                        displayOrder = menu.displayOrder,
                        imagePath = menu.imagePath,
                        viewPer = menu.viewPer,
                        createPer = menu.createPer,
                        updatePer = menu.updatePer,
                        deletePer = menu.deletePer,

                    };
                    foreach (var child in menulist.Data)
                    {
                        if (child.parentId == menu.menuId)
                        {
                            var childmenu = new MenuByRole()
                            {
                                menuId = child.menuId,
                                title = child.title,
                                parentId = child.parentId,
                                menuUrl = child.menuUrl,
                                displayOrder = child.displayOrder,
                                imagePath = child.imagePath,
                                viewPer = child.viewPer,
                                createPer = child.createPer,
                                updatePer = child.updatePer,
                                deletePer = child.deletePer,

                            };
                            parentmenu.Child.Add(childmenu);
                        }
                    }
                    menuListwithchield.Add(parentmenu);
                }
            }



            ViewBag.Viewall = menulist.Data.All(x => x.viewPer) == true ? "Checked" : "Unchecked";
            ViewBag.Createall = menulist.Data.All(x => x.createPer) == true ? "Checked" : "Unchecked";
            ViewBag.Editall = menulist.Data.All(x => x.updatePer) == true ? "Checked" : "Unchecked";
            ViewBag.Deleteall = menulist.Data.All(x => x.deletePer) == true ? "Checked" : "Unchecked";
            ViewBag.Username = _httpContextAccessor.HttpContext.User.FindFirst(UserClaimTypes.UserName)?.Value;
            ViewBag.Rolename = roleDetails.Data.roleName;
            return PartialView(menuListwithchield);
        }

        [HttpPost("Setting")]
        public async Task<IActionResult> Setting([FromBody] List<PermissionDto> permissions)
        {
            BaseDgApiResponse<RoleDto> roleDetails = await _roleServices.GetRoleById(permissions.FirstOrDefault().RoleId);
            ViewBag.roleid = roleDetails.Data.id;
            ViewBag.Username = _httpContextAccessor.HttpContext.User.FindFirst(UserClaimTypes.UserName)?.Value;
            ViewBag.Rolename = roleDetails.Data.roleName;
            MenusByRoleList menulist = await _menuManagerService.GetMenuByRoleId(permissions.FirstOrDefault().RoleId);
            List<MenuByRole> menuItems = new List<MenuByRole>();
            foreach (var item in permissions)
            {
                MenuByRole menuItem = menulist.Data.Where(x => x.menuId == item.menuid).FirstOrDefault();
                if (menuItem.viewPer != item.viewper ||
                  menuItem.createPer != item.Createper ||
                  menuItem.updatePer != item.Updateper ||
                  menuItem.deletePer != item.Deleteper)
                {
                    menuItem.viewPer = item.viewper;
                    menuItem.createPer = item.Createper;
                    menuItem.updatePer = item.Updateper;
                    menuItem.deletePer = item.Deleteper;
                    menuItems.Add(menuItem);
                }

            }
            if (menuItems.Count > 0)
            {
                var result = await _menuManagerService.UpdateMenuToRole(menuItems, Convert.ToInt32(roleDetails.Data.id));
                _notyfService.Success(result.Message);
                return Json(result.Success);
            }
            else
            {
                _notyfService.Warning("No Any Permission Changes");
                return Json(false);
            }
            // _notyfService.Error("Failed To Assign Permissions");
            //  return Json(false);

        }
        #endregion


        #region UpdateRoleStatus
        [HttpPost("UpdateRoleStatus")]
        public async Task<IActionResult> UpdateRoleStatus(string currstatus, string roleid, string rolename, string discription)
        {
            RoleDto roleDto = new RoleDto() { isActive = currstatus == "true" ? true : false, id = Convert.ToInt32(roleid), roleName = rolename, description = discription };
            var roledetails = await _roleServices.UpdateRole(roleDto);
            return PartialView();
        }
        #endregion
    }
}
