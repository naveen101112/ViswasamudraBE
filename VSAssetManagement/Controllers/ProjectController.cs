using Microsoft.AspNetCore.Mvc;
using VSAssetManagement.Models;
using VSAssetManagement.Repo;

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
            return Ok(repo.getAllList());
        }

        [HttpGet("{id}")]
        public ActionResult getById(int id)
        {
            Project record = repo.getById(id);
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
