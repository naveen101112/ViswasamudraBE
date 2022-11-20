using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using ViswaSamudraUI.Models;
using io = VSAssetManagement.IOModels;

namespace ViswaSamudraUI.Providers.Assets
{
	public class TagProvider
	{
        CommonHelper ch = new CommonHelper();
        public IEnumerable<io.Tag> GetAll()
        {
            return (IEnumerable<io.Tag>)ch.GetRequest<io.Tag>("tag");
        }

        public IEnumerable<io.Tag> GetAllTag(io.Tag model = null)
        {
            if (model == null)
                return (IEnumerable<io.Tag>)ch.GetRequest<io.Tag>("tag");
            else
                return (IEnumerable<io.Tag>)ch.GetDetailsRequest<io.Tag>("tag/search", model);
        }

        public ResponseBody Add(io.Tag model = null)
        {
            if (model != null)
            {
                if (model.Guid == Guid.Empty)
                {
                    var res= ch.PostRequest<io.Tag>("tag/Create", model);
                    return res;
                        
                }
                return ch.PostRequest<io.Tag>("tag/Update", model);
            }
            else
                return null;
        }

        public ResponseBody Delete(io.Tag model = null)
        {
            return ch.DeleteRequest<io.Tag>("Tag/Delete", model);
        }
        

        public IEnumerable<io.Tag> GetDropDown()
        {
            return (IEnumerable<io.Tag>)ch.GetRequest<io.Tag>("tag/combo");
        }

        public IEnumerable<io.Tag> GetDropDowncombomap()
        {
            return (IEnumerable<io.Tag>)ch.GetRequest<io.Tag>("tag/combomap");
        }

        public List<SelectListItem> GetSelectList(string SelectedValue = null)
        {
            SelectListItem selListItem = new SelectListItem() { Value = "", Text = "" };
            List<SelectListItem> newList = new List<SelectListItem>();
            newList.Add(selListItem);

            foreach (var x in GetDropDown().Select(i => new { i.Name, i.Code, i.Guid }))
            {
                if (SelectedValue != null && x.Guid.ToString() == SelectedValue)
                    selListItem = new SelectListItem() { Value = x.Guid.ToString(), Text = x.Name, Selected = true };
                else
                    selListItem = new SelectListItem() { Value = x.Guid.ToString(), Text = x.Name };

                newList.Add(selListItem);
            }
            return newList;
        }

        public List<SelectListItem> GetSelectListWithoutMapped(string SelectedValue = null)
        {
            SelectListItem selListItem = new SelectListItem() { Value = "", Text = "" };
            List<SelectListItem> newList = new List<SelectListItem>();
            newList.Add(selListItem);

            foreach (var x in GetDropDowncombomap().Select(i => new { i.Name, i.Code, i.Guid }))
            {
                if (SelectedValue != null && x.Guid.ToString() == SelectedValue)
                    selListItem = new SelectListItem() { Value = x.Guid.ToString(), Text = x.Name, Selected = true };
                else
                    selListItem = new SelectListItem() { Value = x.Guid.ToString(), Text = x.Name };

                newList.Add(selListItem);
            }
            return newList;
        }
    }
}
