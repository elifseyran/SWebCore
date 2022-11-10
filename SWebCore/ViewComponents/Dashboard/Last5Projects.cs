using Microsoft.AspNetCore.Mvc;

namespace SWebCore.ViewComponents.Dashboard
{
    //son projeleri gösterir
    public class Last5Projects:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
