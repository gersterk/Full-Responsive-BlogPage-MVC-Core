using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Yikilmadim.Controllers
{
    public class ConctactController : Controller
    {
        ContactManager cm = new ContactManager(new EFContactRepository());
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Contact p)
        {
            p.ContactDateTime =DateTime.Parse(DateTime.Now.ToShortDateString());

            p.ContactStatus = true;
            cm.ContactAdd(p);


            return RedirectToAction("Index", "Blog");
        }
    }
}
