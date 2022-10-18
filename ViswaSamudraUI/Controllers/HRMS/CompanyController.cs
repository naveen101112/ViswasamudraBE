using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ViswaSamudraUI.Providers.HRMS;
using VSManagement.IOModels;

namespace ViswaSamudraUI.Controllers.HRMS
{
    public class CompanyController : Controller
    {
		CompanyProvider provider = new CompanyProvider();
		public IActionResult Index()
		{
			IEnumerable<Company> list = provider.GetAll();
			return View(list);
		}
	}
}
