using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using VSAssetManagement.Models;
using VSAssetManagement.Repo;
using io = VSAssetManagement.IOModels;

namespace VSAssetManagement.Controllers
{
    [Route("asset")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        AssetRepo assetRepo = new AssetRepo(new VISWASAMUDRAContext());
        [HttpGet]
        public ActionResult assetList()
        {
            List<io.Asset> list = 
                JsonConvert.
                DeserializeObject<List<io.Asset>>(JsonConvert.SerializeObject(assetRepo.getAllList()));

            return Ok(list);
        }

        [HttpGet("{id}")]
        public ActionResult assetGetById(int id)
        {
            Asset record = assetRepo.getById(id);
            if (record == null) return NotFound();
            return Ok(record);
        }

        [HttpPost]
        public ActionResult createAsset([FromBody] io.Asset record)
        {
            int id = assetRepo.createAsset(JsonConvert.
                DeserializeObject<Asset>(JsonConvert.SerializeObject(record)));
            return Created($"/asset/{id}","Created Successfully.");
        }
    }
}
