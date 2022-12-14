using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace VSManagement.Models.VISWASAMUDRA
{
    public partial class Batch
    {
        public Batch()
        {
            Asset = new HashSet<Asset>();
        }

        public int Id { get; set; }
        public string BatchNo { get; set; }
        public string BatchDescription { get; set; }
        public int Quantity { get; set; }
        public string AssetType { get; set; }
        public string AssetSpecification { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDateTime { get; set; }
        public int RecordStatus { get; set; }
        public Guid Guid { get; set; }
        public Guid PurchaseBatchMasterGuid { get; set; }
        public string Uom { get; set; }
        public int UseFrequency { get; set; }
        public string UsageUom { get; set; }
        public string BatchStatus { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string ReceivedBy { get; set; }
        public DateTime ReceivedDate { get; set; }

        public virtual PurchaseOrder PurchaseBatchMasterGu { get; set; }
        public virtual ICollection<Asset> Asset { get; set; }
    }
}
