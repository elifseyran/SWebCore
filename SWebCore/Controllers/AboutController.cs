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
        public IActionResult Index(About about)
        {
            var values = aboutManager.TGetByID(5);
            return View(values);
        }

        [HttpPost]

        public async Task<IActionResult> Index(About about, [Bind("picture")] IFormFile picture)
        {
            if (about.Age is null)
            {
                
                ModelState.AddModelError("", "Lütfen girilen değerleri kontrol ediniz.");
                return View(about);
            }
            if (about.Age >= DateTime.Now)
            {
                ModelState.AddModelError("", "Lütfen girilen değerleri kontrol ediniz.");
                return View(about);
            }
            if (((DateTime.Now - about.Age).Value.Days / 365) > 150)
            {
                ModelState.AddModelError("", "Lütfen girilen değerleri kontrol ediniz.");
                return View(about);

            }


            if (ModelState.IsValid)
            {
                string path =about.ImageUrl;
            if(picture != null)
            {
                path = await AddAsync(picture);
            }
            about.ImageUrl = path;
            aboutManager.TUpdate(about);
          
          
                return RedirectToAction("Index", "About");
            }
            ModelState.AddModelError("", "Lütfen girilen değerleri kontrol ediniz.");
            return View(about);
            
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
    }
}
