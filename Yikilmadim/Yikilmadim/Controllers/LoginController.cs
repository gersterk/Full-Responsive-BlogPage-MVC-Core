﻿using Microsoft.AspNetCore.Authorization;
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
	}
}
