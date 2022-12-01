using Microsoft.AspNetCore.Mvc;
using VSManagement.IOModels;

namespace ViswaSamudraUI.Controllers.WINGS
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult login([FromForm]UserLogin model)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes("loggedin");
            string authKey = string.Empty;

            if(model.UserName == "admin@mail.com" && model.Password == "Password123")
            {
                authKey = System.Convert.ToBase64String(plainTextBytes);
            }
            else
            {
                return Redirect("unuthorized");
            }
            return Redirect("../Dashboard/Index?authKey=" + authKey);
        }
    }
}
