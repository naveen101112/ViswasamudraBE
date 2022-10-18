using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using VSManagement.Models.VS_EMPLOYEE;
using io = VSManagement.IOModels;
using VSManagement.Repository.HRMS;
using System;

namespace VSManagement.Controllers.HRMS
{
    [Route("Salutation")]
    [ApiController]
    public class SalutationController : ControllerBase
    {
        SalutationRepo repo = new SalutationRepo(new VS_EMPLOYEEContext());
        [HttpGet]
        public ActionResult getAllList()
        {
            List<io.Salutation> list =
                JsonConvert.
                DeserializeObject<List<io.Salutation>>(JsonConvert.SerializeObject(repo.getAllList()));

            return Ok(list);
        }

        [HttpGet("{id}")]
        public ActionResult getById(Guid id)
        {
            io.Salutation record = JsonConvert.
                DeserializeObject<io.Salutation>(JsonConvert.SerializeObject(repo.getById(id)));
            if (record == null) return NotFound();
            return Ok(record);
        }

        [HttpPost]
        public ActionResult createRecord([FromBody] io.Salutation record)
        {
            int id = repo.create(JsonConvert.
                DeserializeObject<Salutation>(JsonConvert.SerializeObject(record)));
            return Created($"/salutation/{id}", "Created Successfully.");
        }

        [HttpPut]
        public ActionResult updateRecord([FromBody] io.Salutation record)
        {
            Salutation salute = repo.getById(record.UniqueId);
            salute.DepartmentUid = record.DepartmentUid;
            salute.Name = record.Name;
            salute.Code = record.Code;
            salute.CreatedBy = record.CreatedBy;
            salute.ModifiedBy = record.ModifiedBy;
            int id = repo.update(salute);
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
