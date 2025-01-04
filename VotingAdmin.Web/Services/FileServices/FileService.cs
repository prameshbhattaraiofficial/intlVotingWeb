namespace VotingAdmin.Web.Services.FileServices
{
    public class FileService : IFileService
    {
        private IWebHostEnvironment _environment;
        private IHttpContextAccessor _httpContextAccessor;
        public FileService(IWebHostEnvironment environment, IHttpContextAccessor httpContextAccessor)
        {
            _environment = environment;
            _httpContextAccessor = httpContextAccessor;
        }
        public bool DeleteImage(string imageFileName)
        {
            try
            {
                var wwwPath = _environment.WebRootPath;
                var path = Path.Combine(wwwPath, "Uploads\\", imageFileName);
                if (File.Exists(path))
                {
                    File.Delete(path);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return ex is not null ? true : false;
            }
        }
        public string GetImagePath(string imageFileName)
        {
            try
            {
                var wwwPath = _environment.WebRootPath;
                var path = Path.Combine(wwwPath, "Uploads\\", imageFileName);
                if (File.Exists(path))
                {

                    return path;
                }
                return null;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public Tuple<int, string> SaveImage(IFormFile imageFile, string username)
        {
            try
            {
                var contentPath = _environment.ContentRootPath;
                // path = "c://projects/productminiapi/uploads" ,not exactly something like that
                var path = Path.Combine(contentPath, "Uploads");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                // Check the allowed extenstions
                var ext = Path.GetExtension(imageFile.FileName);
                var allowedExtensions = new string[] { ".jpg", ".png", ".jpeg" };
                if (!allowedExtensions.Contains(ext))
                {
                    string msg = string.Format("Only {0} extensions are allowed", string.Join(",", allowedExtensions));
                    return new Tuple<int, string>(0, msg);
                }
                var currentclaims = _httpContextAccessor.HttpContext?.User;
                string uniqueString = username;
                // we are trying to create a unique filename here
                var newFileName = uniqueString + ext;
                var fileWithPath = Path.Combine(path, newFileName);
                var stream = new FileStream(fileWithPath, FileMode.Create);
                imageFile.CopyTo(stream);
                stream.Close();
                return new Tuple<int, string>(1, newFileName);
            }
            catch (Exception ex)
            {
                return new Tuple<int, string>(0, "Error has occured");
            }
        }
    }
}
