using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViswaSamudraUI.Providers.Assets;
using Microsoft.AspNetCore.Mvc.Rendering;
using io =VSAssetManagement.IOModels;
using System.Text.RegularExpressions;


namespace ViswaSamudraUI.Controllers.WINGS
{
    public class ReasonController : Controller
    {
        ReasonProvider reasonProvider = new ReasonProvider();
        LookUpProvider lookUpProvider = new LookUpProvider();

        public IActionResult Index()
        {            
            IEnumerable<io.Reason> reasonList = reasonProvider.GetAllReason();
            return View(reasonList);            
        }
        public async Task<IActionResult> ReasonGetDetailById(io.Reason resModel)
        {
            if (resModel.Guid == Guid.Empty)
            {
                ViewBag.reasontype = lookUpProvider.GetSelectList("RTY");
                return View("ReasonOps", resModel);
            }
            IEnumerable<io.Reason> poList = reasonProvider.GetAllReason(resModel);
            var result = poList.FirstOrDefault();           
            
            ViewBag.reasontype = lookUpProvider.GetSelectList("RTY", result.ReasonType);

            return View("ReasonOps", result);
        }

        public ActionResult ReasonModification(io.Reason resModel)
        {
            return Ok(reasonProvider.AddReason(resModel));
            //return Content(poStatus);
        }
    }
}
