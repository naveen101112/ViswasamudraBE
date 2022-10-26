using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ViswaSamudraUI.Providers.HRMS;
using VSManagement.IOModels;

namespace ViswaSamudraUI.Controllers.HRMS
{
    public class DepartmentController : Controller
    {
		DepartmentProvider provider = new DepartmentProvider();
		public IActionResult Index()
		{
			IEnumerable<Department> list = provider.GetAll();
			return View(list);
		}
	}
}
