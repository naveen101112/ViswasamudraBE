using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using VSManagement.Models.VISWASAMUDRA;
using io = VSAssetManagement.IOModels;
using VSManagement.Repository.AssetManagement;

namespace VSManagement.Controllers.AssetManagement
{
    [Route("project")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        ProjectRepo repo = new ProjectRepo(new VISWASAMUDRAContext());
        [HttpGet]
        public ActionResult getAllList()
        {
            List<io.Project> list =
                JsonConvert.
                DeserializeObject<List<io.Project>>(JsonConvert.SerializeObject(repo.getAllList()));

            return Ok(list);
        }

        [HttpGet("blank")]
        public ActionResult getById(int id)
        {
            io.Project record = JsonConvert.
                DeserializeObject<io.Project>(JsonConvert.SerializeObject(repo.getById(id)));
            if (record == null) return NotFound();
            return Ok(record);
        }

        [HttpGet("{id}")]
        public ActionResult getByIdEdit(int id)
        {
            var record = repo.getByIdEdit(id);
            if (record == null) return NotFound();
            return Ok(record);
        }

        [HttpPost]
        public ActionResult createRecord([FromBody] io.Project record)
        {
            int id = repo.create(JsonConvert.
                DeserializeObject<Project>(JsonConvert.SerializeObject(record)));
            return Created($"/project/{id}", "Created Successfully.");
        }

        [HttpPut]
        public ActionResult updateRecord([FromBody] io.Project record)
        {
            int id = repo.update(JsonConvert.
                DeserializeObject<Project>(JsonConvert.SerializeObject(record)));
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

        [HttpGet("grid")]
        public ActionResult getDataGrid()
        {
            return Ok(repo.getDataGrid());
        }
    }
}
