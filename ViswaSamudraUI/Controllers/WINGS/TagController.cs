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
        public IActionResult Index()
        {
            IEnumerable<Tag> list = provider.GetAll();
            return View(list);
        }

        public async Task<IActionResult> TagOps(Tag ioModel)
        {
            if (ioModel.Guid == Guid.Empty)
            {
                return View(ioModel);
            }
            IEnumerable<Tag> list = provider.GetAllTag(ioModel);
            var l = list.FirstOrDefault();
            return View(l);
        }

        public ActionResult TagModification(Tag model)
        {
            string status = provider.Add(model);
            return Content(status);
        }
    }
}
