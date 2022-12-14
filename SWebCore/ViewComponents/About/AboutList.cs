using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using SWebCore.Models;

namespace SWebCore.ViewComponents.About
{
    public class AboutList : ViewComponent
    {
        AboutManager aboutManager = new AboutManager(new EfAboutDal());
        public IViewComponentResult Invoke()
        {
            var values = aboutManager.TGetList().ToList().Select(x => new AboutVM
            {
                AboutID = x.AboutID,
                Address = x.Address,
                Age = x.Age,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                Mail = x.Mail,
                Phone = x.Phone,
                Title = x.Title
            }).ToList();

            return View(values);
        }
    }
}
