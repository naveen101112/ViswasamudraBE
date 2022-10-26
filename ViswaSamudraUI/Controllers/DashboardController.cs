using Microsoft.AspNetCore.Mvc;

namespace ViswaSamudraUI.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
