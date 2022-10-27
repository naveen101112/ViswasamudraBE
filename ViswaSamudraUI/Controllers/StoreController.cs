﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViswaSamudraUI.Providers.Assets;
using VSAssetManagement.IOModels;

namespace ViswaSamudraUI.Controllers
{
	public class StoreController : Controller
	{
		StoreProvider provider = new StoreProvider();
        public IActionResult Index()
		{
            IEnumerable<Store> list = provider.GetAll();
            return View(list);
		}

		public async Task<IActionResult> StoreOps(Store ioModel)
        {
            if (ioModel.Guid == Guid.Empty)
            {
                return View(ioModel);
            }
            IEnumerable<Store> list = provider.GetAllStore(ioModel);
            List<string> listTest = new List<string>();
            listTest.Add("A");
            listTest.Add("B");
            listTest.Add("C");
            var l = list.FirstOrDefault();
            l.Regions = listTest;
            return View(l);
        }

        public ActionResult StoreModification(Store model)
        {
            String status = provider.Add(model);
            return Content(status);
        }
    }
}