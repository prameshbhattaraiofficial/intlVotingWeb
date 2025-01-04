namespace VotingAdmin.Web.Models.MenusTmp
{
    public class MenuItem
    {
        private List<MenuItem> _subMenus = new();
        private string _url = string.Empty;

        public string Title { get; set; }
        public string Icon { get; set; }
        public string Url { get => _url; set => _url = value ?? string.Empty; }
        public int Order { get; set; }
        public List<MenuItem> SubMenus { get => _subMenus; set => _subMenus = value ?? new(); }
    }
}
