using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace SWebCore.Areas.Writer.ViewComponents.NotificationViewComponent
{

    public class NotificationViewComponent : ViewComponent

    {
        AnnouncementManager announcementManager = new AnnouncementManager(new EfAnnouncementDal());
        public IViewComponentResult Invoke()
        {
            var values =(announcementManager.TGetList().Take(5).ToList());
            return View(values);
        }
    }
}
