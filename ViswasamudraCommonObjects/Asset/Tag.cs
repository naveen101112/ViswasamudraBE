using System;

namespace VSAssetManagement.IOModels
{
    public partial class Tag
    {

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDateTime { get; set; }
        public int RecordStatus { get; set; }
        public Guid Guid { get; set; }
        public string CompanyCode { get; set; }
        public string DeptCode { get; set; }
        public string UserCode { get; set; }
    }
}
