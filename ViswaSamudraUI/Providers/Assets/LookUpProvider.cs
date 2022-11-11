using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using ViswaSamudraUI.Models;
using VSAssetManagement.IOModels;
using io = VSAssetManagement.IOModels;

namespace ViswaSamudraUI.Providers.Assets
{
    public class LookUpProvider
    {
        CommonHelper ch = new CommonHelper();

        public IEnumerable<io.LookupTypeValue> GetAllLookup(string lookUpType)
        {
            return (IEnumerable<io.LookupTypeValue>)ch.GetRequest<io.LookupTypeValue>("lookup/"+ lookUpType);
        }

        public IEnumerable<io.LookupType> GetLookupData(LookupType lookupType)
        {
           
            return (IEnumerable<io.LookupType>)ch.GetDetailsRequest<io.LookupType>("lookup/search", lookupType);
        }


        public IEnumerable<io.LookupTypeValue> GetLookupValue(LookupTypeValue lookupTypevalue)
        {
            
            return (IEnumerable<io.LookupTypeValue>)ch.GetDetailsRequest<io.LookupTypeValue>("lookup/value/search", lookupTypevalue);
        }

        public List<SelectListItem> GetSelectList(string code, string SelectedValue=null)
        {
            SelectListItem selListItem = new SelectListItem() { Value = "", Text = "" };
            List<SelectListItem> newList = new List<SelectListItem>();
            newList.Add(selListItem);

            foreach (var x in GetAllLookup(code).Select(i => new { i.Name, i.Code, i.Guid }))
            {
                if (SelectedValue!=null && x.Guid.ToString() == SelectedValue)
                    selListItem = new SelectListItem() { Value = x.Guid.ToString(), Text = x.Name, Selected=true };
                else
                    selListItem = new SelectListItem() { Value = x.Guid.ToString(), Text = x.Name };

                newList.Add(selListItem);
            }
            return newList;
        }

        public List<SelectListItem> GetLookUpMasterList()
        {
            LookupType ty = new LookupType();
            SelectListItem selListItem = new SelectListItem() { Value = "", Text = "" };
            List<SelectListItem> newList = new List<SelectListItem>();
            newList.Add(selListItem);

            foreach (var x in GetLookupData(ty).Select(i => new { i.Name, i.Code, i.Guid }))
            {
                selListItem = new SelectListItem() { Value = x.Guid.ToString(), Text = x.Name };

                newList.Add(selListItem);
            }           
            return newList;
        }

        //LoadGrid

        public ResponseBody Add(io.LookupType model = null)
        {
            if (model != null)
            {
                if (model.Guid == Guid.Empty)
                {
                    return ch.PostRequest<io.LookupType>("LookUp/Create", model);
                }
                return ch.PostRequest<io.LookupType>("LookUp/Update", model);
            }
            else
                return null;
        }

        public ResponseBody Add(io.LookupTypeValue model = null)
        {
            if (model != null)
            {
                if (model.Guid == Guid.Empty)
                {
                    return ch.PostRequest<io.LookupTypeValue>("LookUp/Value/Create", model);
                }
                return ch.PostRequest<io.LookupTypeValue>("LookUp/Value/Update", model);
            }
            else
                return null;
        }

        public List<SelectListItem> GetUsageUomList()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Value = "", Text = "" });
            list.Add(new SelectListItem() { Value = "Times", Text = "Times" });
            list.Add(new SelectListItem() { Value = "Days", Text = "Days" });
            list.Add(new SelectListItem() { Value = "Years", Text = "Years" });
            return list;
        }

        public List<SelectListItem> GetTempUserData()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Value = "", Text = "" });
            list.Add(new SelectListItem() { Value = "User1", Text = "User1" });
            list.Add(new SelectListItem() { Value = "Admin", Text = "Admin" });
            list.Add(new SelectListItem() { Value = "User2", Text = "User2" });
            return list;
        }

        public List<SelectListItem> GetRequisitionStatusData()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Value = "R", Text = "Requested" });
            list.Add(new SelectListItem() { Value = "A", Text = "Open" });
            list.Add(new SelectListItem() { Value = "O", Text = "Accepted" });
            list.Add(new SelectListItem() { Value = "C", Text = "Closed" });
            return list;
        }
    }

}
