using DataAccesLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Yikilmadim.Controllers
{
	public class LoginController : Controller
	{
		//[AllowAnonymous]
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Index(Writer p)
		{
			Context c = new Context();
			var datavalues = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword);
			
			if(datavalues != null)
            {
				HttpContext.Session.SetString("usernmae", p.WriterMail);
				return RedirectToAction("Briter", "Blog");

            }
            else
            {
				return View();
			}
			
		}
	}
}
