using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Results;
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
        PurchaseOrder po = new PurchaseOrder();
        public IActionResult Index()
        {
            BatchSearch batchModel = new BatchSearch();
            IEnumerable<BatchSearch> list = batchOrder.GetAll().OrderByDescending(l=>l.Id);
            return View(list);
        }

        public ActionResult POModification(PurchaseOrder PO)
        {
            return Ok(purchaseOrderProvider.AddPurchaseOrder(PO));            
        }

        public PurchaseOrder POGet(PurchaseOrder PO)
        {            
            po.Guid = PO.Guid;            
            return purchaseOrderProvider.GetAllPurchaseOrder(po).FirstOrDefault();            
        }

        public List<SelectListItem> POStoreByProject(Project project)
        {
            return ViewBag.PurchaseStore = storeProvider.GetSelectListPro(0, project.Guid);
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
                ViewBag.UsageUom = lookUpProvider.GetSelectList("UOM");
                ViewBag.Users = lookUpProvider.GetTempUserData();
                ViewBag.PurchaseOrderNo = purchaseOrderProvider.GetSelectList();
                ViewBag.PurchaseProject = projectProvider.GetSelectList();                
                return View(model);
            }
            IEnumerable<BatchSearch> BatchList = batchOrder.GetAllBatches(model);
            var result = BatchList.FirstOrDefault();

            ViewBag.StructureType = lookUpProvider.GetSelectList("STY", result.StructureType.ToString());
            ViewBag.StructureSubType = lookUpProvider.GetSelectList("SST", result.StructureSubType.ToString());
            ViewBag.AssetType = lookUpProvider.GetSelectList("ATY", result.AssetType.ToString());
            ViewBag.AssetSpecification = lookUpProvider.GetSelectList("ATS", result.AssetSpecification.ToString());
            ViewBag.Uom = lookUpProvider.GetSelectList("UOM", result.Uom.ToString());            
            ViewBag.UsageUom = lookUpProvider.GetSelectList("UOM", result.UsageUom.ToString());
            ViewBag.Users = lookUpProvider.GetTempUserData();
            ViewBag.PurchaseOrderNo = purchaseOrderProvider.GetSelectList(result.PurchaseOrderId.ToString());
            ViewBag.PurchaseProject = projectProvider.GetSelectList(result.PurchaseProject.ToString());
            ViewBag.PurchaseStore = storeProvider.GetSelectListPro(0, result.PurchaseProject, result.PurchaseStore.ToString());            
            return View(result);
        }

        public ActionResult BatchModification(BatchSearch batchModel)
        {
            ResponseBody batchStatus = batchOrder.BatchModifications(batchModel);            
            po.Guid=batchModel.PurchaseOrderId;
            po.RecordStatus = 1;
            po.CompanyName = batchModel.CompanyName;
            po.PurchaseProject = batchModel.PurchaseProject;
            po.PurchaseStore = batchModel.PurchaseStore;
            po.PurchaseOrderDate= batchModel.PurchaseOrderDate;
            ResponseBody Postatus = purchaseOrderProvider.UpdatePurchaseOrder(po);

            return Ok(batchStatus);
        }
    }
}
