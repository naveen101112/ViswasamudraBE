using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViswaSamudraUI.Providers.Assets;
using VSAssetManagement.IOModels;

namespace ViswaSamudraUI.Controllers.WINGS
{
    public class TagController : Controller
    {
        TagProvider provider = new TagProvider();
        LookUpProvider lookUpProvider = new LookUpProvider();
        public IActionResult Index()
        {
            IEnumerable<Tag> list = provider.GetAll().OrderByDescending(l=>l.Id);
            return View(list);
        }

        public async Task<IActionResult> TagOps(Tag ioModel)
        {
            if (ioModel.Guid == Guid.Empty)
            {
                ViewBag.Status = lookUpProvider.GetSelectList("TST");
                return View(ioModel);
            }
            IEnumerable<Tag> list = provider.GetAllTag(ioModel);
            var tag = list.FirstOrDefault();
            ViewBag.Status = lookUpProvider.GetSelectList("TST", tag.Status);
            return View(tag);
        }

        public ActionResult TagModification(Tag model)
        {
            return Ok(provider.Add(model));
            //return Content(status);
        }
    }
}
