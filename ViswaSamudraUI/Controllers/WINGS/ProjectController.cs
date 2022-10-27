using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

		public async Task<IActionResult> ProjectOps(Project ProjectIoModel)
        {
            if (ProjectIoModel.Guid == Guid.Empty)
            {
                return View(ProjectIoModel);
            }
            IEnumerable<Project> poList = provider.GetAllProject(ProjectIoModel);
            return View(poList.FirstOrDefault());
        }

        public ActionResult ProjectModification(Project model)
        {
            String status = provider.Add(model);
            return Content(status);
        }
    }
}
