using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViswaSamudraUI.Providers.Assets;
using VSAssetManagement.IOModels;

namespace ViswaSamudraUI.Controllers
{
	public class BatchController : Controller
	{
        BatchProvider batchOrder = new BatchProvider();
        public IActionResult Index()
		{
            IEnumerable<Batch> BatchList = batchOrder.GetAllbatchOrder();
            return View(BatchList);
		}
        
    }
}
