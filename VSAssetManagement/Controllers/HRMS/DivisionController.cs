using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using VSManagement.Models.VS_EMPLOYEE;
using io = VSManagement.IOModels;
using VSManagement.Repository.HRMS;
using System;

namespace VSManagement.Controllers.HRMS
{
    [Route("Division")]
    [ApiController]
    public class DivisionController : ControllerBase
    {
        DivisionRepo repo = new DivisionRepo(new VS_EMPLOYEEContext());
        [HttpGet]
        public ActionResult getAllList()
        {
            List<io.Division> list =
                JsonConvert.
                DeserializeObject<List<io.Division>>(JsonConvert.SerializeObject(repo.getAllList()));

            return Ok(list);
        }

        [HttpGet("{id}")]
        public ActionResult getById(Guid id)
        {
            io.Division record = JsonConvert.
                DeserializeObject<io.Division>(JsonConvert.SerializeObject(repo.getById(id)));
            if (record == null) return NotFound();
            return Ok(record);
        }

        [HttpPost]
        public ActionResult createRecord([FromBody] io.Division record)
        {
            int id = repo.create(JsonConvert.
                DeserializeObject<Division>(JsonConvert.SerializeObject(record)));
            return Created($"/project/{id}", "Created Successfully.");
        }

        [HttpPut]
        public ActionResult updateRecord([FromBody] io.Division record)
        {
            Division division = repo.getById(record.UniqueId);
            division.Name = record.Name;
            division.CompanyUid = record.CompanyUid;
            division.Code = record.Code;
            division.CompanyCode = record.CompanyCode;
            division.CreatedBy = record.CreatedBy;
            division.ModifiedBy = record.ModifiedBy;
            int id = repo.update(division);
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
