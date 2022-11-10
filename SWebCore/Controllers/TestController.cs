using Microsoft.AspNetCore.Mvc;

namespace SWebCore.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
