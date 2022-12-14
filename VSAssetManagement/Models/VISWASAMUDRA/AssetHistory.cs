using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace VSManagement.Models.VISWASAMUDRA
{
    public partial class AssetHistory
    {
        public int Id { get; set; }
        public string AssetStatus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDateTime { get; set; }
        public int RecordStatus { get; set; }
        public Guid AssetGuid { get; set; }
        public Guid Guid { get; set; }
        public Guid TagGuid { get; set; }

        public virtual Asset AssetGu { get; set; }
    }
}
