using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using VSManagement.Models.VISWASAMUDRA;
using io = VSAssetManagement.IOModels;
using VSManagement.Repository.AssetManagement;
using ViswasamudraCommonObjects.Util;

namespace VSManagement.Controllers.AssetManagement
{
    [Route("utility")]
    [ApiController]
    public class UitilityController : ControllerBase
    {
        UtilityRepo repo = new UtilityRepo(new VISWASAMUDRAContext());

        [HttpGet("status")]
        public ActionResult getByStatusListByType([FromQuery] Pagination page)
        {
            return Ok("");
        }
    }
}
