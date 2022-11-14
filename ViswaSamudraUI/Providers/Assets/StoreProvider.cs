using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using ViswaSamudraUI.Models;
using io = VSAssetManagement.IOModels;

namespace ViswaSamudraUI.Providers.Assets
{
	public class StoreProvider
    {
        CommonHelper ch = new CommonHelper();

        public IEnumerable<io.Store> GetAllStore(io.Store model = null)
        {
            if (model == null)
                return (IEnumerable<io.Store>)ch.GetRequest<io.Store>("Store");
            else
                return (IEnumerable<io.Store>)ch.GetDetailsRequest<io.Store>("Store/search", model);
        }
        public IEnumerable<io.Store> GetAll()
        {
            return (IEnumerable<io.Store>)ch.GetRequest<io.Store>("Store");
        }

        public IEnumerable<io.Store> GetDropDown(int id)
        {
            return (IEnumerable<io.Store>)ch.GetRequest<io.Store>("Store/combo?id="+id);
        }

        public List<SelectListItem> GetSelectList(int id, string SelectedValue = null)
        {
            SelectListItem selListItem = new SelectListItem() { Value = "", Text = "" };
            List<SelectListItem> newList = new List<SelectListItem>();
            newList.Add(selListItem);

            foreach (var x in GetDropDown(id).Select(i => new { i.Name, i.Code, i.Guid }))
            {
                if (SelectedValue != null && x.Guid.ToString() == SelectedValue)
                    selListItem = new SelectListItem() { Value = x.Guid.ToString(), Text = x.Name, Selected = true };
                else
                    selListItem = new SelectListItem() { Value = x.Guid.ToString(), Text = x.Name };

                newList.Add(selListItem);
            }
            return newList;
        }

        public ResponseBody Add(io.Store model = null)
        {
            if (model != null)
            {
                if (model.Guid == Guid.Empty)
                {
                    return ch.PostRequest<io.Store>("Store/Create", model);
                }
                return ch.PostRequest<io.Store>("Store/Update", model);
            }
            else
                return null;
        }

        public ResponseBody Delete(io.Store model = null)
        {
            return ch.DeleteRequest<io.Store>("Store/Delete", model);
        }
    }
}
