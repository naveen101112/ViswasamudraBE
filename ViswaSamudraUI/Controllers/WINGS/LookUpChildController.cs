using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using ViswaSamudraUI.Providers.Assets;
using VSAssetManagement.IOModels;

namespace ViswaSamudraUI.Controllers.WINGS
{
    public class LookUpChildController : Controller
    {
        LookUpProvider lookUpProvider = new LookUpProvider();
        LookupTypeValue lookupTypevalue = new LookupTypeValue();
        LookupType lookupType = new LookupType();

        public IActionResult Index(Guid guid)
        {            
            lookupTypevalue.LookupTypeId = guid;
            lookupType.Guid = guid;
            IEnumerable<LookupTypeValue> list = LookUpList(lookupTypevalue);
            ViewBag.lookupname=lookUpProvider.GetLookupData(lookupType).Select(x=>x.Name).FirstOrDefault();
            ViewBag.lookupguid = lookUpProvider.GetLookupData(lookupType).Select(x => x.Guid).FirstOrDefault();

            return View(list);           
        }

        public ActionResult LookUpTypeModification(LookupTypeValue model)
        {
            return Ok(lookUpProvider.Add(model));
        }

        public IEnumerable<LookupTypeValue> LookUpList(LookupTypeValue flookupType)
        {
            return lookUpProvider.GetLookupValue(flookupType);
        }
    }
}
