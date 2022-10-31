using System;

namespace VSAssetManagement.IOModels
{
    public class BatchSearch : Batch
    {
        
        public string PurchaseOrderNo { get; set; }
        public DateTime? PurchaseOrderDate { get; set; }
    }
}
