using Microsoft.AspNetCore.Mvc;

namespace ViswaSamudraUI.Controllers.WINGS
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult login()
        {
            return RedirectToRoute("Dashboard/Index");
        }
    }
}
