using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SWebCore.Controllers
{
    public class PortfolioController : Controller
    {
        PortfolioManager portfolioManager = new PortfolioManager(new EfPortfolioDal());

        public IActionResult Index()
        {
            var values = portfolioManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddPortfolio()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddPortfolio(Portfolio p, [Bind("picture")] IFormFile picture)
        {
             string path = await AddAsync(picture);
                p.ImageUrl = path;  
            if (path==null)
            {
                ModelState.AddModelError("", "Resim Alanı Boş Geçilemez.");
                return View(p);
            }
            PortfolioValidator validations = new PortfolioValidator();
            ValidationResult results = validations.Validate(p);
            if (results.IsValid) //results geerli ise sen çalış
            {
               
                portfolioManager.TAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(p);
        }
        [NonAction]
        public async Task<string> AddAsync(IFormFile file)
        {
            string filePath = null;

            if (file==null)
            {
                return null;
            }
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
                else { ModelState.AddModelError("item.ImageuRL", "This is not a valid date"); }
            }
            return filePath;
        }

        public IActionResult DeletePortfolio(int id)
        {
            var values = portfolioManager.TGetByID(id);
            portfolioManager.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditPortfolio(int id)
        {
            var values = portfolioManager.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditPortfolio(Portfolio portfolio)
        {
            PortfolioValidator validations = new PortfolioValidator();
            ValidationResult results = validations.Validate(portfolio);
            if (results.IsValid)
            {
                portfolioManager.TUpdate(portfolio);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
