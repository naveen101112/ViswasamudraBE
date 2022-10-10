using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using VSAssetManagement.Models;
using VSAssetManagement.Repo;
using io = VSAssetManagement.IOModels;

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
            List<io.Store> list =
                JsonConvert.
                DeserializeObject<List<io.Store>>(JsonConvert.SerializeObject(repo.getAllList()));
            return Ok(list);
        }

        [HttpGet("{id}")]
        public ActionResult getById(int id)
        {
            io.Store record = JsonConvert.
                DeserializeObject<io.Store>(JsonConvert.SerializeObject(repo.getById(id)));
            if (record == null) return NotFound();
            return Ok(record);
        }

        [HttpPost]
        public ActionResult getById([FromBody] io.Store record)
        {
            int id = repo.createAsset(JsonConvert.
                DeserializeObject<Store>(JsonConvert.SerializeObject(record)));
            return Created($"/store/{id}","Created Successfully.");
        }
    }
}
