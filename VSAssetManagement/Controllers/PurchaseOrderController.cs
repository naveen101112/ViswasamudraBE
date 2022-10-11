using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using VSAssetManagement.Models;
using VSAssetManagement.Repo;
using io = VSAssetManagement.IOModels;

namespace VSAssetManagement.Controllers
{
    [Route("purchase-order")]
    [ApiController]
    public class PurchaseOrderController : ControllerBase
    {
        PurchaseOrderRepo repo = new PurchaseOrderRepo(new VISWASAMUDRAContext());
        [HttpGet]
        public ActionResult getAllList()
        {
            List<io.PurchaseOrder> list =
                JsonConvert.
                DeserializeObject<List<io.PurchaseOrder>>(JsonConvert.SerializeObject(repo.getAllList()));

            return Ok(list);
        }

        [HttpGet("{id}")]
        public ActionResult getById(int id)
        {
            io.PurchaseOrder record = JsonConvert.
                DeserializeObject<io.PurchaseOrder>(JsonConvert.SerializeObject(repo.getById(id)));
            if (record == null) return NotFound();
            return Ok(record);
        }

        [HttpPost]
        public ActionResult createRecord([FromBody] io.PurchaseOrder record)
        {
            int id = repo.create(JsonConvert.
                DeserializeObject<PurchaseOrder>(JsonConvert.SerializeObject(record)));
            return Created($"/project/{id}","Created Successfully.");
        }

        [HttpPut]
        public ActionResult updateRecord([FromBody] io.PurchaseOrder record)
        {
            int id = repo.update(JsonConvert.
                DeserializeObject<PurchaseOrder>(JsonConvert.SerializeObject(record)));
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
