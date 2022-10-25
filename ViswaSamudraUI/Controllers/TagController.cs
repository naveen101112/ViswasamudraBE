using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ViswaSamudraUI.Providers.Assets;
using VSAssetManagement.IOModels;

namespace ViswaSamudraUI.Controllers
{
	public class TagController : Controller
	{
		TagProvider provider = new TagProvider();
		public IActionResult Index()
		{
			IEnumerable<Tag> list = provider.GetAll();
			return View(list);
		}
	}
}
