using Microsoft.AspNetCore.Mvc;

namespace ViswaSamudraUI.Controllers.WINGS
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
