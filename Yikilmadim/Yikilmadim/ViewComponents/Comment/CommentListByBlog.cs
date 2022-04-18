using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Yikilmadim.ViewComponents.Comment
{
	public class CommentListByBlog : ViewComponent
	{
		CommentManager cm = new CommentManager(new EFCommentRepository());

		public IViewComponentResult Invoke(int id)
		{
			var values = cm.GetList(id);
			return View(values);

		}
	}
}
