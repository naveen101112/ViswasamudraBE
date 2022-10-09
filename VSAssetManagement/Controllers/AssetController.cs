using Microsoft.AspNetCore.Mvc;
using VSAssetManagement.Models;
using VSAssetManagement.Repo;

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
            return Ok(assetRepo.getAllList());
        }

        [HttpGet("{id}")]
        public ActionResult assetGetById(int id)
        {
            Asset record = assetRepo.getById(id);
            if (record == null) return NotFound();
            return Ok(record);
        }

        [HttpPost]
        public ActionResult createAsset([FromBody] Asset asset)
        {
            int id = assetRepo.createAsset(asset);
            return Created($"/asset/{id}","Created Successfully.");
        }
    }
}
