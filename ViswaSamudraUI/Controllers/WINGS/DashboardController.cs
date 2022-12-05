using Microsoft.AspNetCore.Mvc;
using System;
using VSManagement.IOModels;

namespace ViswaSamudraUI.Controllers.WINGS
{
    public class DashboardController : Controller
    {
        [HttpGet]
        public IActionResult Index([FromQuery] string authKey)
        {
            try
            {
                if (!string.IsNullOrEmpty(authKey))
                {
                    var base64EncodedBytes = System.Convert.FromBase64String(authKey);
                    authKey = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
                }
                if (string.IsNullOrEmpty(authKey) || authKey != "loggedin")
                {
                    return Redirect("../unauthorized");
                }
                return View();
            } catch(Exception e)
            {
                return Redirect("../unauthorized");
            }
        }
    }
}
