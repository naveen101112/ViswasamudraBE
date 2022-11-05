using System;
using System.Collections.Generic;
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
                    return ch.PostRequest<io.Tag>("tag/Create", model);
                }
                return ch.PostRequest<io.Tag>("tag/Update", model);
            }
            else
                return null;
        }
    }
}
