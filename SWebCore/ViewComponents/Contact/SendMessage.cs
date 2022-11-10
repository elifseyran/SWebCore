using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace SWebCore.ViewComponents.Contact
{
    public class SendMessage: ViewComponent
    {
        MessageManager messageManger = new MessageManager(new EfMessageDal());

        [HttpGet]
        public IViewComponentResult Invoke()
        {
            return View();
        }
        //[HttpGet]
        //public IViewComponentResult Invoke(Message p)
        //{
        //    p.Date=Convert.ToDateTime(DateTime.Now.ToShortDateString());
        //    p.Status = true;
        //    messageManger.TAdd(p);
        //    return View();
        //}
    }
}
