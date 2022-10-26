using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ViswaSamudraUI.Providers.HRMS;
using VSManagement.IOModels;

namespace ViswaSamudraUI.Controllers.HRMS
{
    public class SalutationController : Controller
    {
		SalutationProvider provider = new SalutationProvider();
		public IActionResult Index()
		{
			IEnumerable<Salutation> list = provider.GetAll();
			return View(list);
		}
	}
}
