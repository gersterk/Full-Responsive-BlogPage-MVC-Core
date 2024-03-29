﻿using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Yikilmadim.ViewComponents.Blog
{
	public class WriterLastBlog : ViewComponent
	{
		BlogManager bm = new BlogManager(new EFBlogRepository());


		public IViewComponentResult Invoke()
		{
			var values = bm.GetBlogListByWriter(5);
			return View(values);

		}
	}
}
