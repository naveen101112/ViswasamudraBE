using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViswaSamudraUI.Providers.Assets;
using VSAssetManagement.IOModels;

namespace ViswaSamudraUI.Controllers.WINGS
{
    public class ProjectController : Controller
    {
        ProjectProvider provider = new ProjectProvider();
        public IActionResult Index()
        {
            IEnumerable<Project> list = provider.GetAll();
            return View(list);
        }


    }
}
