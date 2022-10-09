using Microsoft.AspNetCore.Mvc;
using VSAssetManagement.Models;
using VSAssetManagement.Repo;

namespace VSAssetManagement.Controllers
{
    [Route("store")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        StoreRepo repo = new StoreRepo(new VISWASAMUDRAContext());
        [HttpGet]
        public ActionResult getList()
        {
            return Ok(repo.getAllList());
        }

        [HttpGet("{id}")]
        public ActionResult getById(int id)
        {
            Store record = repo.getById(id);
            if (record == null) return NotFound();
            return Ok(record);
        }

        [HttpPost]
        public ActionResult getById([FromBody] Store record)
        {
            int id = repo.createAsset(record);
            return Created($"/store/{id}","Created Successfully.");
        }
    }
}
