using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using mo = VSManagement.Models.VISWASAMUDRA;
using io = VSAssetManagement.IOModels;
using VSManagement.Repository.AssetManagement;
using ViswasamudraCommonObjects.Util;
using System.Collections;

namespace VSManagement.Controllers.AssetManagement
{
    [Route("assetRequisition")]
    [ApiController]
    public class AssetRequisitionController : Controller
    {
        AssetRequisitionRepo repo = new AssetRequisitionRepo(new mo.VISWASAMUDRAContext());
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("search")]
        public ActionResult Search([FromBody] io.AssetRequisition record)
        {            
            List<io.AssetRequisition> areqList = new List<io.AssetRequisition>(); 
            var AssectReqModel = JsonConvert.
                DeserializeObject<io.AssetRequisitionHeader>(JsonConvert.SerializeObject(record));

            List<io.AssetRequisitionHeader> headers =
            JsonConvert.DeserializeObject<List<io.AssetRequisitionHeader>>(JsonConvert.SerializeObject(repo.searchListQuery(AssectReqModel)));
            foreach (var header in headers)
            {
                io.AssetRequisition areq = new io.AssetRequisition();
                io.AssetRequisitionHeader ah = new io.AssetRequisitionHeader();
                ah.Guid = header.Guid;
                List<io.AssetRequisitionDetails> details =
            JsonConvert.DeserializeObject<List<io.AssetRequisitionDetails>>(JsonConvert.SerializeObject(repo.searchdetailQuery(ah)));
                areq.header = header;
                areq.details = details;
                areqList.Add(areq);
            }

            return Ok(areqList);
        }
        //searchListQuery

        [HttpPost("createAssetRequisition")]
        public ActionResult createRecord([FromBody] io.AssetRequisition record)
        {            
                int id = repo.createAsserReq(JsonConvert.
                    DeserializeObject<mo.AssetRequisition>(JsonConvert.SerializeObject(record)), "I");
                return Created($"/assetRequisition/{id}", "Created Successfully.");
        }

        [HttpPost("updateAssetRequisition")]
        public ActionResult updateRecord([FromBody] io.AssetRequisition record)
        {
            int id = repo.createAsserReq(JsonConvert.
                DeserializeObject<mo.AssetRequisition>(JsonConvert.SerializeObject(record)), "U");
            return Created($"/assetRequisition/{id}", "Created Successfully.");
        }
    }
}
