using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using VSManagement.Models.VS_EMPLOYEE;
using io = VSManagement.IOModels;
using VSManagement.Repository.HRMS;
using System;

namespace VSManagement.Controllers.HRMS
{
    [Route("Department")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        DepartmentRepo repo = new DepartmentRepo(new VS_EMPLOYEEContext());
        [HttpGet]
        public ActionResult getAllList()
        {
            List<io.Department> list =
                JsonConvert.
                DeserializeObject<List<io.Department>>(JsonConvert.SerializeObject(repo.getAllList()));

            return Ok(list);
        }

        [HttpGet("{id}")]
        public ActionResult getById(Guid id)
        {
            io.Department record = JsonConvert.
                DeserializeObject<io.Department>(JsonConvert.SerializeObject(repo.getById(id)));
            if (record == null) return NotFound();
            return Ok(record);
        }

        [HttpPost]
        public ActionResult createRecord([FromBody] io.Department record)
        {
            int id = repo.create(JsonConvert.
                DeserializeObject<Department>(JsonConvert.SerializeObject(record)));
            return Created($"/project/{id}", "Created Successfully.");
        }

        [HttpPut]
        public ActionResult updateRecord([FromForm] io.Department record)
        {
            Department department = repo.getById(record.UniqueId);
            repo._context.Entry(department).State = EntityState.Detached;
            department.CompanyUid = record.CompanyUid;
            department.Name = record.Name;
            department.Code = record.Code;
            department.CompanyCode = record.CompanyCode;
            department.CreatedBy = record.CreatedBy;
            department.ModifiedBy = record.ModifiedBy;
            int id = repo.update(department);
            if (id == 0) return Conflict("Error updating record");
            return Ok(new { status = "success" });
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
