using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace SWebCore.ViewComponents.Dashboard
{
    public class StatisticsDashboard2:ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = c.Portfolios.Count(); //ana sayfanın orta kısmı
            ViewBag.v2 = c.Messages.Count();
            ViewBag.v3 = c.Services.Count();
            return View();
        }
    }
}
