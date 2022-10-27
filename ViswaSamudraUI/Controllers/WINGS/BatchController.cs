using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViswaSamudraUI.Providers.Assets;
using VSAssetManagement.IOModels;
using io = VSAssetManagement.IOModels;

namespace ViswaSamudraUI.Controllers.WINGS
{
    public class BatchController : Controller
    {
        BatchProvider batchOrder = new BatchProvider();
        BatchSearch BatchSearch = new BatchSearch();
        public IActionResult Index()
        {
            BatchSearch batchModel = new BatchSearch();
            BatchSearch.Id = 0;
            IEnumerable<BatchSearch> list = batchOrder.GetAllBatches(BatchSearch);
            return View(list);
        }

        public async Task<IActionResult> BatchGetDetailById(BatchSearch batchModel)
        {
            if (batchModel.Guid == Guid.Empty)
            {
                return View("BatchOps", batchModel);
            }
            IEnumerable<BatchSearch> BatchList = batchOrder.GetAllBatches(batchModel);
            return View("BatchOps", BatchList.FirstOrDefault());
        }

        public ActionResult BatchModification(Batch batchModel)
        {
            string batchStatus = batchOrder.BatchModifications(batchModel);
            return Content(batchStatus);
        }
    }
}
