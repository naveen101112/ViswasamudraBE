using System;
using System.Collections.Generic;
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

        public string Add(io.Store model = null)
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
    }
}
