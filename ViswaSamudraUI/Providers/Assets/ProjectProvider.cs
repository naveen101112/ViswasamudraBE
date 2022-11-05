using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using ViswaSamudraUI.Models;
using io = VSAssetManagement.IOModels;

namespace ViswaSamudraUI.Providers.Assets
{
	public class ProjectProvider
    {
        CommonHelper ch = new CommonHelper();

        public IEnumerable<io.Project> GetAllProject(io.Project model = null)
        {
            if (model == null)
                return (IEnumerable<io.Project>)ch.GetRequest<io.Project>("Project");
            else
                return (IEnumerable<io.Project>)ch.GetDetailsRequest<io.Project>("Project/search", model);
        }
        public IEnumerable<io.Project> GetAll()
        {
            return (IEnumerable<io.Project>)ch.GetRequest<io.Project>("Project");
        }

        public ResponseBody Add(io.Project model = null)
        {
            if (model != null)
            {
                if (model.Guid == Guid.Empty)
                {
                    return ch.PostRequest<io.Project>("Project/Create", model);
                }
                return ch.PostRequest<io.Project>("Project/Update", model);
            }
            else
                return null;
        }

        public IEnumerable<io.Project> GetDropDown()
        {
            return (IEnumerable<io.Project>)ch.GetRequest<io.Project>("Project/combo");
        }

        public List<SelectListItem> GetSelectList(string SelectedValue = null)
        {
            SelectListItem selListItem = new SelectListItem() { Value = "", Text = "" };
            List<SelectListItem> newList = new List<SelectListItem>();
            newList.Add(selListItem);

            foreach (var x in GetDropDown().Select(i => new { i.ProjectName, i.ProjectCode }))
            {
                if (SelectedValue != null && x.ProjectCode == SelectedValue)
                    selListItem = new SelectListItem() { Value = x.ProjectCode, Text = x.ProjectName, Selected = true };
                else
                    selListItem = new SelectListItem() { Value = x.ProjectCode, Text = x.ProjectName };

                newList.Add(selListItem);
            }
            return newList;
        }
    }
}
