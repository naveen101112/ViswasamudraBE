using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViswaSamudraUI.Providers.Assets;
using VSAssetManagement.IOModels;
using io = VSAssetManagement.IOModels;

namespace ViswaSamudraUI.Controllers.WINGS
{
    public class BatchController : Controller
    {
        BatchProvider batchOrder = new BatchProvider();
        LookUpProvider lookUpProvider = new LookUpProvider();
        PurchaseOrderProvider purchaseOrderProvider = new PurchaseOrderProvider();
        ProjectProvider projectProvider = new ProjectProvider();
        StoreProvider storeProvider = new StoreProvider();
        public IActionResult Index()
        {
            BatchSearch batchModel = new BatchSearch();
            IEnumerable<BatchSearch> list = batchOrder.GetAll();
            return View(list);
        }

        public ActionResult POModification(PurchaseOrder PO)
        {
            string PoStatus = purchaseOrderProvider.AddPurchaseOrder(PO);
            return Content(PoStatus);
        }

        public async Task<IActionResult> BatchOps(BatchSearch model)
        {
            if (model.Guid == Guid.Empty)
            {
                ViewBag.StructureType = lookUpProvider.GetSelectList("STY");
                ViewBag.StructureSubType = lookUpProvider.GetSelectList("SST");
                ViewBag.AssetType = lookUpProvider.GetSelectList("ATY");
                ViewBag.AssetSpecification = lookUpProvider.GetSelectList("ATS");
                ViewBag.Uom = lookUpProvider.GetSelectList("UOM");
                ViewBag.UsageUom = lookUpProvider.GetUsageUomList();
                ViewBag.Users = lookUpProvider.GetTempUserData();
                ViewBag.PurchaseOrderNo = purchaseOrderProvider.GetSelectList();
                ViewBag.PurchaseProject = projectProvider.GetSelectList();
                ViewBag.PurchaseStore = storeProvider.GetSelectList(0);
                return View(model);
            }
            IEnumerable<BatchSearch> BatchList = batchOrder.GetAllBatches(model);
            var result = BatchList.FirstOrDefault();

            ViewBag.StructureType = lookUpProvider.GetSelectList("STY", result.StructureType);
            ViewBag.StructureSubType = lookUpProvider.GetSelectList("SST", result.StructureSubType);
            ViewBag.AssetType = lookUpProvider.GetSelectList("ATY", result.AssetType);
            ViewBag.AssetSpecification = lookUpProvider.GetSelectList("ATS", result.AssetSpecification);
            ViewBag.Uom = lookUpProvider.GetSelectList("UOM", result.Uom);
            ViewBag.UsageUom = lookUpProvider.GetUsageUomList();
            ViewBag.Users = lookUpProvider.GetTempUserData();
            ViewBag.PurchaseOrderNo = purchaseOrderProvider.GetSelectList(result.PurchaseOrderId.ToString());
            ViewBag.PurchaseProject = projectProvider.GetSelectList(result.PurchaseProject);
            ViewBag.PurchaseStore = storeProvider.GetSelectList(0, result.PurchaseStore);
            return View(result);
        }

        public ActionResult BatchModification(Batch batchModel)
        {
            string batchStatus = batchOrder.BatchModifications(batchModel);
            return Content(batchStatus);
        }
    }
}
