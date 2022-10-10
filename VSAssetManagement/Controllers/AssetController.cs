using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using VSAssetManagement.Models;
using VSAssetManagement.Repo;
using io = VSAssetManagement.IOModels;

namespace VSAssetManagement.Controllers
{
    [ApiController]
    public class AssetController : ControllerBase
    {
        AssetRepo repo = new AssetRepo(new VISWASAMUDRAContext());


        [HttpGet]
        public ActionResult getAllList()
        {
            List<io.Asset> list = 
                JsonConvert.
                DeserializeObject<List<io.Asset>>(JsonConvert.SerializeObject(repo.getAllList()));

            return Ok(list);
        }

        [HttpGet("asset/{id}")]
        public ActionResult getById(int id)
        {
            Asset record = repo.getById(id);
            if (record == null) return NotFound();
            return Ok(record);
        }

        [HttpPost("asset")]
        public ActionResult createRecord([FromBody] io.Asset record)
        {
            int id = repo.create(JsonConvert.
                DeserializeObject<Asset>(JsonConvert.SerializeObject(record)));
            return Created($"/asset/{id}","Created Successfully.");
        }

        [HttpPut("asset")]
        public ActionResult updateRecord([FromBody] io.Asset record)
        {
            int id = repo.update(JsonConvert.
                DeserializeObject<Asset>(JsonConvert.SerializeObject(record)));
            if(id == 0) return Conflict("Error updating record");
            return Ok("Updated successfully");
        }

        [HttpDelete("asset/{id}")]
        public ActionResult deleteRecord(int id)
        {
            int count = repo.delete(id);
            if (id == 0) return Conflict("Error deleting record");
            return Ok("Deleted successfully");
        }
    }
}
