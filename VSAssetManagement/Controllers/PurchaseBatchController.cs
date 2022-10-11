using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using VSAssetManagement.Models;
using VSAssetManagement.Repo;
using io = VSAssetManagement.IOModels;

namespace VSAssetManagement.Controllers
{
    [Route("batch")]
    [ApiController]
    public class PurchaseBatchController : ControllerBase
    {
        BatchRepo repo = new BatchRepo(new VISWASAMUDRAContext());
        [HttpGet]
        public ActionResult getAllList()
        {
            List<io.Batch> list =
                JsonConvert.
                DeserializeObject<List<io.Batch>>(JsonConvert.SerializeObject(repo.getAllList()));

            return Ok(list);
        }

        [HttpGet("{id}")]
        public ActionResult getById(int id)
        {
            io.Batch record = JsonConvert.
                DeserializeObject<io.Batch>(JsonConvert.SerializeObject(repo.getById(id)));
            if (record == null) return NotFound();
            return Ok(record);
        }

        [HttpPost]
        public ActionResult createRecord([FromBody] io.Batch record)
        {
            int id = repo.create(JsonConvert.
                DeserializeObject<Batch>(JsonConvert.SerializeObject(record)));
            return Created($"/project/{id}","Created Successfully.");
        }

        [HttpPut]
        public ActionResult updateRecord([FromBody] io.Tag record)
        {
            int id = repo.update(JsonConvert.
                DeserializeObject<Batch>(JsonConvert.SerializeObject(record)));
            if (id == 0) return Conflict("Error updating record");
            return Ok("Updated successfully");
        }

        [HttpDelete("{id}")]
        public ActionResult deleteRecord(int id)
        {
            int count = repo.delete(id);
            if (id == 0) return Conflict("Error deleting record");
            return Ok("Deleted successfully");
        }
    }
}
