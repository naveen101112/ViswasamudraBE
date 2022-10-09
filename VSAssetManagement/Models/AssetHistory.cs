using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace VSAssetManagement.Models
{
    public partial class AssetHistory
    {
        public int Id { get; set; }
        public int AssetId { get; set; }
        public int TagId { get; set; }
        public string AssetStatus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDateTime { get; set; }
        public int RecordStatus { get; set; }

        public virtual Asset Asset { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
