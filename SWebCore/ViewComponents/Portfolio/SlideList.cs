using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace SWebCore.ViewComponents.Portfolio
{
    public class SlideList :ViewComponent
    {
        PortfolioManager portfolioManager = new PortfolioManager(new EfPortfolioDal());
        public IViewComponentResult Invoke()
        {
            var values=portfolioManager.TGetList();
            return View(values);
        }
    }
}
