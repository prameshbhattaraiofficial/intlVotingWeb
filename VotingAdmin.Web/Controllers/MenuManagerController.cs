using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VotingAdmin.Web.Dtos.Menus;
using VotingAdmin.Web.Filter;
using VotingAdmin.Web.Services.Menus;

namespace VotingAdmin.Web.Controllers
{
    public class MenuManagerController : Controller
    {
        private readonly IMenuManagerService _menuManagerService;
        private readonly INotyfService _notyfService;
        private readonly IMapper _mapper;

        public MenuManagerController(IMenuManagerService menuManagerService,
            INotyfService notyfService,
            IMapper mapper)
        {
            _menuManagerService = menuManagerService;
            _notyfService = notyfService;
            _mapper = mapper;
        }
        [MenuAccess]
        [HttpGet("menu-manager")]
        public async Task<IActionResult> Index()
        {
            try
            {
                ViewBag.view = HttpContext.Items["view"];
                ViewBag.create = HttpContext.Items["create"];
                ViewBag.delete = HttpContext.Items["delet"];
                ViewBag.update = HttpContext.Items["update"];
                var menus = await _menuManagerService.GetMenusAllAsync();
                var Menuwithchield = new List<Menuwithchield>();
                foreach (var menu in menus)
                {
                    if (menu.ParentId == 0)
                    {
                        var Parentmenu = new Menuwithchield
                        {
                            child = new List<Menuwithchield>(),
                            Id = menu.Id,
                            ImagePath = menu.ImagePath,
                            ParentId = menu.ParentId,
                            Title = menu.Title,
                            MenuUrl = menu.MenuUrl,
                            IsActive = menu.IsActive,
                            DisplayOrder = menu.DisplayOrder
                        };

                        foreach (var child in menus)
                        {
                            if (child.ParentId == menu.Id && child.Id != menu.Id)
                            {
                                var childmenu = new Menuwithchield();
                                childmenu.Id = child.Id;
                                childmenu.ParentId = child.ParentId;
                                childmenu.ImagePath = child.ImagePath;
                                childmenu.Title = child.Title;
                                childmenu.MenuUrl = child.MenuUrl;
                                childmenu.IsActive = child.IsActive;
                                childmenu.DisplayOrder = child.DisplayOrder;
                                Parentmenu.child.Add(childmenu);
                            }
                        }
                        Menuwithchield.Add(Parentmenu);
                    }
                }


                return View(Menuwithchield);
            }
            catch
            {
                return View("_UnAutherized");
            }
        }

        [HttpGet("add-menu")]
        public IActionResult AddMenu()
        {
            return PartialView("AddMenu");
        }
        [HttpPost("addmenu")]
        public async Task<IActionResult> AddMenu2(AddMenu Addmenu)
        {

            var AddMenuresponse = await _menuManagerService.Addmenu(Addmenu);
            if (AddMenuresponse.Success)
            {
                _notyfService.Success("Menu was successfully Added.");
                return RedirectToAction("Index");

            }
            foreach (var item in AddMenuresponse.Errors)
            {
                _notyfService.Error(item);
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateMenu(int Id)
        {
            var menudata = await _menuManagerService.GetMenusByIdAsync(Id);
            if (menudata.Success)
            {
                var imagepathurl = menudata.Data.ImagePath;
                menudata.Data.ImagePath = null;
                var data = _mapper.Map<UpdateMenu>(menudata.Data);
                if (imagepathurl != null)
                {
                    data.ImagePathurl = imagepathurl.ToString();
                }
                return PartialView(data);
            }
            return PartialView("Error");

        }
        [HttpPost]
        public async Task<IActionResult> UpdateMenuAction(UpdateMenu menu)
        {
            if (menu.Id > 0)
            {
                var updateresponse = await _menuManagerService.Updatemenu(menu);
                if (updateresponse.Success)
                {
                    _notyfService.Success("Updated Succesfuly");
                    return RedirectToAction("Index");

                }
                foreach (var item in updateresponse.Errors)
                {
                    _notyfService.Error(item);
                }
                return RedirectToAction("Index");

            }
            _notyfService.Error("something went wrong");
            return RedirectToAction("Index");

        }
        [HttpPost]
        public async Task<bool> UpdateMenuIsactive(int Id, bool IsActive)
        {
            if (Id > 0)
            {
                var Menuupdate = new MenuUpdateIsactive
                {
                    Id = Id,
                    Isactive = IsActive
                };
                var response = await _menuManagerService.UpdateMenuIsactive(Menuupdate);
                if (response.Success)
                {
                    return true;
                }

            }
            return false;

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            return PartialView(id);

        }
        public async Task<IActionResult> DeleteAction(int Id)
        {
            if (Id > 0)
            {
                var menudata = await _menuManagerService.GetMenusByIdAsync(Id);
                if (menudata.Success)
                {
                    var deleted = await _menuManagerService.DeleteMenusByIdAsync(Id);
                    if (deleted.Success)
                    {
                        _notyfService.Warning(deleted.Message);
                        return RedirectToAction("Index");
                    }

                }

            }
            _notyfService.Error("Something went wrong");
            return RedirectToAction("Index");

        }

        public async void UpdateMenuDisplayOrder(int Id, int DisplayOrderValue)
        {
            if (Id > 0)
            {
                var UpdateOrder = new UpdateMenuDisplayOrder()
                {
                    Id = Id,
                    DisplayOrder = DisplayOrderValue
                };
                await _menuManagerService.UpdateMenuDisplayOrder(UpdateOrder);
            }

        }

    }
}
