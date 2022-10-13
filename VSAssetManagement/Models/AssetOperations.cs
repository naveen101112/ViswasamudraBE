using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace VSAssetManagement.Models
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
        public string CompanyCode { get; set; }
        public string DeptCode { get; set; }
        public string Initiater { get; set; }

        public virtual Asset AssetGu { get; set; }
        public virtual Tag TagGu { get; set; }
    }
}
