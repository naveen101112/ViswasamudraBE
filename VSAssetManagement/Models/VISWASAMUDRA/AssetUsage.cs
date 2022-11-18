using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace VSManagement.Models.VISWASAMUDRA
{
    public partial class AssetUsage
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public Guid AssetId { get; set; }
        public int? UseFrequency { get; set; }
        public Guid? Uom { get; set; }
        public Guid? UsageUom { get; set; }
        public int? UsedCount { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDateTime { get; set; }
        public int RecordStatus { get; set; }
    }
}
