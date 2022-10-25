using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ViswaSamudraUI.Providers.HRMS;
using VSManagement.IOModels;

namespace ViswaSamudraUI.Controllers.HRMS
{
    public class DeputationController : Controller
    {
		DeputationProvider provider = new DeputationProvider();
		public IActionResult Index()
		{
			IEnumerable<Deputation> list = provider.GetAll();
			return View(list);
		}
	}
}
