using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace VSAssetManagement.Models
{
    public partial class Batch
    {
        public Batch()
        {
            Asset = new HashSet<Asset>();
        }

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

        public virtual PurchaseOrder PurchaseBatchMasterGu { get; set; }
        public virtual ICollection<Asset> Asset { get; set; }
    }
}
