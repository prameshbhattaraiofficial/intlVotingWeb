namespace VotingAdmin.Web.Dtos.Menus
{
    public class MenusByRoleList : BaseDgApiResponse<List<MenuByRole>>
    {
        public override List<MenuByRole> Data { get; set; }
    }
    public class MenuByRole
    {
        public int menuId { get; set; }
        public string title { get; set; }
        public int parentId { get; set; }
        public string menuUrl { get; set; }
        public int displayOrder { get; set; }
        public string imagePath { get; set; }
        public bool viewPer { get; set; }
        public bool createPer { get; set; }
        public bool updatePer { get; set; }
        public bool deletePer { get; set; }
    }

    public class MenuRoleWithchild
    {
        public int menuId { get; set; }
        public string title { get; set; }
        public int parentId { get; set; }
        public string menuUrl { get; set; }
        public int displayOrder { get; set; }
        public string imagePath { get; set; }
        public bool viewPer { get; set; }
        public bool createPer { get; set; }
        public bool updatePer { get; set; }
        public bool deletePer { get; set; }
        public List<MenuByRole> Child { get; set; }


    }
}
