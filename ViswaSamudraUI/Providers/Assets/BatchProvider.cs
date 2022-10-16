using System.Collections.Generic;
using io = VSAssetManagement.IOModels;

namespace ViswaSamudraUI.Providers.Assets
{
	public class BatchProvider
	{
        CommonHelper ch = new CommonHelper();
        public IEnumerable<io.Batch> GetAllbatchOrder()
        {
            return (IEnumerable<io.Batch>)ch.GetRequest<io.Batch>("Batch");
        }
    }
}
