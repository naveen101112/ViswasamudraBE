using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using VSManagement.Models.VS_EMPLOYEE;
using io = VSManagement.IOModels;
using VSManagement.Repository.HRMS;
using System;

namespace VSManagement.Controllers.HRMS
{
    [Route("Company")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        CompanyRepo repo = new CompanyRepo(new VS_EMPLOYEEContext());
        [HttpGet]
        public ActionResult getAllList()
        {
            List<io.Company> list =
                JsonConvert.
                DeserializeObject<List<io.Company>>(JsonConvert.SerializeObject(repo.getAllList()));

            return Ok(list);
        }

        [HttpGet("{id}")]
        public ActionResult getById(Guid id)
        {
            io.Company record = JsonConvert.
                DeserializeObject<io.Company>(JsonConvert.SerializeObject(repo.getById(id)));
            if (record == null) return NotFound();
            return Ok(record);
        }

        [HttpPost]
        public ActionResult createRecord([FromBody] io.Company record)
        {
            int id = repo.create(JsonConvert.
                DeserializeObject<Company>(JsonConvert.SerializeObject(record)));
            return Created($"/company/{id}", "Created Successfully.");
        }

        [HttpPut]
        public ActionResult updateRecord([FromBody] io.Company record)
        {
            Company company = repo.getById(record.UniqueId);
            company.Name = record.Name;
            company.Code = record.Code;
            company.CreatedBy = record.CreatedBy;
            company.ModifiedBy = record.ModifiedBy;
            int id = repo.update(company);
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
