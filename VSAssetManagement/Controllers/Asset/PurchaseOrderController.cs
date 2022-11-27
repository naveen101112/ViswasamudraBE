﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using VSManagement.Models.VISWASAMUDRA;
using io = VSAssetManagement.IOModels;
using VSManagement.Repository.AssetManagement;

namespace VSManagement.Controllers.AssetManagement
{
    [Route("PurchaseOrder")]
    [ApiController]
    public class PurchaseOrderController : ControllerBase
    {
        PurchaseOrderRepo repo = new PurchaseOrderRepo(new VISWASAMUDRAContext());

        [HttpGet]
        public ActionResult getAllList()
        {
            List<io.PurchaseOrder> list =
                JsonConvert.
                DeserializeObject<List<io.PurchaseOrder>>(JsonConvert.SerializeObject(repo.getAllList()));

            return Ok(list);
        }

        [HttpPost("posearch")]
        public ActionResult Search([FromBody] io.PurchaseOrder record)
        {
            var AssectModel = JsonConvert.
                DeserializeObject<io.PurchaseOrder>(JsonConvert.SerializeObject(record));
            List<io.PurchaseOrder> list =
            JsonConvert.DeserializeObject<List<io.PurchaseOrder>>(JsonConvert.SerializeObject(repo.searchListQuery(AssectModel)));

            return Ok(list);
        }

        [HttpGet("{id}")]
        public ActionResult getById(int id)
        {
            var record = repo.getByIdEdit(id);
            if (record == null) return NotFound();
            return Ok(record);
        }

        [HttpPost("CreatePO")]
        public ActionResult createRecord([FromBody] io.PurchaseOrder record)
        {
            int id = repo.create(JsonConvert.
                DeserializeObject<PurchaseOrder>(JsonConvert.SerializeObject(record)));
            if (id == -1) return Problem("PurchaseOrder Exist");
            return Created($"/PurchaseOrder/{id}", "Created Successfully.");
        }

        [HttpPost("UpdatePo")]
        public ActionResult updateRecord([FromBody] io.PurchaseOrder record)
        {
            PurchaseOrder order = repo.getById(record.Id, record.Guid);
            order.PurchaseOrderNo = record.PurchaseOrderNo.ToString();
            order.PurchaseOrderDate = record.PurchaseOrderDate;
            order.PurchaseStore = record.PurchaseStore;
            order.PurchaseProject = record.PurchaseProject;
            order.CompanyName = record.CompanyName;
            order.LastUpdatedBy = "User";
            order.LastUpdatedDateTime = System.DateTime.Now;
            int id = repo.update(order);
            if (id == 0) return Conflict("Error updating record");
            return Ok("Updated successfully");
        }

        [HttpPost("UpdatePoByName")]
        public ActionResult updateRecordByName([FromBody] io.PurchaseOrder record)
        {
            PurchaseOrder order = repo.getById(record.Guid);            
            order.PurchaseOrderDate = record.PurchaseOrderDate;
            order.PurchaseOrderNo = order.PurchaseOrderNo;
            order.PurchaseStore = record.PurchaseStore;
            order.PurchaseProject = record.PurchaseProject;
            order.CompanyName = record.CompanyName;
            order.CreatedBy= order.CreatedBy;
            order.CreatedDateTime = order.CreatedDateTime;
            order.LastUpdatedBy = "User";
            order.LastUpdatedDateTime = System.DateTime.Now;
            int id = repo.update(order);
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

        [HttpGet("combo")]
        public ActionResult getDropDown()
        {
            List<io.PurchaseOrder> record = JsonConvert.
                DeserializeObject<List<io.PurchaseOrder>>(JsonConvert.SerializeObject(repo.getDropDown()));
            if (record == null) return NotFound();
            return Ok(record);
        }
    }
}
