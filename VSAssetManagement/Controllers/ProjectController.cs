using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using VSAssetManagement.Models;
using VSAssetManagement.Repo;
using io = VSAssetManagement.IOModels;

namespace VSAssetManagement.Controllers
{
    [Route("project")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        ProjectRepo repo = new ProjectRepo(new VISWASAMUDRAContext());
        [HttpGet]
        public ActionResult getList()
        {
            List<io.Project> list =
                JsonConvert.
                DeserializeObject<List<io.Project>>(JsonConvert.SerializeObject(repo.getAllList()));

            return Ok(list);
        }

        [HttpGet("{id}")]
        public ActionResult getById(int id)
        {
            io.Project record = JsonConvert.
                DeserializeObject<io.Project>(JsonConvert.SerializeObject(repo.getById(id)));
            if (record == null) return NotFound();
            return Ok(record);
        }

        [HttpPost]
        public ActionResult getById([FromBody] Project asset)
        {
            int id = repo.createAsset(asset);
            return Created($"/project/{id}","Created Successfully.");
        }
    }
}
