using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using VSManagement.Models.VS_EMPLOYEE;
using io = VSManagement.IOModels;
using VSManagement.Repository.HRMS;
using System;

namespace VSManagement.Controllers.HRMS
{
    [Route("User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserLoginRepo repo = new UserLoginRepo(new VS_EMPLOYEEContext());

        [HttpPost]
        public ActionResult createRecord([FromBody] io.UserLogin record)
        {
            return Ok(repo.login(record));
        }

        [HttpPost("Login")]
        public ActionResult validateUser([FromBody] io.UserLogin record)
        {
            return Ok(repo.login(record));
        }
    }
}
