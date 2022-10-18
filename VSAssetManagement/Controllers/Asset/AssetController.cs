using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using VSManagement.Models.VISWASAMUDRA;
using io = VSAssetManagement.IOModels;
using VSManagement.Repository.AssetManagement;
using ViswasamudraCommonObjects.Util;

namespace VSManagement.Controllers.AssetManagement
{
    [ApiController]
    public class AssetController : ControllerBase
    {
        AssetRepo repo = new AssetRepo(new VISWASAMUDRAContext());
        AssetHistoryRepo historyRepo = new AssetHistoryRepo(new VISWASAMUDRAContext());
        AssetOperationsRepo operationsRepo = new AssetOperationsRepo(new VISWASAMUDRAContext());

        #region Asset
        [HttpGet("asset")]
        public ActionResult getAllList([FromQuery] Pagination page)
        {
            List<io.Asset> list =
                JsonConvert.
                DeserializeObject<List<io.Asset>>(JsonConvert.SerializeObject(repo.getAllList(page)));

            return Ok(list);
        }

        [HttpGet("asset/blank")]
        public ActionResult getById(int id)
        {
            Asset record = repo.getByOnlyId(id);
            if (record == null) return NotFound();
            return Ok(record);
        }

        [HttpGet("asset/{id}")]
        public ActionResult getByIdEdit(int id)
        {
            var record = repo.getByIdEdit(id);
            if (record == null) return NotFound();
            return Ok(record);
        }

        [HttpPost("asset")]
        public ActionResult createRecord([FromBody] io.Asset record)
        {
            int id = repo.create(JsonConvert.
                DeserializeObject<Asset>(JsonConvert.SerializeObject(record)));
            return Created($"/asset/{id}", "Created Successfully.");
        }

        [HttpPut("asset")]
        public ActionResult updateRecord([FromForm] io.Asset record)
        {
            Asset asset = repo.getById(record.Id, record.Guid);
            asset.Code = record.Code;
            asset.Name = record.Name;
            asset.ProjectGuid = record.ProjectGuid;
            asset.StoreGuid = record.StoreGuid;
            asset.BatchGuid = record.BatchGuid;
            asset.CompanyName = record.CompanyName;
            int id = repo.update(asset);
            if (id == 0) return Conflict("Error updating record");
            return Ok(new { status = "success" });
        }

        [HttpDelete("asset/{id}")]
        public ActionResult deleteRecord(int id)
        {
            int count = repo.delete(id);
            if (id == 0) return Conflict("Error deleting record");
            return Ok("Deleted successfully");
        }

        [HttpGet("asset/grid")]
        public ActionResult getDataGrid()
        {
            return Ok(repo.getDataGrid());
        }
        #endregion

        #region AssetHistory
        [HttpGet("assetHistory")]
        public ActionResult getAllHistoryList()
        {
            List<io.AssetHistory> list =
                JsonConvert.
                DeserializeObject<List<io.AssetHistory>>(JsonConvert.SerializeObject(historyRepo.getAllList()));

            return Ok(list);
        }

        [HttpGet("assetHistory/{id}")]
        public ActionResult getByHistoryId(int id)
        {
            AssetHistory record = historyRepo.getById(id);
            if (record == null) return NotFound();
            return Ok(record);
        }

        [HttpPost("assetHistory")]
        public ActionResult createHistoryRecord([FromBody] io.Asset record)
        {
            int id = historyRepo.create(JsonConvert.
                DeserializeObject<AssetHistory>(JsonConvert.SerializeObject(record)));
            return Created($"/assetHistory/{id}", "Created Successfully.");
        }

        [HttpPut("assetHistory")]
        public ActionResult updateHistoryRecord([FromBody] io.Asset record)
        {
            int id = historyRepo.update(JsonConvert.
                DeserializeObject<AssetHistory>(JsonConvert.SerializeObject(record)));
            if (id == 0) return Conflict("Error updating record");
            return Ok("Updated successfully");
        }

        [HttpDelete("assetHistory/{id}")]
        public ActionResult deleteHistoryRecord(int id)
        {
            int count = historyRepo.delete(id);
            if (id == 0) return Conflict("Error deleting record");
            return Ok("Deleted successfully");
        }

        [HttpGet("assetHistory/grid")]
        public ActionResult getDataGridHistory()
        {
            return Ok(historyRepo.getDataGrid());
        }
        #endregion

        #region AssetOperations
        [HttpGet("assetOperations")]
        public ActionResult getAllOperationList()
        {
            List<io.AssetOperations> list =
                JsonConvert.
                DeserializeObject<List<io.AssetOperations>>(JsonConvert.SerializeObject(historyRepo.getAllList()));

            return Ok(list);
        }

        [HttpGet("assetOperations/{id}")]
        public ActionResult getByOperationId(int id)
        {
            AssetOperations record = operationsRepo.getById(id);
            if (record == null) return NotFound();
            return Ok(record);
        }

        [HttpPost("assetOperations")]
        public ActionResult createOperationRecord([FromBody] io.Asset record)
        {
            int id = operationsRepo.create(JsonConvert.
                DeserializeObject<AssetOperations>(JsonConvert.SerializeObject(record)));
            return Created($"/assetHistory/{id}", "Created Successfully.");
        }

        [HttpPut("assetOperations")]
        public ActionResult updateOperationRecord([FromBody] io.Asset record)
        {
            int id = operationsRepo.update(JsonConvert.
                DeserializeObject<AssetOperations>(JsonConvert.SerializeObject(record)));
            if (id == 0) return Conflict("Error updating record");
            return Ok("Updated successfully");
        }

        [HttpDelete("assetOperations/{id}")]
        public ActionResult deleteOperationRecord(int id)
        {
            int count = operationsRepo.delete(id);
            if (id == 0) return Conflict("Error deleting record");
            return Ok("Deleted successfully");
        }

        [HttpGet("assetOperations/grid")]
        public ActionResult getDataGridOperations()
        {
            return Ok(operationsRepo.getDataGrid());
        }
        #endregion
    }
}
