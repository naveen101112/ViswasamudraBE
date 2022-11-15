using System;
using System.Text.Json.Serialization;

namespace VSAssetManagement.IOModels
{
    public class Asset
    {

        public int Id { get; set; }
        public string AssetCode { get; set; }
        public string AssetName { get; set; }        
        public int? Size { get; set; }
        [JsonPropertyName("Company Name")]
        public string CompanyName { get; set; }
        [JsonPropertyName("Created By")]
        public string CreatedBy { get; set; }
        [JsonPropertyName("Created Date Time")]
        public DateTime CreatedDateTime { get; set; }
        [JsonPropertyName("Last Updated By")]
        public string LastUpdatedBy { get; set; }
        [JsonPropertyName("Last Updated Date Time")]
        public DateTime LastUpdatedDateTime { get; set; }
        [JsonPropertyName("Record Status")]
        public int RecordStatus { get; set; }
        public Guid Guid { get; set; }
        [JsonPropertyName("Project Id")]
        public Guid ProjectCode { get; set; }
        public string BatchNo { get; set; }
        public Guid? AssetStatus { get; set; }
        public string AssetStatusName { get; set; }
        public Guid? TagId { get; set; }
        public Guid? StructureType { get; set; }
        public string StructureName { get; set; }
        public Guid? StructureSubType { get; set; }
        public string StructureSubName { get; set; }
        public Guid? AssetType { get; set; }
        public string AssetTypeName { get; set; }
        public Guid AssetSpecification { get; set; }
        public string AssetSpecificationName { get; set; }
        public string ProjectCodeName { get; set; }
        public Guid Store { get; set; }
        public string StoreName { get; set; }

    }

}