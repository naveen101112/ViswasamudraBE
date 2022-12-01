using Microsoft.AspNetCore.Mvc;
using VSManagement.IOModels;

namespace ViswaSamudraUI.Controllers.WINGS
{
    public class UnauthorizedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
