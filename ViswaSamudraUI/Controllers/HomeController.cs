using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ViswaSamudraUI.Models;
using Newtonsoft.Json;
using VSAssetManagement.IOModels;
using ViswaSamudraUI.Providers.Assets;

namespace ViswaSamudraUI.Controllers
{
    public class HomeController : Controller
    {
        PurchaseOrderProvider purchaseOrder = new PurchaseOrderProvider();
        public async Task<IActionResult> Index()
        {            
            IEnumerable<PurchaseOrder> poList = purchaseOrder.GetAllPurchaseOrder(); 
            return View(poList);
        }

        
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
