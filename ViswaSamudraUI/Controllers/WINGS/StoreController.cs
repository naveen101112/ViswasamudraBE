using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViswaSamudraUI.Providers.Assets;
using VSAssetManagement.IOModels;

namespace ViswaSamudraUI.Controllers.WINGS
{
    public class StoreController : Controller
    {
        StoreProvider provider = new StoreProvider();
        public IActionResult Index()
        {
            IEnumerable<Store> list = provider.GetAll();
            return View(list);
        }

        public async Task<IActionResult> StoreOps(Store ioModel)
        {
            if (ioModel.Guid == Guid.Empty)
            {
                return View(ioModel);
            }
            IEnumerable<Store> list = provider.GetAllStore(ioModel);
            var l = list.FirstOrDefault();
            return View(l);
        }

        public ActionResult StoreModification(Store model)
        {
            string status = provider.Add(model);
            return Content(status);
        }
    }
}
