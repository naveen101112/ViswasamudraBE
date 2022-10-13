using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace VSAssetManagement.Models
{
    public partial class Asset
    {
        public Asset()
        {
            AssetHistory = new HashSet<AssetHistory>();
            AssetOperations = new HashSet<AssetOperations>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
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

        public virtual Batch Batch { get; set; }
        public virtual Project Project { get; set; }
        public virtual Store Store { get; set; }
        public virtual ICollection<AssetHistory> AssetHistory { get; set; }
        public virtual ICollection<AssetOperations> AssetOperations { get; set; }
    }
}
