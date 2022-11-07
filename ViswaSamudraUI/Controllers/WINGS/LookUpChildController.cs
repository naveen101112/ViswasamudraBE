using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
            IEnumerable<LookupTypeValue> list = LookUpList(lookupTypevalue);
            return View(list);           
        }

        public IEnumerable<LookupTypeValue> LookUpList(LookupTypeValue flookupType)
        {
            return lookUpProvider.GetLookupValue(flookupType);
        }
    }
}
