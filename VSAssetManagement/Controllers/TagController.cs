using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using VSAssetManagement.Models;
using VSAssetManagement.Repo;
using io = VSAssetManagement.IOModels;

namespace VSAssetManagement.Controllers
{
    [Route("tag")]
    [ApiController]
    public class TagController : ControllerBase
    {
        TagRepo repo = new TagRepo(new VISWASAMUDRAContext());
        [HttpGet]
        public ActionResult getAllList()
        {
            List<io.Tag> list =
                JsonConvert.
                DeserializeObject<List<io.Tag>>(JsonConvert.SerializeObject(repo.getAllListLinq()));

            return Ok(list);
        }

        [HttpGet("{id}")]
        public ActionResult getById(int id)
        {
            io.Tag record = JsonConvert.
                DeserializeObject<io.Tag>(JsonConvert.SerializeObject(repo.getById(id)));
            if (record == null) return NotFound();
            return Ok(record);
        }

        [HttpPost]
        public ActionResult createRecord([FromBody] io.Tag record)
        {
            int id = repo.create(JsonConvert.
                DeserializeObject<Tag>(JsonConvert.SerializeObject(record)));
            return Created($"/project/{id}","Created Successfully.");
        }

        [HttpPut]
        public ActionResult updateRecord([FromBody] io.Tag record)
        {
            int id = repo.update(JsonConvert.
                DeserializeObject<Tag>(JsonConvert.SerializeObject(record)));
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
