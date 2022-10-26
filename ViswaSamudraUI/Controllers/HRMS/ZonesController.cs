using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ViswaSamudraUI.Providers.HRMS;
using VSManagement.IOModels;

namespace ViswaSamudraUI.Controllers.HRMS
{
    public class ZonesController : Controller
    {
		ZonesProvider provider = new ZonesProvider();
		public IActionResult Index()
		{
			IEnumerable<Zones> list = provider.GetAll();
			return View(list);
		}
	}
}
