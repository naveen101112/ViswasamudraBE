using System;

namespace VSAssetManagement.IOModels
{
    public class BatchSearch : Batch
    {
        public string PurchaseOrderNo { get; set; }
        public string PurchaseStore { get; set; }
        public string PurchaseProject { get; set; }
        public string CompanyName { get; set; }
        public DateTime? PurchaseOrderDate { get; set; }
    }
}
