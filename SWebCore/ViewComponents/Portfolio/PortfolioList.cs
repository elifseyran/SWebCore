using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Concrete;

namespace SWebCore.ViewComponents.Portfolio
{
    public class PortfolioList:ViewComponent
    {
        PortfolioManager portfolioManger = new PortfolioManager (new EfPortfolioDal());
        public IViewComponentResult Invoke()
        {
            var values = portfolioManger.TGetList();
            return View(values);
        }
    }
}
