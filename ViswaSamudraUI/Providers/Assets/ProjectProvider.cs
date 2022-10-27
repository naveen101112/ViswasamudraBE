using System;
using System.Collections.Generic;
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

        public string Add(io.Project model = null)
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
    }
}
