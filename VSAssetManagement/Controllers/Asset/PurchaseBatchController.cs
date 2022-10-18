using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using VSManagement.Models.VISWASAMUDRA;
using io = VSAssetManagement.IOModels;
using VSManagement.Repository.AssetManagement;

namespace VSManagement.Controllers.AssetManagement
{
    [Route("batch")]
    [ApiController]
    public class PurchaseBatchController : ControllerBase
    {
        BatchRepo repo = new BatchRepo(new VISWASAMUDRAContext());
        [HttpGet]
        public ActionResult getAllList()
        {
            List<io.Batch> list =
                JsonConvert.
                DeserializeObject<List<io.Batch>>(JsonConvert.SerializeObject(repo.getAllList()));

            return Ok(list);
        }

        [HttpGet("blank")]
        public ActionResult getById(int id)
        {
            io.Batch record = JsonConvert.
                DeserializeObject<io.Batch>(JsonConvert.SerializeObject(repo.getByOnlyId(id)));
            if (record == null) return NotFound();
            return Ok(record);
        }

        [HttpGet("{id}")]
        public ActionResult getByIdEdit(int id)
        {
            var record = repo.getbyIdEdit(id);
            if (record == null) return NotFound();
            return Ok(record);
        }

        [HttpPost]
        public ActionResult createRecord([FromBody] io.Batch record)
        {
            int id = repo.create(JsonConvert.
                DeserializeObject<Batch>(JsonConvert.SerializeObject(record)));
            return Created($"/project/{id}", "Created Successfully.");
        }

        [HttpPut]
        public ActionResult updateRecord([FromForm] io.Batch record)
        {
            Batch batch = repo.getById(record.Id, record.Guid);
            batch.BatchName = record.BatchName;
            batch.BatchNo = record.BatchNo;
            batch.AssetSize = record.AssetSize;
            batch.AssetType = record.AssetType;
            batch.PurchaseBatchMasterGuid = record.PurchaseBatchMasterGuid;
            batch.Quantity = record.Quantity;
            repo._context.Entry(batch).State = EntityState.Detached;
            int id = repo.update(batch);
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

        [HttpGet("grid")]
        public ActionResult getDataGrid()
        {
            return Ok(repo.getDataGrid());
        }
    }
}
