using System;

namespace VSAssetManagement.IOModels
{
    public class AssetRequisitionDetails
    {
        public int Id { get; set; }
        public string AssetRequisitionHeader { get; set; }
        public string StructureType { get; set; }
        public string StructureSubType { get; set; }
        public string AssetType { get; set; }
        public string AssetSpecification { get; set; }
        public int? QuantityRequired { get; set; }
        public string Uom { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDateTime { get; set; }
        public int? RecordStatus { get; set; }
        public Guid Guid { get; set; }
    }
}
