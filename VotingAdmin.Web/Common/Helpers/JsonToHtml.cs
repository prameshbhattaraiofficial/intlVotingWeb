using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace VotingAdmin.Web.Common.Helpers
{
    public class JsonToHtml
    {
        public static string RenderRazorViewToString(Controller controllers, string ViewName, object model = null)
        {
            controllers.ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                IViewEngine viewEngine = controllers.HttpContext.RequestServices.GetService(typeof(ICompositeViewEngine)) as ICompositeViewEngine;
                ViewEngineResult viewResult = viewEngine.FindView(controllers.ControllerContext, ViewName, false);

                ViewContext viewContext = new ViewContext(
                    controllers.ControllerContext,
                    viewResult.View,
                    controllers.ViewData,
                    controllers.TempData,
                    sw,
                    new HtmlHelperOptions()
                    );
                viewResult.View.RenderAsync(viewContext);
                if (!viewResult.Success)
                {
                    throw new InvalidOperationException($"Couldn't find view '{ViewName}'");
                }
                return sw.GetStringBuilder().ToString();
            }
        }

        public async static Task<string> RenderRazorViewAsString(Controller controller, string viewName, object model = null)
        {
            controller.ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                IViewEngine viewEngine = controller.HttpContext.RequestServices.GetService(typeof(ICompositeViewEngine)) as ICompositeViewEngine;
                ViewEngineResult viewResult = viewEngine.FindView(controller.ControllerContext, viewName, false);

                if (viewResult.View == null)
                {
                    throw new InvalidOperationException($"Couldn't find view '{viewName}'");
                }

                var viewContext = new ViewContext(
                    controller.ControllerContext,
                    viewResult.View,
                    controller.ViewData,
                    controller.TempData,
                    sw,
                    new HtmlHelperOptions()
                );

                viewResult.View.RenderAsync(viewContext).GetAwaiter().GetResult();

                return sw.GetStringBuilder().ToString();
            }
        }

    }
}
