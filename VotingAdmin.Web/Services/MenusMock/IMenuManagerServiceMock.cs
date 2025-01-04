using VotingAdmin.Web.Models.MenusTmp;

namespace VotingAdmin.Web.Services.MenusMock
{
    public interface IMenuManagerServiceMock
    {
        Task<List<MenuItem>> GetMenusAsync();
    }
}
