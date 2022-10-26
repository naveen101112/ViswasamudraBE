using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using VSManagement.Models.VISWASAMUDRA;
using io = VSAssetManagement.IOModels;
using VSManagement.Repository.AssetManagement;
using System;

namespace VSManagement.Controllers.AssetManagement
{
    [Route("reason")]
    [ApiController]
    public class ReasonController : ControllerBase
    {
        ReasonRepo repo = new ReasonRepo(new VISWASAMUDRAContext());
        [HttpGet]
        public ActionResult getAllList()
        {
            List<io.Reason> list =
                JsonConvert.
                DeserializeObject<List<io.Reason>>(JsonConvert.SerializeObject(repo.getAllList()));
            return Ok(list);
        }

        [HttpGet("{id}")]
        public ActionResult getById(Guid id)
        {
            io.Reason record = JsonConvert.
                DeserializeObject<io.Reason>(JsonConvert.SerializeObject(repo.getById(id)));
            if (record == null) return NotFound();
            return Ok(record);
        }

        [HttpPost]
        public ActionResult createRecord([FromBody] io.Reason record)
        {
            Guid id = repo.createAsset(JsonConvert.
                DeserializeObject<Reason>(JsonConvert.SerializeObject(record)));
            return Created($"/reason/{id}", "Created Successfully.");
        }

        [HttpPut]
        public ActionResult updateRecord([FromBody] io.Reason record)
        {
            int id = repo.update(JsonConvert.
                DeserializeObject<Reason>(JsonConvert.SerializeObject(record)));
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
