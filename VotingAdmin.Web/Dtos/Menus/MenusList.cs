namespace VotingAdmin.Web.Dtos.Menus
{
    public class MenusList : BaseDgApiResponse<List<MenuItem>>
    {
        public override List<MenuItem> Data { get; set; }
    }

    public class MenuItem
    {
        public int MenuId { get; set; }
        public string Title { get; set; }
        public int ParentId { get; set; }
        public string MenuUrl { get; set; }
        public int DisplayOrder { get; set; }
        public string ImagePath { get; set; }
        public bool ViewPer { get; set; }
        public bool CreatePer { get; set; }
        public bool UpdatePer { get; set; }
        public bool DeletePer { get; set; }
        public List<MenuItem> SubMenus { get; set; }
    }
}
