using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViswaSamudraUI.Providers.Assets;
using VSManagement.IOModels;
using ViswaSamudraUI.Models;

namespace ViswaSamudraUI.Controllers.WINGS
{
    public class EmpMigrateController : Controller
    {
        EmpMigrateProvider provider = new EmpMigrateProvider();
        public IActionResult Index()
        {
            IEnumerable<TblMigrationEmployee> list = provider.GetAll().OrderByDescending(l=>l.Id);
            return View(list);
        }
    }
}
