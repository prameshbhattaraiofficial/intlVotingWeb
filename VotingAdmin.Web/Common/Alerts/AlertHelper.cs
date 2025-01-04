using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace VotingAdmin.Web.Common.Alerts
{
    public class AlertHelper
    {
        public static void SetMessage(Controller controller, string message, MessageType messageType = MessageType.Success)
        {
            var alert = new Alert
            {
                Message = message,
                MessageType = messageType
            };

            controller.TempData["loginMessage"] = JsonConvert.SerializeObject(alert);
        }
    }
}
