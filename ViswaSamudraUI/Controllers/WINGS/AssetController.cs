using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using ViswaSamudraUI.Providers.Assets;
using VSAssetManagement.IOModels;

namespace ViswaSamudraUI.Controllers.WINGS
{
    public class AssetController : Controller
    {
        AssetProvider assetprovider = new AssetProvider();
        LookUpProvider lookUpProvider = new LookUpProvider();
        TagProvider tagProvider = new TagProvider();
        ProjectProvider projectProvider = new ProjectProvider();
        StoreProvider storeProvider = new StoreProvider();
        Asset asset = new Asset();
        public IActionResult Index()
        {            
            asset.RecordStatus = 1;
            IEnumerable<Asset> list = assetprovider.GetAll(asset);
            return View(list);
        }

        public ActionResult AssetModification(Asset model)
        {
            return Ok(assetprovider.Add(model));
        }        

        public async Task<IActionResult> AssetOps(Asset model)
        {
            asset.Guid = model.Guid;
            asset.RecordStatus = 1;

            var result = assetprovider.GetAll(asset).FirstOrDefault();
            if(result.TagId == null)
            ViewBag.selectTag = tagProvider.GetSelectListWithoutMapped();
            else 
            ViewBag.selectTag = tagProvider.GetSelectListwithExisted((System.Guid)result.TagId);

            ViewBag.StructureType = lookUpProvider.GetSelectList("STY", result.StructureType.ToString());
            ViewBag.StructureSubType = lookUpProvider.GetSelectList("SST", result.StructureSubType.ToString());
            ViewBag.AssetType = lookUpProvider.GetSelectList("ATY", result.AssetType.ToString());
            ViewBag.AssetSpecification = lookUpProvider.GetSelectList("ATS", result.AssetSpecification.ToString());
            ViewBag.PurchaseProject = projectProvider.GetSelectList(result.ProjectCode.ToString());
            ViewBag.PurchaseStore = storeProvider.GetSelectList(0, result.Store.ToString());


            return View(result);
        }
    }
}
