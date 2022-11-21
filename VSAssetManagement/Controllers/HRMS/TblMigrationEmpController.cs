using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using VSManagement.Models.VS_EMPLOYEE;
using io = VSManagement.IOModels;
using VSManagement.Repository.HRMS;
using System;

namespace VSManagement.Controllers.HRMS
{
    [Route("migrate-emp")]
    [ApiController]
    public class TblMigrationEmpController : ControllerBase
    {
        TblMigrationEmpRepo repo = new TblMigrationEmpRepo(new VS_EMPLOYEEContext());
        [HttpGet]
        public ActionResult getAllList()
        {
            List<io.TblMigrationEmployee> list =
                JsonConvert.
                DeserializeObject<List<io.TblMigrationEmployee>>(JsonConvert.SerializeObject(repo.getAllList()));

            return Ok(list);
        }
    }
}
