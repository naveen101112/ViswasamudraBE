using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using io = VSManagement.IOModels;
using VSManagement.Repository.HRMS;
using VSManagement.Models.VS_EMPLOYEE;
using System;

namespace VSManagement.Controllers.HRMS
{
    [ApiController]
    public class BranchController : ControllerBase
    {
        BranchRepo repo = new BranchRepo(new VS_EMPLOYEEContext());

        [HttpGet("Branch")]
        public ActionResult getAllList()
        {
            List<io.Branch> list =
                JsonConvert.
                DeserializeObject<List<io.Branch>>(JsonConvert.SerializeObject(repo.getAllList()));

            return Ok(list);
        }

        [HttpGet("branch/{id}")]
        public ActionResult getById(Guid id)
        {
            Branch record = repo.getById(id);
            if (record == null) return NotFound();
            return Ok(record);
        }

        [HttpPost("branch")]
        public ActionResult createRecord([FromBody] io.Branch record)
        {
            int id = repo.create(JsonConvert.
                DeserializeObject<Branch>(JsonConvert.SerializeObject(record)));
            return Created($"/branch/{id}", "Created Successfully.");
        }

        [HttpPut("branch")]
        public ActionResult updateRecord([FromForm] io.Branch record)
        {
            Branch branch = repo.getById(record.UniqueId);
            branch.Code = record.Code;
            branch.Name = record.Name;
            branch.ZoneUid = record.ZoneUid;
            branch.ZoneCode = record.ZoneCode;
            branch.CreatedBy = record.CreatedBy;
            branch.ModifiedBy = record.ModifiedBy;
            int id = repo.update(branch);
            if (id == 0) return Conflict("Error updating record");
            return Ok(new { status = "success" });
        }

        [HttpDelete("branch/{id}")]
        public ActionResult deleteRecord(Guid id)
        {
            int count = repo.delete(id);
            if (count == 0) return Conflict("Error deleting record");
            return Ok("Deleted successfully");
        }
    }
}
