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

            foreach (var x in GetAllLookup(code).Select(i => new { i.Name, i.Code }))
            {
                if (SelectedValue!=null && x.Code == SelectedValue)
                    selListItem = new SelectListItem() { Value = x.Code, Text = x.Name, Selected=true };
                else
                    selListItem = new SelectListItem() { Value = x.Code, Text = x.Name };

                newList.Add(selListItem);
            }
            return newList;
        }
    }

}
