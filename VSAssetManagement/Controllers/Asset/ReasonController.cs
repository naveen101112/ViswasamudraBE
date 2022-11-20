﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using VSManagement.Models.VISWASAMUDRA;
using io = VSAssetManagement.IOModels;
using VSManagement.Repository.AssetManagement;
using System;

namespace VSManagement.Controllers.AssetManagement
{
    [Route("reason")]
    [ApiController]
    public class ReasonController : ControllerBase
    {
        ReasonRepo repo = new ReasonRepo(new VISWASAMUDRAContext());
        [HttpGet]
        public ActionResult getAllList()
        {
            io.Reason ReasonModel = new io.Reason();
            ReasonModel.Id = 0;
            List<io.Reason> list =
                JsonConvert.
                DeserializeObject<List<io.Reason>>(JsonConvert.SerializeObject(repo.searchListQuery(ReasonModel)));
            return Ok(list);
        }

        [HttpPost("reasonsearch")]
        public ActionResult Search([FromBody] io.Reason record)
        {
            var ReasonModel = JsonConvert.
                DeserializeObject<io.Reason>(JsonConvert.SerializeObject(record));
            List<io.Reason> list =
            JsonConvert.DeserializeObject<List<io.Reason>>(JsonConvert.SerializeObject(repo.searchListQuery(ReasonModel)));

            return Ok(list);
        }

        [HttpGet("{id}")]
        public ActionResult getById(Guid id)
        {
            io.Reason record = JsonConvert.
                DeserializeObject<io.Reason>(JsonConvert.SerializeObject(repo.getById(id)));
            if (record == null) return NotFound();
            return Ok(record);
        }

        [HttpPost("CreateResult")]
        public ActionResult createRecord([FromBody] io.Reason record)
        {
            int id = repo.createReason(JsonConvert.
                DeserializeObject<Reason>(JsonConvert.SerializeObject(record)));
            if (id == -1) return Problem("Reason Exist");
            return Created($"/reason/{id}", "Created Successfully.");
        }

        [HttpPost("UpdateResult")]
        public ActionResult updateRecord([FromBody] io.Reason record)
        {
            int id = repo.update(JsonConvert.
                DeserializeObject<Reason>(JsonConvert.SerializeObject(record)));
            if (id == 0) return Conflict("Error updating record");
            if (id == -1) return Problem("Reason Exist");
            return Ok("Updated successfully");
        }

        [HttpPost("Delete")]
        public ActionResult deleteRecord([FromBody] io.Reason request)
        {
            int count = repo.delete(request);            
            return Ok("Deleted successfully");
        }
    }
}
