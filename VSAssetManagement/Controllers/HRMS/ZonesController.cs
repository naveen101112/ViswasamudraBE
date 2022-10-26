using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using VSManagement.Models.VS_EMPLOYEE;
using io = VSManagement.IOModels;
using VSManagement.Repository.HRMS;
using System;

namespace VSManagement.Controllers.HRMS
{
    [Route("Zones")]
    [ApiController]
    public class ZonesController : ControllerBase
    {
        ZonesRepo repo = new ZonesRepo(new VS_EMPLOYEEContext());
        [HttpGet]
        public ActionResult getAllList()
        {
            List<io.Zones> list =
                JsonConvert.
                DeserializeObject<List<io.Zones>>(JsonConvert.SerializeObject(repo.getAllList()));

            return Ok(list);
        }

        [HttpGet("{id}")]
        public ActionResult getById(Guid id)
        {
            io.Zones record = JsonConvert.
                DeserializeObject<io.Zones>(JsonConvert.SerializeObject(repo.getById(id)));
            if (record == null) return NotFound();
            return Ok(record);
        }

        [HttpPost]
        public ActionResult createRecord([FromBody] io.Zones record)
        {
            int id = repo.create(JsonConvert.
                DeserializeObject<Zones>(JsonConvert.SerializeObject(record)));
            return Created($"/zones/{id}", "Created Successfully.");
        }

        [HttpPut]
        public ActionResult updateRecord([FromBody] io.Zones record)
        {
            Zones zone = repo.getById(record.UniqueId);
            zone.DivisionUid = record.DivisionUid;
            zone.Name = record.Name;
            zone.Code = record.Code;
            zone.DivisionCode = record.DivisionCode;
            zone.CreatedBy = record.CreatedBy;
            zone.ModifiedBy = record.ModifiedBy;
            int id = repo.update(zone);
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
