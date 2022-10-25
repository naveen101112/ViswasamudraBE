using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ViswaSamudraUI.Providers.HRMS;
using VSManagement.IOModels;

namespace ViswaSamudraUI.Controllers.HRMS
{
    public class BranchController : Controller
    {
		BranchProvider provider = new BranchProvider();
		public IActionResult Index()
		{
			IEnumerable<Branch> list = provider.GetAll();
			return View(list);
		}
	}
}
