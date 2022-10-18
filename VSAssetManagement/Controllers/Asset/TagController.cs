using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using VSManagement.Models.VISWASAMUDRA;
using io = VSAssetManagement.IOModels;
using VSManagement.Repository.AssetManagement;

namespace VSManagement.Controllers.AssetManagement
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

        [HttpGet("grid")]
        public ActionResult getDataGrid()
        {
            return Ok(repo.getDataGrid());
        }

        [HttpGet("{id}")]
        public ActionResult getById(int id)
        {
            var record = repo.getByIdEdit(id);
            if (record == null) return NotFound();
            return Ok(record);
        }

        [HttpPost]
        public ActionResult createRecord([FromBody] io.Tag record)
        {
            int id = repo.create(JsonConvert.
                DeserializeObject<Tag>(JsonConvert.SerializeObject(record)));
            return Created($"/project/{id}", "Created Successfully.");
        }

        [HttpPut]
        public ActionResult updateRecord([FromForm] io.Tag record)
        {
            Tag tag = repo.getById(record.Id, record.Guid);
            tag.Name = record.Name;
            tag.Code = record.Code;
            tag.Status = record.Status;
            int id = repo.update(tag);
            if (id == 0) return Conflict("Error updating record");
            return Ok(new { status = "success" });
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
