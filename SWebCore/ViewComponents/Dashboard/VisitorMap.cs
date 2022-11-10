using Microsoft.AspNetCore.Mvc;

namespace SWebCore.ViewComponents.Dashboard
{
    public class VisitorMap :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
