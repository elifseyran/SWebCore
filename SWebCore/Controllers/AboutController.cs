using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;


namespace SWebCore.Controllers
{
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EfAboutDal());
        [HttpGet]
        public IActionResult Index()
        {
            var values = aboutManager.TGetByID(1);
            return View(values);
        }

        [HttpPost]

        public async Task<IActionResult> Index(About about, [Bind("picture")] IFormFile picture)
        {
            string path = await AddAsync(picture);
            about.ImageUrl = path;
            aboutManager.TUpdate(about);
            return RedirectToAction("Index", "About");
        }

        [NonAction]
        public async Task<string> AddAsync(IFormFile file)
        {
            string filePath = null;

            
            if (file.Length > 0 )
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
    }
}
