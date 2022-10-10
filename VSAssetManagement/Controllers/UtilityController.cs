using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using VSAssetManagement.Models;
using VSAssetManagement.Repo;
using io = VSAssetManagement.IOModels;

namespace VSAssetManagement.Controllers
{
    [Route("utility")]
    [ApiController]
    public class UitilityController : ControllerBase
    {
        UtilityRepo repo = new UtilityRepo(new VISWASAMUDRAContext());

        [HttpGet("status")]
        public ActionResult getByStatusListByType([FromQuery] io.Pagination page)
        {
            List <Status> statusList = repo.getStatusListForType(page);
            if (statusList == null) return NotFound();
            return Ok(statusList);
        }
    }
}
