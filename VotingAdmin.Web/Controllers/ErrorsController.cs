using Microsoft.AspNetCore.Mvc;

namespace VotingAdmin.Web.Controllers
{
    [Route("[controller]")]
    public class ErrorsController : Controller
    {

        //[HttpGet("{statusCode:int}")]
        //public IActionResult Error(int statusCode)
        //{
        //    return statusCode switch
        //    {
        //        400 => View("BadRequest"),
        //        403 => View("Forbidden"),
        //        404 => View("NotFound"),
        //        500 => View("InternalServerError"),
        //        _ => View("BadRequest")
        //    };
        //}

        [Route("Forbidden")]
        public IActionResult Forbidden()
        {
            return View("Forbidden");
        }
    }
}
