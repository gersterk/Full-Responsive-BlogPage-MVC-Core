using Microsoft.AspNetCore.Mvc;
using Yikilmadim.Models;

namespace Yikilmadim.ViewComponents
{
	public class CommentList : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			var commentvalues = new List<UserComment>
			{
				new UserComment
				{
					ID=1,
					UserName= "Murat"
				},

				new UserComment
				{
					ID= 2,
					UserName="Baris"
				},
			};
			return View(commentvalues);
		} 
	}
}
