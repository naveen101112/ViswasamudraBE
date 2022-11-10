﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using ViswaSamudraUI.Models;
using ViswaSamudraUI.Providers.Assets;
using VSAssetManagement.IOModels;

namespace ViswaSamudraUI.Controllers.WINGS
{
    public class LookUpController : Controller
    {
        LookUpProvider lookUpProvider = new LookUpProvider();        
        LookupType lookupType = new LookupType();
        public IActionResult Index()
        {
            IEnumerable<LookupType> list = LookUpList(lookupType);
            return View(list);
        }

        public IActionResult LoadGrid()
        {
            IEnumerable<LookupType> list = LookUpList(lookupType);
            return View(list);
        }

        public IEnumerable<LookupType> LookUpList(LookupType flookupType)
        {
            return lookUpProvider.GetLookupData(flookupType);
        }

        public IActionResult lookupops(Guid guid= new Guid())
        {
            lookupType.Guid = guid;
            IEnumerable<LookupType> list=LookUpList(lookupType);
            return PartialView(list.FirstOrDefault());
        }

        public ActionResult LookUpTypeModification(LookupType model)
        {
            return Ok(lookUpProvider.Add(model));            
        }
    }
}