using System;

namespace VSAssetManagement.IOModels
{
    public class PurchaseOrder
    {

        public int Id { get; set; }
        public string PurchaseOrderNo { get; set; }
        public DateTime PurchaseOrderDate { get; set; }
        public Guid PurchaseStore { get; set; }
        public Guid PurchaseProject { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDateTime { get; set; }
        public int RecordStatus { get; set; }
        public Guid Guid { get; set; }
        public string CompanyName { get; set; }
        public int Page { get; set; }
    }
}
