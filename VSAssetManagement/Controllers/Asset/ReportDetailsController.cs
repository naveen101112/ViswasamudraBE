using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using VSManagement.Models.VISWASAMUDRA;
using io = VSAssetManagement.IOModels;
using VSManagement.Repository.AssetManagement;
using System;
using VSAssetManagement.IOModels;

namespace VSManagement.Controllers.AssetManagement
{
    [Route("reports")]
    [ApiController]
    public class ReportDetailsController : ControllerBase
    {
        ReportsRepo repo = new ReportsRepo(new VISWASAMUDRAContext());

        [HttpGet("summaryreport")]
        public ActionResult getStoreDetails()
        {   
            return Ok(repo.GetStoreWiseData());
        }

        [HttpPost("storesummaryreport")]
        public ActionResult getStoreAndProjectDetails(StoreReport asr)
        {
            return Ok(repo.GetStore_projectWiseData(asr));
        }

        [HttpGet("Dashboardreport")]
        public ActionResult getDashboardDetails()
        {
            return Ok(repo.Get_DashBoard_Data());
        }

    }
}
