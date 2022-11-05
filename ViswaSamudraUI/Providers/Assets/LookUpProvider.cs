using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Linq;
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
    }

}
