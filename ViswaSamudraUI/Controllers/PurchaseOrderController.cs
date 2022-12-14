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
    public class PurchaseOrderController : Controller
    {
        PurchaseOrderProvider purchaseOrder = new PurchaseOrderProvider();
        public async Task<IActionResult> Index()
        {
            IEnumerable<PurchaseOrder> poList = purchaseOrder.GetAllPurchaseOrder();
            return View(poList);
        }

        public async Task<IActionResult> PoGetDetailById(PurchaseOrder PoIoModel)
        {
            if (PoIoModel.Guid == Guid.Empty)
            {
                return View("PoOps", PoIoModel);
            }
            IEnumerable<PurchaseOrder> poList = purchaseOrder.GetAllPurchaseOrder(PoIoModel);
            return View("PoOps", poList.FirstOrDefault());
        }

        public ActionResult PoModification(PurchaseOrder PoIoModel)
        {
            String poStatus = purchaseOrder.AddPurchaseOrder(PoIoModel);
            return Content(poStatus);
        }
    }
}
