﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ViswaSamudraUI.Models;
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
            return Ok(purchaseOrderProvider.AddPurchaseOrder(PO));
            //return Content(PoStatus);
        }

        public PurchaseOrder POGet(PurchaseOrder PO)
        {
            PurchaseOrder po = new PurchaseOrder();
            po.Guid = PO.Guid;            
            var ddd= purchaseOrderProvider.GetAllPurchaseOrder(po).FirstOrDefault();
            return ddd;
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
                ViewBag.UsageUom = lookUpProvider.GetSelectList("UUM");
                ViewBag.Users = lookUpProvider.GetTempUserData();
                ViewBag.PurchaseOrderNo = purchaseOrderProvider.GetSelectList();
                ViewBag.PurchaseProject = projectProvider.GetSelectList();
                ViewBag.PurchaseStore = storeProvider.GetSelectList(0);
                return View(model);
            }
            IEnumerable<BatchSearch> BatchList = batchOrder.GetAllBatches(model);
            var result = BatchList.FirstOrDefault();

            ViewBag.StructureType = lookUpProvider.GetSelectList("STY", result.StructureType.ToString());
            ViewBag.StructureSubType = lookUpProvider.GetSelectList("SST", result.StructureSubType.ToString());
            ViewBag.AssetType = lookUpProvider.GetSelectList("ATY", result.AssetType.ToString());
            ViewBag.AssetSpecification = lookUpProvider.GetSelectList("ATS", result.AssetSpecification.ToString());
            ViewBag.Uom = lookUpProvider.GetSelectList("UOM", result.Uom.ToString());            
            ViewBag.UsageUom = lookUpProvider.GetSelectList("UUM", result.UsageUom.ToString());
            ViewBag.Users = lookUpProvider.GetTempUserData();
            ViewBag.PurchaseOrderNo = purchaseOrderProvider.GetSelectList(result.PurchaseOrderId.ToString());
            ViewBag.PurchaseProject = projectProvider.GetSelectList(result.PurchaseProject.ToString());
            ViewBag.PurchaseStore = storeProvider.GetSelectList(0, result.PurchaseStore.ToString());
            return View(result);
        }

        public ActionResult BatchModification(Batch batchModel)
        {
            ResponseBody batchStatus = batchOrder.BatchModifications(batchModel);
            return Ok(batchStatus);
        }
    }
}
