using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ViswaSamudraUI.Providers.HRMS;
using VSManagement.IOModels;

namespace ViswaSamudraUI.Controllers.HRMS
{
    public class DivisionController : Controller
    {
		DivisionProvider provider = new DivisionProvider();
		public IActionResult Index()
		{
			IEnumerable<Division> list = provider.GetAll();
			return View(list);
		}
	}
}
