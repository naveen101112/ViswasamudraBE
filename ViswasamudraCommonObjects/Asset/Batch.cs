using System;

namespace VSAssetManagement.IOModels
{
    public class Batch
    {
        public int Id { get; set; }
        public string BatchNo { get; set; }
        public string BatchDescription { get; set; }
        public int BatchQuantity { get; set; }
        public Guid StructureType { get; set; }
        public Guid StructureSubType { get; set; }
        public Guid AssetType { get; set; }
        public Guid AssetSpecification { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDateTime { get; set; }
        public int RecordStatus { get; set; }
        public Guid Guid { get; set; }
        public Guid PurchaseOrderId { get; set; }
        public Guid Uom { get; set; }
        public int UseFrequency { get; set; }
        public Guid UsageUom { get; set; }
        public string BatchStatus { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; } = DateTime.Now;
        public string ReceivedBy { get; set; }
        public DateTime ReceivedDate { get; set; } = DateTime.Now;
    }
}
