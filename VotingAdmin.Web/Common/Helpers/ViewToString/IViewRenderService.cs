namespace VotingAdmin.Web.Common.Helpers.ViewToString
{
    public interface IViewRenderService
    {
        Task<string> RenderToStringAsync(string viewName, object model);
    }
}
