using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace VSManagement.Models.VISWASAMUDRA
{
    public partial class AssetRequisitionHeader
    {
        public int Id { get; set; }
        public string AssetRequisitionNo { get; set; }
        public DateTime? AssetRequisitionDate { get; set; }
        public Guid? TaskType { get; set; }
        public Guid? Project { get; set; }
        public DateTime? RequiredFromDate { get; set; }
        public string RequestedBy { get; set; }
        public string ApprovedBy { get; set; }
        public string Remarks { get; set; }
        public string RequisitionStatus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDateTime { get; set; }
        public int? RecordStatus { get; set; }
        public Guid Guid { get; set; }
        public DateTime? RequiredToDate { get; set; }
    }
}
