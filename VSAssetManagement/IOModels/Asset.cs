using System;

namespace VSAssetManagement.IOModels
{
    public class Asset
    {

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int? Size { get; set; }
        public string CompanyName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDateTime { get; set; }
        public int RecordStatus { get; set; }
        public Guid Guid { get; set; }
        public Guid ProjectGuid { get; set; }
        public Guid StoreGuid { get; set; }
        public Guid BatchGuid { get; set; }
    }

}