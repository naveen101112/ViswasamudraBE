using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ViswaSamudraUI.Providers.Assets;
using VSAssetManagement.IOModels;

namespace ViswaSamudraUI.Controllers
{
	public class AssetController : Controller
	{
		AssetProvider provider = new AssetProvider();
		public IActionResult Index()
		{
			IEnumerable<Asset> list = provider.GetAll();
			return View(list);
		}
	}
}
