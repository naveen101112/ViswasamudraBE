using System;

namespace VSAssetManagement.IOModels
{
    public partial class AssetHistory
    {
        public int Id { get; set; }
        public int TagId { get; set; }
        public string AssetStatus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDateTime { get; set; }
        public int RecordStatus { get; set; }
        public Guid AssetGuid { get; set; }
        public Guid Guid { get; set; }
    }
}
