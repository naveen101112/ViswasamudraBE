using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using VSManagement.Models.VISWASAMUDRA;
using io = VSAssetManagement.IOModels;
using VSManagement.Repository.AssetManagement;
using System;

namespace VSManagement.Controllers.AssetManagement
{
    [Route("lookup")]
    [ApiController]
    public class LookUpController : ControllerBase
    {
        LookUpRepo repo = new LookUpRepo(new VISWASAMUDRAContext());
        LookUpValueRepo valueRepo = new LookUpValueRepo(new VISWASAMUDRAContext());

        [HttpGet("{code}")]
        public ActionResult getdropdownlist(string code)
        {
            return Ok(valueRepo.getLookUpDropDownByCode(code));
            List<io.LookupTypeValue> list =
                JsonConvert.
                DeserializeObject<List<io.LookupTypeValue>>(JsonConvert.SerializeObject(valueRepo.getLookUpDropDownByCode(code)));
            return Ok(list);
        }

        #region lookUp
        [HttpGet]
        public ActionResult getAllList()
        {
            List<io.LookupType> list =
                JsonConvert.
                DeserializeObject<List<io.LookupType>>(JsonConvert.SerializeObject(repo.getAllList()));
            return Ok(list);
        }

        [HttpPost("search")]
        public ActionResult Search([FromBody] io.LookupType record)
        {
            var model = JsonConvert.
                DeserializeObject<LookupType>(JsonConvert.SerializeObject(record));
            List<io.LookupType> list =
            JsonConvert.DeserializeObject<List<io.LookupType>>(JsonConvert.SerializeObject(repo.searchListQuery(model)));

            return Ok(list);
        }

        [HttpPost]
        public ActionResult createRecord([FromBody] io.LookupType record)
        {
            Guid id = repo.create(JsonConvert.
                DeserializeObject<LookupType>(JsonConvert.SerializeObject(record)));
            return Created($"/lookup/{id}", "Created Successfully.");
        }

        [HttpPut]
        public ActionResult updateRecord([FromBody] io.LookupType record)
        {
            int id = repo.update(JsonConvert.
                DeserializeObject<LookupType>(JsonConvert.SerializeObject(record)));
            if (id == 0) return Conflict("Error updating record");
            return Ok("Updated successfully");
        }

        [HttpDelete("{id}")]
        public ActionResult deleteRecord(Guid id)
        {
            int count = repo.delete(id);
            //if (id == 0) return Conflict("Error deleting record");
            return Ok("Deleted successfully");
        }
        #endregion

        #region lookUpValue
        [HttpGet("value")]
        public ActionResult getAllValueList()
        {
            List<io.LookupTypeValue> list =
                JsonConvert.
                DeserializeObject<List<io.LookupTypeValue>>(JsonConvert.SerializeObject(valueRepo.getAllList()));
            return Ok(list);
        }

        [HttpPost("value/search")]
        public ActionResult ValueSearch([FromBody] io.LookupTypeValue record)
        {
            var model = JsonConvert.
                DeserializeObject<LookupTypeValue>(JsonConvert.SerializeObject(record));
            List<io.LookupTypeValue> list =
            JsonConvert.DeserializeObject<List<io.LookupTypeValue>>(JsonConvert.SerializeObject(valueRepo.searchListQuery(model)));

            return Ok(list);
        }

        [HttpPost("value")]
        public ActionResult createValueRecord([FromBody] io.LookupTypeValue record)
        {
            Guid id = valueRepo.create(JsonConvert.
                DeserializeObject<LookupTypeValue>(JsonConvert.SerializeObject(record)));
            return Created($"/lookup/value/{id}", "Created Successfully.");
        }

        [HttpPut("value")]
        public ActionResult updateValueRecord([FromBody] io.LookupTypeValue record)
        {
            int id = valueRepo.update(JsonConvert.
                DeserializeObject<LookupTypeValue>(JsonConvert.SerializeObject(record)));
            if (id == 0) return Conflict("Error updating record");
            return Ok("Updated successfully");
        }

        [HttpDelete("value/{id}")]
        public ActionResult deleteValueRecord(Guid id)
        {
            int count = valueRepo.delete(id);
            //if (id == 0) return Conflict("Error deleting record");
            return Ok("Deleted successfully");
        }
        #endregion
    }
}
