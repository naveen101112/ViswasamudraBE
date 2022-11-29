using System;

namespace VSAssetManagement.IOModels
{
    public class AssetRequisitionDetails
    {
        public int Id { get; set; }
        public Guid? AssetRequisitionHeader { get; set; }
        public Guid? StructureType { get; set; }
        public string StructureTypeName { get; set; }
        public Guid? StructureSubType { get; set; }
        public string StructureSubTypeName { get; set; }
        public Guid? AssetType { get; set; }
        public string AssetTypeName { get; set; }
        public Guid? AssetSpecification { get; set; }
        public string AssetSpecificationName { get; set; }
        public int? QuantityRequired { get; set; }
        public Guid? Uom { get; set; }
        public string UomName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDateTime { get; set; }
        public int? RecordStatus { get; set; }
        public Guid Guid { get; set; }
    }
}
