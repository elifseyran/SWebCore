using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace SWebCore.ViewComponents.Contact
{
    public class ContactDetails :ViewComponent
    {
        //private readonly IContactService _contactService;
        //public ContactDetails(IContactService contactService)
        //{
        //    _contactService = contactService;
        //}

        //public IViewComponentResult Invoke()
        //{
        //    var values = _contactService.TGetList();
        //    return View(values);
        //}

        ContactManager contactManager = new ContactManager(new EfContactDal());
        public IViewComponentResult Invoke()
        {
            var values = contactManager.TGetList();
            return View(values);  
        }
    }
}
