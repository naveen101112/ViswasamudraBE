using System;
using System.Collections.Generic;
using io = VSAssetManagement.IOModels;

namespace ViswaSamudraUI.Providers.Assets
{
	public class BatchProvider
	{
        CommonHelper ch = new CommonHelper();
        public IEnumerable<io.BatchSearch> GetAll()
        {
            return (IEnumerable<io.BatchSearch>)ch.GetRequest<io.BatchSearch>("batch/all");
        }
        public IEnumerable<io.BatchSearch> GetAllBatches(io.BatchSearch BatchModel)
        {
            return (IEnumerable<io.BatchSearch>)ch.GetDetailsRequest<io.BatchSearch>("batch/search", BatchModel);
        }

        public string BatchModifications(io.Batch BatchModel = null)
        {
            if (BatchModel != null)
            {
                if (BatchModel.Guid == Guid.Empty)
                {
                    return ch.PostRequest<io.Batch>("batch/Create", BatchModel);
                }
                return ch.PostRequest<io.Batch>("batch/Update", BatchModel);
            }
            else
                return null;
        }
    }
}
