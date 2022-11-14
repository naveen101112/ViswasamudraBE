using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using VSManagement.Models.VISWASAMUDRA;
using io = VSAssetManagement.IOModels;
using VSManagement.Repository.AssetManagement;

namespace VSManagement.Controllers.AssetManagement
{
    [Route("Project")]
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

        [HttpPost("Create")]
        public ActionResult createRecord([FromBody] io.Project record)
        {
            int id = repo.create(JsonConvert.
                DeserializeObject<Project>(JsonConvert.SerializeObject(record)));
            return Created($"/project/{id}", "Created Successfully.");
        }

        [HttpPost("Update")]
        public ActionResult updateRecord([FromBody] io.Project record)
        {
            int id = repo.update(JsonConvert.
                DeserializeObject<Project>(JsonConvert.SerializeObject(record)));
            if (id == 0) return Conflict("Error updating record");
            return Ok("Updated successfully");
        }

        [HttpPost("Delete")]
        public ActionResult deleteRecord([FromBody] io.Project request)
        {
            int count = repo.delete(request);
            if (count == 0) return Conflict("Error deleting record");
            return Ok("Deleted successfully");
        }

        [HttpPost("search")]
        public ActionResult Search([FromBody] io.Project record)
        {
            var AssectModel = JsonConvert.
                DeserializeObject<io.Project>(JsonConvert.SerializeObject(record));
            List<io.Project> list =
            JsonConvert.DeserializeObject<List<io.Project>>(JsonConvert.SerializeObject(repo.searchListQuery(AssectModel)));

            return Ok(list);
        }

        [HttpGet("grid")]
        public ActionResult getDataGrid()
        {
            return Ok(repo.getDataGrid());
        }

        [HttpGet("combo")]
        public ActionResult getDropDown()
        {
            List<io.Project> record = JsonConvert.
                DeserializeObject<List<io.Project>>(JsonConvert.SerializeObject(repo.getDropDown()));
            if (record == null) return NotFound();
            return Ok(record);
        }
    }
}
