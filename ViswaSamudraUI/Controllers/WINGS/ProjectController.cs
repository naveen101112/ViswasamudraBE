﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViswaSamudraUI.Providers.Assets;
using VSAssetManagement.IOModels;
using ViswaSamudraUI.Models;

namespace ViswaSamudraUI.Controllers.WINGS
{
    public class ProjectController : Controller
    {
        ProjectProvider provider = new ProjectProvider();
        LookUpProvider lookUpProvider = new LookUpProvider();
        public IActionResult Index()
        {
            IEnumerable<Project> list = provider.GetAll().OrderByDescending(p=>p.Id);
            return View(list);
        }

		public async Task<IActionResult> ProjectOps(Project ProjectIoModel)
        {
            if (ProjectIoModel.Guid == Guid.Empty)
            {
                ViewBag.ProjectType = lookUpProvider.GetSelectList("PTY");
                return View(ProjectIoModel);
            }
            var result = provider.GetAllProject(ProjectIoModel).FirstOrDefault();
            ViewBag.ProjectType = lookUpProvider.GetSelectList("PTY", result.ProjectType);
            return View(result);
        }

        public ActionResult ProjectModification(Project model)
        {
            model.RecordStatus = 1;
            return Ok(provider.Add(model));            
        }

        public ActionResult Delete(Project model)
        {
            ResponseBody res = provider.Delete(model);
            if (res != null && res.Status == true)
            {
                return RedirectToAction("Index");                
            }
            else
            {
                return Ok(res);
            }
        }
    }
}
