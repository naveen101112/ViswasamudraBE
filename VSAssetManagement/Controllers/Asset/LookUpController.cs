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
            try
            {
                record.RecordStatus = 1;
                var model = JsonConvert.
                    DeserializeObject<LookupType>(JsonConvert.SerializeObject(record));
                List<io.LookupType> list =
                JsonConvert.DeserializeObject<List<io.LookupType>>(JsonConvert.SerializeObject(repo.searchListQuery(model)));

                return Ok(list);
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        [HttpPost("Create")]
        public ActionResult createRecord([FromBody] io.LookupType record)
        {
            record.RecordStatus= 1;
            Guid id = repo.create(JsonConvert.
                DeserializeObject<LookupType>(JsonConvert.SerializeObject(record)));
            return Created($"/lookup/{id}", "Created Successfully.");
        }

        [HttpPost("Update")]
        public ActionResult updateRecord([FromBody] io.LookupType request)
        {
            LookupType record = repo.getByGuid(request.Guid);
            record.Code = request.Code;
            record.Name = request.Name;
            record.RecordStatus = record.RecordStatus;
            if(record.CreatedDateTime!=null)
                request.CreatedDateTime = record.CreatedDateTime;
            record.LastUpdatedDateTime = DateTime.Now;
            record.LastUpdatedBy = "System";
            int count = repo.update(record);
            if (count == 0) return Conflict("Error updating record");
            return Ok("Updated successfully");
        }

        [HttpPost("Delete")]
        public ActionResult deleteRecord([FromBody] io.LookupType request)
        {
            int count = repo.delete(request);
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
            record.RecordStatus = 1;
            var model = JsonConvert.
                DeserializeObject<io.LookupTypeValue>(JsonConvert.SerializeObject(record));
            List<io.LookupTypeValue> list =
            JsonConvert.DeserializeObject<List<io.LookupTypeValue>>(JsonConvert.SerializeObject(valueRepo.searchListQuery(model)));

            return Ok(list);
        }

        [HttpPost("value/Create")]
        public ActionResult createRecord([FromBody] io.LookupTypeValue record)
        {
            record.RecordStatus = 1;
            Guid id = valueRepo.create(JsonConvert.
                DeserializeObject<LookupTypeValue>(JsonConvert.SerializeObject(record)));
            return Created($"/lookup/{id}", "Created Successfully.");
        }

        [HttpPost("value/Update")]
        public ActionResult updateRecord([FromBody] io.LookupTypeValue request)
        {
            LookupTypeValue record = valueRepo.getByGuid(request.Guid);
            record.Code = request.Code;
            record.Name = request.Name;
            record.LookupTypeId= request.LookupTypeId;
            record.RecordStatus = record.RecordStatus;
            if (record.CreatedDateTime != null)
                request.CreatedDateTime = record.CreatedDateTime;
            record.LastUpdatedDateTime = DateTime.Now;
            record.LastUpdatedBy = "System";
            int count = repo.update(record);
            if (count == 0) return Conflict("Error updating record");
            return Ok("Updated successfully");
        }

        [HttpPost("value/Delete")]
        public ActionResult deleteValueRecord([FromBody] io.LookupTypeValue request)
        {
            int count = valueRepo.delete(request);
            //if (id == 0) return Conflict("Error deleting record");
            return Ok("Deleted successfully");
        }
        #endregion
    }
}
