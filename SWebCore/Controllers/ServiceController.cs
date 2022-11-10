using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace SWebCore.Controllers
{
    public class ServiceController : Controller
    {
        ServiceManager serviceManager = new ServiceManager(new EfServiceDal());
        private IHostingEnvironment _hostingEnvironment;

        public ServiceController(IHostingEnvironment hostingEnvironment) 
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            var values = serviceManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddService()
        {
            string[] filePathsRoot = Directory.GetFiles(Path.Combine(_hostingEnvironment.WebRootPath, "Template/images/services"));// servis klasör içindeki bütün resimleri göster
            List<string> filePaths = new();
            foreach (var item in filePathsRoot)
            {
                string path= PathSplit(item);
                path = PathReplace(path);
                filePaths.Add(path);
            }
            ViewBag.Images = filePaths;
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> AddService(Service service, [Bind("picture")]IFormFile picture)
        {
            string path = await AddAsync(picture);
            service.ImageUrl = path;
            serviceManager.TAdd(service);
            return RedirectToAction("Index");
        }


        [NonAction]
        public async Task<string> AddAsync(IFormFile file)
        {
            string filePath = null;


            if (file.Length > 0)
            {
                string[] permittedExtensions = { ".png", ".jpg" };

                var ext = System.IO.Path.GetExtension(file.FileName).ToLowerInvariant();

                if (ext != null || permittedExtensions.Contains(ext))
                {

                    Guid imageId = Guid.NewGuid(); //eşsiz bir anahtar
                    filePath = imageId + ext;

                    using (FileStream uploadStream = System.IO.File.Create($"wwwroot/images/{filePath}"))
                    {
                        await file.CopyToAsync(uploadStream);
                        await uploadStream.FlushAsync();
                        filePath = $"/images/{filePath}";
                    }
                }
            }
            return filePath;
        }

        [NonAction]
        public async Task RemoveAsync(string path)
        {
            string newPath = PathSplit(path);
            await Task.Run(() =>
            {
                if (System.IO.File.Exists(_hostingEnvironment.WebRootPath + "\\" + newPath))
                {
                    System.IO.File.Delete(_hostingEnvironment.WebRootPath + "\\" + newPath);
                }
            });
        }

        [NonAction]
        private string PathSplit(string path)
        {

            int index = path.IndexOf("wwwroot");
            string newPath = path.Substring(index + 8);
            return newPath;
        }

        [NonAction]
        private string PathReplace(string path)
        {
            return path.Replace(@"\", @"/");
        }












        public IActionResult DeleteService(int id)
        {
            var values = serviceManager.TGetByID(id);
            serviceManager.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditService(int id)
        {
            var values = serviceManager.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditService(Service service)
        {
            serviceManager.TUpdate(service);
            return RedirectToAction("Index");
        }
    }
}
