using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using ViswaSamudraUI.Models;
using ViswaSamudraUI.Providers.Assets;
using VSAssetManagement.IOModels;

namespace ViswaSamudraUI.Controllers.WINGS
{
    public class LookUpChildController : Controller
    {
        LookUpProvider lookUpProvider = new LookUpProvider();
        LookupTypeValue lookupTypevalue = new LookupTypeValue();
        LookupType lookupType = new LookupType();
        private Guid guidV;

        public IActionResult Index(Guid guid)
        {           
            if(guid == Guid.Empty)
            {
                guid = (Guid)TempData["GuidValue"];
            }
            lookupTypevalue.LookupTypeId = guid;
            lookupType.Guid = guid;           
            return View(Getdata(lookupTypevalue));           
        }

        public IEnumerable<LookupTypeValue> Getdata(LookupTypeValue lookupTypevalue)
        {
            IEnumerable<LookupTypeValue> list = LookUpList(lookupTypevalue);
            ViewBag.lookupname = lookUpProvider.GetLookupData(lookupType).Select(x => x.Name).FirstOrDefault();
            ViewBag.lookupguid = lookUpProvider.GetLookupData(lookupType).Select(x => x.Guid).FirstOrDefault();
            return list;
        }

        public ActionResult LookUpTypeModification(LookupTypeValue model)
        {
            TempData["GuidValue"] = model.LookupTypeId;
            return Ok(lookUpProvider.Add(model));
        }

        public IEnumerable<LookupTypeValue> LookUpList(LookupTypeValue flookupType)
        {
            return lookUpProvider.GetLookupValue(flookupType);
        }

        public IActionResult Delete(LookupTypeValue model)
        {
            lookupTypevalue.Guid = model.Guid;
            LookupTypeValue ltypeId = LookUpList(lookupTypevalue).FirstOrDefault();
            ResponseBody res = lookUpProvider.DeleteValue(model);
            if (res != null && res.Status == true)
            {
                var GuidValue = (Guid)ltypeId.LookupTypeId;
                TempData["GuidValue"] = GuidValue;
                return RedirectToAction("Index", "LookUpChild");
            }
            else
            {
                return Ok(res);
            }
        }
    }
}
