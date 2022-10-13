using System;
using System.Text.Json.Serialization;

namespace VSAssetManagement.IOModels
{
    public class Asset
    {

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
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
        public Guid ProjectGuid { get; set; }
        [JsonPropertyName("Store Id")]
        public Guid StoreGuid { get; set; }
        [JsonPropertyName("Batch Id")]
        public Guid BatchGuid { get; set; }
    }

}