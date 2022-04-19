using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using DataAccesLayer.EntityFramework;


namespace Yikilmadim.Controllers
{
    public class AboutController : Controller
    {
        AboutManager abm = new AboutManager(new EFAboutRepository());

        public IActionResult Index()
        {
            var values = abm.GetList();
            return View(values);
        }
        public PartialViewResult SocialMediaAbout()
        { 
            return PartialView();

        }
    }
}
