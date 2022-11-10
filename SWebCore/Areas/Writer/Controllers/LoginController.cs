using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SWebCore.Areas.Writer.Models;

namespace SWebCore.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    public class LoginController : Controller
    {
        private readonly SignInManager<WriterUser> _singnInManager;

        public LoginController(SignInManager<WriterUser> singnInManager)
        {
            _singnInManager = singnInManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserLoginViewModel p)
        {
            
            if (ModelState.IsValid)
            {
                var result = await _singnInManager.PasswordSignInAsync(p.UserName, p.Password, true, true);
                if (result.Succeeded)
                {
                    
                    return RedirectToAction("Index","Writer","Default");


                    //return RedirectToAction("Index", "Default");
                }
                
                else 
                {
                    ModelState.AddModelError("", "Hatalı kullanıcı adı veya şifre");
                }
            }
            return View();
        }
        public async Task<IActionResult>LogOut()
        {
            await _singnInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}
