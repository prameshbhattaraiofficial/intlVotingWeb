using VotingAdmin.Web.Models.MenusTmp;

namespace VotingAdmin.Web.Services.MenusMock
{
    public class MenuManagerServiceMock : IMenuManagerServiceMock
    {
        public Task<List<MenuItem>> GetMenusAsync()
        {
            return Task.FromResult(new List<MenuItem>
            {
                new MenuItem
                {
                    Title = "Dashboard",
                    Icon = "fa-chart-line",
                    Order = 1,
                    Url = "/"
                },
                new MenuItem
                {
                    Title = "Reports",
                    Icon = "fa-file-lines",
                    Order = 2,
                    SubMenus = new List<MenuItem>
                    {
                        new MenuItem
                        {
                            Title = "Sales",
                            Icon = "file-text",
                            Order = 1,
                            Url = "/reports/sales"
                        },
                        new MenuItem
                        {
                            Title = "Purchase",
                            Icon = "dollar-sign",
                            Order = 1,
                            Url = "/reports/purchase"
                        },
                        new MenuItem
                        {
                            Title = "Expense",
                            Icon = "arrow-down-left",
                            Order = 1,
                            Url = "/reports/expense"
                        },
                        new MenuItem
                        {
                            Title = "Investment",
                            Icon = "arrow-down-left",
                            Order = 1,
                            Url = "/reports/investment"
                        },
                        new MenuItem
                        {
                            Title = "Settlement",
                            Icon = "dollar-sign",
                            Order = 1,
                            Url = "/reports/settlement"
                        }
                    }
                },
                new MenuItem
                {
                    Title = "Customers",
                    Icon = "fa-user-group",
                    Order = 1,
                    Url = "/customers"
                }
            });
        }
    }
}
