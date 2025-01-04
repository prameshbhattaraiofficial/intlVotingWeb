namespace VotingAdmin.Web.Services.FileServices
{
    public interface IFileService
    {
        public Tuple<int, string> SaveImage(IFormFile imageFile, string username);
        public bool DeleteImage(string imageFileName);
        string GetImagePath(string imageFileName);
    }
}
