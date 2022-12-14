using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using VSManagement.Models.VISWASAMUDRA;
using io = VSAssetManagement.IOModels;
using VSManagement.Repository.AssetManagement;
using System;

namespace VSManagement.Controllers.AssetManagement
{
    [Route("store")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        StoreRepo repo = new StoreRepo(new VISWASAMUDRAContext());
        [HttpGet]
        public ActionResult getAllList()
        {
            List<io.Store> list =
                JsonConvert.
                DeserializeObject<List<io.Store>>(JsonConvert.SerializeObject(repo.getAllList()));
            return Ok(list);
        }

        [HttpGet("{id}")]
        public ActionResult getById(Guid id)
        {
            io.Store record = JsonConvert.
                DeserializeObject<io.Store>(JsonConvert.SerializeObject(repo.getById(id)));
            if (record == null) return NotFound();
            return Ok(record);
        }

        [HttpPost]
        public ActionResult createRecord([FromBody] io.Store record)
        {
            Guid id = repo.createAsset(JsonConvert.
                DeserializeObject<Store>(JsonConvert.SerializeObject(record)));
            return Created($"/store/{id}", "Created Successfully.");
        }

        [HttpPut]
        public ActionResult updateRecord([FromBody] io.Store record)
        {
            int id = repo.update(JsonConvert.
                DeserializeObject<Store>(JsonConvert.SerializeObject(record)));
            if (id == 0) return Conflict("Error updating record");
            return Ok("Updated successfully");
        }

        [HttpDelete("{id}")]
        public ActionResult deleteRecord(Guid id)
        {
            int count = repo.delete(id);
            //if (id == 0) return Conflict("Error deleting record");
            return Ok("Deleted successfully");
        }
    }
}
