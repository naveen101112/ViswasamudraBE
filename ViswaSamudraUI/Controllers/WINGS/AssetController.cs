using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ViswaSamudraUI.Providers.Assets;
using VSAssetManagement.IOModels;

namespace ViswaSamudraUI.Controllers.WINGS
{
    public class AssetController : Controller
    {
        AssetProvider provider = new AssetProvider();
        public IActionResult Index()
        {
            Asset asset=new Asset();
            asset.RecordStatus = 1;
            IEnumerable<Asset> list = provider.GetAll(asset);
            return View(list);
        }
    }
}
