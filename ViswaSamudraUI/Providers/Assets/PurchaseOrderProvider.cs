using System.Collections.Generic;
using io = VSAssetManagement.IOModels;

namespace ViswaSamudraUI.Providers.Assets 
{
    public class PurchaseOrderProvider
    {
        CommonHelper ch = new CommonHelper();
        public IEnumerable<io.PurchaseOrder> GetAll()
        {
            return (IEnumerable<io.PurchaseOrder>)ch.GetRequest<io.PurchaseOrder>("purchaseOrder");             
        }
    }
}
