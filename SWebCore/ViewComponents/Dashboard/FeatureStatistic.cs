using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace SWebCore.ViewComponents.Dashboard
{
    public class FeatureStatistic :ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = c.Skills.Count();//Skill deki değerleri sayar
            ViewBag.v2=c.Messages.Where(x=>x.Status==false).Count();  //okunmamış mesaj sayısı
            ViewBag.v3=c.Messages.Where(x => x.Status == true).Count();
            ViewBag.v1 = c.Experiences.Count();//Çalıştığım firma yada iş sayısı
            return View();
        }
    }
}
