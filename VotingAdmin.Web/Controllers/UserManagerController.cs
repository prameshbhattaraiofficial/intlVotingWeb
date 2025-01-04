using Microsoft.AspNetCore.Mvc;

namespace VotingAdmin.Web.Controllers
{
    public class UserManagerController : Controller
    {
        [Route("user-manager")]
        public IActionResult Index(bool ajaxcall = false)
        {
            ViewBag.ajax = ajaxcall;
            return View();
        }
    }
}
