﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using VSManagement.Models.VISWASAMUDRA;
using io = VSAssetManagement.IOModels;
using VSManagement.Repository.AssetManagement;
using System;
using Microsoft.AspNetCore.Http;

namespace VSManagement.Controllers.AssetManagement
{
    [Route("batch")]
    [ApiController]
    public class PurchaseBatchController : ControllerBase
    {
        BatchRepo repo = new BatchRepo(new VISWASAMUDRAContext());
        PurchaseOrderRepo porepo= new PurchaseOrderRepo(new VISWASAMUDRAContext());

        [HttpGet]
        public ActionResult getAllList()
        {
            List<io.Batch> list =
                JsonConvert.
                DeserializeObject<List<io.Batch>>(JsonConvert.SerializeObject(repo.getAllList()));

            return Ok(list);
        }

        [HttpPost("search")]
        public ActionResult Search([FromBody] io.BatchSearch record)
        {
            var BatchModel = JsonConvert.
                DeserializeObject<io.BatchSearch>(JsonConvert.SerializeObject(record));
            List<io.BatchSearch> list =
            JsonConvert.DeserializeObject<List<io.BatchSearch>>(JsonConvert.SerializeObject(repo.searchListQuery(BatchModel)));

            return Ok(list);
        }

        [HttpGet("all")]
        public ActionResult GetAll()
        {
            List<io.BatchSearch> list =
            JsonConvert.DeserializeObject<List<io.BatchSearch>>(JsonConvert.SerializeObject(repo.GetAllWithPO()));
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

        [HttpPost("Create")]
        public ActionResult createRecord([FromBody] io.Batch record)
        {
            try
            {
                int id = repo.create(JsonConvert.
                    DeserializeObject<Batch>(JsonConvert.SerializeObject(record)));                
                if (id == 0) return Conflict("Error while creating batch.");
                return Created($"/batch/{id}", "Created Successfully.");
            }catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"Error while creating batch");
            }
        }

        [HttpPost("Update")]
        public ActionResult updateRecord([FromBody] io.Batch request)
        {
            Batch record = JsonConvert.DeserializeObject<Batch>(JsonConvert.SerializeObject(request));
            Batch batch = repo.getById(record.Guid);
            batch.BatchDescription = record.BatchDescription;
            batch.BatchNo = record.BatchNo;
            batch.AssetSpecification = record.AssetSpecification;
            batch.AssetType = record.AssetType;
            batch.PurchaseOrderId = record.PurchaseOrderId;
            batch.BatchQuantity = record.BatchQuantity;
            batch.BatchStatus = record.BatchStatus;
            batch.InvoiceNo= record.InvoiceNo;
            batch.InvoiceDate = record.InvoiceDate;
            batch.ReceivedDate = record.ReceivedDate;
            batch.ReceivedBy = record.ReceivedBy;
            batch.StructureType = record.StructureType;
            batch.UseFrequency = record.UseFrequency;
            batch.StructureSubType = record.StructureSubType;
            batch.UsageUom = record.UsageUom;
            batch.Uom = record.Uom;
            batch.LastUpdatedBy = string.IsNullOrEmpty(record.LastUpdatedBy) ? "SYSTEM" : record.LastUpdatedBy;
            batch.LastUpdatedDateTime = DateTime.Now;
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
