using System;

namespace VSAssetManagement.IOModels
{
    public class LookupTypeValue
    {
        public int Id { get; set; }
        public Guid LookupTypeId { get; set; }
        public string LookupTypeName { get; set; }
        public string LookupTypeCode { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDateTime { get; set; }
        public int? RecordStatus { get; set; }
        public Guid Guid { get; set; }
    }
}
