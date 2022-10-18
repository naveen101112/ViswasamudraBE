using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using VSManagement.Models.VS_EMPLOYEE;
using io = VSManagement.IOModels;
using VSManagement.Repository.HRMS;
using System;

namespace VSManagement.Controllers.HRMS
{
    [Route("Locations")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        LocationsRepo repo = new LocationsRepo(new VS_EMPLOYEEContext());
        [HttpGet]
        public ActionResult getAllList()
        {
            List<io.Locations> list =
                JsonConvert.
                DeserializeObject<List<io.Locations>>(JsonConvert.SerializeObject(repo.getAllList()));

            return Ok(list);
        }

        [HttpGet("{id}")]
        public ActionResult getById(Guid id)
        {
            io.Locations record = JsonConvert.
                DeserializeObject<io.Locations>(JsonConvert.SerializeObject(repo.getById(id)));
            if (record == null) return NotFound();
            return Ok(record);
        }

        [HttpPost]
        public ActionResult createRecord([FromBody] io.Locations record)
        {
            int id = repo.create(JsonConvert.
                DeserializeObject<Locations>(JsonConvert.SerializeObject(record)));
            return Created($"/project/{id}", "Created Successfully.");
        }

        [HttpPut]
        public ActionResult updateRecord([FromBody] io.Locations record)
        {
            Locations location = repo.getById(record.UniqueId);
            location.BranchUid = record.BranchUid;
            location.Name = record.Name;
            location.Code = record.Code;
            location.BranchCode = record.BranchCode;
            location.CreatedBy = record.CreatedBy;
            location.ModifiedBy = record.ModifiedBy;
            int id = repo.update(location);
            if (id == 0) return Conflict("Error updating record");
            return Ok("Updated successfully");
        }

        [HttpDelete("{id}")]
        public ActionResult deleteRecord(Guid id)
        {
            int count = repo.delete(id);
            if (count == 0) return Conflict("Error deleting record");
            return Ok("Deleted successfully");
        }
    }
}
