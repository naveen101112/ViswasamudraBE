using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using VSManagement.Models.VISWASAMUDRA;
using io = VSAssetManagement.IOModels;
using VSManagement.Repository.AssetManagement;
using System;

namespace VSManagement.Controllers.AssetManagement
{
    [Route("Store")]
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

        [HttpGet("combo")]
        public ActionResult getDropDown([FromQuery] int id)
        {
            List<io.Store> record = JsonConvert.
                DeserializeObject<List<io.Store>>(JsonConvert.SerializeObject(repo.getDropDown(id)));
            if (record == null) return NotFound();
            return Ok(record);
        }

        [HttpPost("Create")]
        public ActionResult createRecord([FromBody] io.Store record)
        {
            Guid id = repo.createAsset(JsonConvert.
                DeserializeObject<Store>(JsonConvert.SerializeObject(record)));
            return Created($"/store/{id}", "Created Successfully.");
        }

        [HttpPost("Update")]
        public ActionResult updateRecord([FromBody] io.Store record)
        {
            int id = repo.update(JsonConvert.
                DeserializeObject<Store>(JsonConvert.SerializeObject(record)));
            if (id == 0) return Conflict("Error updating record");
            return Ok("Updated successfully");
        }

        [HttpPost("search")]
        public ActionResult Search([FromBody] io.Store record)
        {
            var model = JsonConvert.
                DeserializeObject<io.Store>(JsonConvert.SerializeObject(record));
            List<io.Store> list =
            JsonConvert.DeserializeObject<List<io.Store>>(JsonConvert.SerializeObject(repo.searchListQuery(model)));

            return Ok(list);
        }

        [HttpPost("Delete")]
        public ActionResult deleteRecord([FromBody] io.Store request)
        {
            int count = repo.delete(request);
            //if (id == 0) return Conflict("Error deleting record");
            return Ok("Deleted successfully");
        }
    }
}
