using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace VSManagement.Models.VISWASAMUDRA
{
    public partial class Asset
    {
        public int Id { get; set; }
        public string AssetCode { get; set; }
        public string AssetName { get; set; }
        public string CompanyName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDateTime { get; set; }
        public int RecordStatus { get; set; }
        public Guid Guid { get; set; }
        public Guid ProjectCode { get; set; }
        public Guid? StructureType { get; set; }
        public Guid? TagId { get; set; }
        public Guid AssetType { get; set; }
        public Guid AssetSpecification { get; set; }
        public Guid Store { get; set; }
        public string BatchNo { get; set; }
        public Guid? StructureSubType { get; set; }
    }
}
