using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ViswaSamudraUI.Providers.HRMS;
using VSManagement.IOModels;

namespace ViswaSamudraUI.Controllers.HRMS
{
    public class LocationsController : Controller
    {
		LocationsProvider provider = new LocationsProvider();
		public IActionResult Index()
		{
			IEnumerable<Locations> list = provider.GetAll();
			return View(list);
		}
	}
}
