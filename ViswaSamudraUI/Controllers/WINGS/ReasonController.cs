using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViswaSamudraUI.Providers.Assets;
using VSAssetManagement.IOModels;
using io=VSAssetManagement.IOModels;


namespace ViswaSamudraUI.Controllers.WINGS
{
    public class ReasonController : Controller
    {
        ReasonProvider reasonProvider = new ReasonProvider();
        public IActionResult Index()
        {
            IEnumerable<io.Reason> reasonList = reasonProvider.GetAllReason();
            return View(reasonList);            
        }
        public async Task<IActionResult> ReasonGetDetailById(io.Reason resModel)
        {
            if (resModel.Guid == Guid.Empty)
            {
                return View("ReasonOps", resModel);
            }
            IEnumerable<io.Reason> poList = reasonProvider.GetAllReason(resModel);
            return View("ReasonOps", poList.FirstOrDefault());
        }

        public ActionResult ReasonModification(io.Reason resModel)
        {
            string poStatus = reasonProvider.AddReason(resModel);
            return Content(poStatus);
        }
    }
}
