using System;

namespace VSAssetManagement.IOModels
{
    public class BatchSearch : Batch
    {
        public string PurchaseOrderNo { get; set; }
        public Guid PurchaseStore { get; set; }
        public Guid PurchaseProject { get; set; }
        public string CompanyName { get; set; }
        public DateTime PurchaseOrderDate { get; set; } = DateTime.Now;
    }
}
