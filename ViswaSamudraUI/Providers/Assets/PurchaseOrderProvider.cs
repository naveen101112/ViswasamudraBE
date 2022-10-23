using System;
using System.Collections.Generic;
using io = VSAssetManagement.IOModels;

namespace ViswaSamudraUI.Providers.Assets 
{
    public class PurchaseOrderProvider
    {
        CommonHelper ch = new CommonHelper();
        public IEnumerable<io.PurchaseOrder> GetAllPurchaseOrder(io.PurchaseOrder PoIoModel=null)
        {
            if (PoIoModel == null)
                return (IEnumerable<io.PurchaseOrder>)ch.GetRequest<io.PurchaseOrder>("purchaseOrder");
            else
                return (IEnumerable<io.PurchaseOrder>)ch.GetDetailsRequest<io.PurchaseOrder>("purchaseOrder/posearch", PoIoModel); 
        }
        public string AddPurchaseOrder(io.PurchaseOrder PoIoModel = null)
        {
            if (PoIoModel != null)
            {
                if (PoIoModel.Guid == Guid.Empty)
                {
                    return ch.PostRequest<io.PurchaseOrder>("purchaseOrder/CreatePO", PoIoModel);
                }
                return ch.PostRequest<io.PurchaseOrder>("purchaseOrder/UpdatePo", PoIoModel);
            }
            else
                return null;
        }
    }
}
