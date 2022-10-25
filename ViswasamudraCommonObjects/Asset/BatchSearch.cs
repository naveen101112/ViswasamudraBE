using System;

namespace VSAssetManagement.IOModels
{
    public class BatchSearch
    {
        public int Id { get; set; }
        public string BatchNo { get; set; }
        public string BatchName { get; set; }
        public int? Quantity { get; set; }
        public string AssetType { get; set; }
        public string AssetSize { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDateTime { get; set; }
        public int RecordStatus { get; set; }
        public Guid Guid { get; set; }
        public Guid PurchaseBatchMasterGuid { get; set; }
        public string PurchaseOrderNo { get; set; }
        public DateTime? PurchaseOrderDate { get; set; }
        public string ReceivedBy { get; set; }
        public DateTime? ReceivedDate { get; set; }
    }
}
