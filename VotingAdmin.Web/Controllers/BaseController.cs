using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using VotingAdmin.Web.Common.Alerts.Types;
using VotingAdmin.Web.Domain;

namespace VotingAdmin.Web.Controllers
{
    [Route("[controller]")]
    public class BaseController : Controller
    {
        public void Notify(string message, string title, NotificationType notificationType = NotificationType.Success)
        {
            var msg = new
            {
                Message = message,
                Title = title,
                Icon = notificationType.ToString(),
                Type = notificationType.ToString(),
                Provider = GetProvider()
            };

            TempData["Message"] = JsonConvert.SerializeObject(msg);
        }

        private string GetProvider()
        {
            var config = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                            .AddEnvironmentVariables()
                            .Build();

            return config["NotificationProvider"];
        }

        protected string GetLoggedInUserUserName()
        {
            return User.FindFirst(UserClaimTypes.UserName)?.Value;
        }

        protected string GetLoggedInUserEmail()
        {
            return User.FindFirst(UserClaimTypes.Email)?.Value;
        }

        protected string GetLoggedInUserIsSuperAdmin()
        {
            return User.FindFirst(UserClaimTypes.IsSuperAdmin)?.Value;
        }

        protected string GetLoggedInUserRole()
        {
            return User.FindFirst(ClaimTypes.Role)?.Value;
        }

        protected string GetLoggedInUserExpireTime()
        {
            return User.FindFirst(UserClaimTypes.Exp)?.Value;
        }
    }
}
