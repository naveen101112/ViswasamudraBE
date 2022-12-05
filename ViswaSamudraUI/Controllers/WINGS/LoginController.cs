using Microsoft.AspNetCore.Mvc;
using ViswaSamudraUI.Providers.HRMS;
using VSManagement.IOModels;

namespace ViswaSamudraUI.Controllers.WINGS
{
    public class LoginController : Controller
    {
        UserProvider provider = new UserProvider();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RedirectDashboard()
        {
            return RedirectToAction("Index", "Dashboard");
        }

        [HttpPost]
        public IActionResult authenticate([FromForm] UserLogin model)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(model.UserName + "~success");
            string authKey = string.Empty;
            authKey = System.Convert.ToBase64String(plainTextBytes);

            ResponseBody response = provider.Login(model);

            if (response.Status) {
                response.UserName = authKey;
                return Ok(response);
            }
            return Redirect("unuthorized");
        }
    }
}
