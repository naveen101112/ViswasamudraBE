using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViswaSamudraUI.Providers.Assets;
using VSAssetManagement.IOModels;

namespace ViswaSamudraUI.Controllers.WINGS
{
    public class AssetRequisitionController : Controller
    {
        //AssetProvider provider = new AssetProvider();
        LookUpProvider lookUpProvider = new LookUpProvider();
        ProjectProvider projectProvider = new ProjectProvider();
        public IActionResult Index()
        {
            IEnumerable<AssetRequisitionHeader> list = null;
            return View(list);
        }

        public ActionResult AssetRequisitionModification(AssetRequisition model)
        {
            return Ok(null);//assetprovider.Add(model));
        }
        public async Task<IActionResult> AssetRequisitionOps(AssetRequisition model)
        {
            ViewBag.Users = lookUpProvider.GetTempUserData();
            ViewBag.ReqStatus = lookUpProvider.GetRequisitionStatusData();
            ViewBag.TaskType = lookUpProvider.GetSelectList("TTY");
            ViewBag.Project = projectProvider.GetSelectList();

            ViewBag.StructureType = lookUpProvider.GetSelectList("STY");
            ViewBag.StructureSubType = lookUpProvider.GetSelectList("SST");
            ViewBag.AssetType = lookUpProvider.GetSelectList("ATY");
            ViewBag.AssetSpecification = lookUpProvider.GetSelectList("ATS");
            ViewBag.Uom = lookUpProvider.GetSelectList("UOM");
            List<AssetRequisitionDetails> li = new List<AssetRequisitionDetails>();
            AssetRequisition req = new AssetRequisition();
            req.details = li;
            return View(req);
        }
    }
}
