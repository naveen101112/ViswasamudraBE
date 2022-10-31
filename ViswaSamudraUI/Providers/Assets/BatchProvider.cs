using System;
using System.Collections.Generic;
using io = VSAssetManagement.IOModels;

namespace ViswaSamudraUI.Providers.Assets
{
	public class BatchProvider
	{
        CommonHelper ch = new CommonHelper();
        public IEnumerable<io.BatchSearch> GetAllBatches(io.BatchSearch BatchModel)
        {
            return (IEnumerable<io.BatchSearch>)ch.GetDetailsRequest<io.BatchSearch>("batch/batchsearch", BatchModel);
        }

        public string BatchModifications(io.Batch BatchModel = null)
        {
            if (BatchModel != null)
            {
                if (BatchModel.Guid == Guid.Empty)
                {
                    return ch.PostRequest<io.Batch>("Batch/CreatePO", BatchModel);
                }
                return ch.PostRequest<io.Batch>("Batch/UpdatePo", BatchModel);
            }
            else
                return null;
        }
    }
}
