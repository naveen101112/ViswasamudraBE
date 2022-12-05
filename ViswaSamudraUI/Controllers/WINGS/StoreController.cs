using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViswaSamudraUI.Models;
using ViswaSamudraUI.Providers.Assets;
using VSAssetManagement.IOModels;

namespace ViswaSamudraUI.Controllers.WINGS
{
    public class StoreController : Controller
    {
        StoreProvider provider = new StoreProvider();
        ProjectProvider projectProvider = new ProjectProvider();
        public IActionResult Index()
        {
            IEnumerable<Store> list = provider.GetAll().OrderByDescending(s=>s.Id);
            return View(list);
        }

        public async Task<IActionResult> StoreOps(Store ioModel)
        {
            if (ioModel.Guid == Guid.Empty)
            {
                ViewBag.ParentStore = provider.GetSelectList(0);
                ViewBag.Project = projectProvider.GetSelectList();
                return View(ioModel);
            }
            IEnumerable<Store> list = provider.GetAllStore(ioModel);
            var result = list.FirstOrDefault();
            ViewBag.ParentStore = provider.GetSelectList(result.Id, result.ParentStore);
            ViewBag.Project = projectProvider.GetSelectList(result.Guid.ToString());
            return View(result);
        }

        public ActionResult StoreModification(Store model)
        {
            return Ok(provider.Add(model));           
        }

        public IActionResult Delete(Store model)
        {
            ResponseBody res = provider.Delete(model);
            if(res != null && res.Status == true)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return Ok(res);
            }
        }
    }
}
