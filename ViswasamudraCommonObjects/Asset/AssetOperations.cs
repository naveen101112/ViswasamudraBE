using System;

namespace VSAssetManagement.IOModels
{
    public partial class AssetOperations
    {
        public int Id { get; set; }
        public string OperationStatus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string LastUdatedBy { get; set; }
        public DateTime LastUpdatedTime { get; set; }
        public int RecordStatus { get; set; }
        public Guid Guid { get; set; }
        public Guid AssetGuid { get; set; }
        public Guid TagGuid { get; set; }
        public string Company { get; set; }
        public string Department { get; set; }
        public string Initiater { get; set; }
    }
}
