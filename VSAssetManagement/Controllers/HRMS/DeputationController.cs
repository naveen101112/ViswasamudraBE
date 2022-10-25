using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using VSManagement.Models.VS_EMPLOYEE;
using io = VSManagement.IOModels;
using VSManagement.Repository.HRMS;
using System;

namespace VSManagement.Controllers.HRMS
{
    [Route("Deputation")]
    [ApiController]
    public class DeputationController : ControllerBase
    {
        DeputationRepo repo = new DeputationRepo(new VS_EMPLOYEEContext());

        [HttpGet]
        public ActionResult getAllList()
        {
            List<io.Deputation> list =
                JsonConvert.
                DeserializeObject<List<io.Deputation>>(JsonConvert.SerializeObject(repo.getAllList()));

            return Ok(list);
        }

        [HttpGet("{id}")]
        public ActionResult getById(Guid id)
        {
            var record = repo.getById(id);
            if (record == null) return NotFound();
            return Ok(record);
        }

        [HttpPost]
        public ActionResult createRecord([FromBody] io.Deputation record)
        {
            int id = repo.create(JsonConvert.
                DeserializeObject<Deputation>(JsonConvert.SerializeObject(record)));
            return Created($"/project/{id}", "Created Successfully.");
        }

        [HttpPut]
        public ActionResult updateRecord([FromForm] io.Deputation record)
        {
            Deputation order = repo.getById(record.UniqueId);
            order.DepartmentUid = record.DepartmentUid;
            order.Name = record.Name;
            order.Code = record.Code;
            order.CreatedBy = record.CreatedBy;
            order.ModifiedBy = record.ModifiedBy;
            int id = repo.update(order);
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
