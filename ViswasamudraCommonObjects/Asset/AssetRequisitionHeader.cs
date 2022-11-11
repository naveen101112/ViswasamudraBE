
using System;

namespace VSAssetManagement.IOModels
{
    public class AssetRequisitionHeader
    {
        public int Id { get; set; }
        public string AssetRequisitionNo { get; set; }
        public DateTime? AssetRequisitionDate { get; set; } = DateTime.Now;
        public string TaskType { get; set; }
        public string Project { get; set; }
        public DateTime? RequiredFromDate { get; set; } = DateTime.Now;
        public DateTime? RequiredToDate { get; set; } = DateTime.Now;
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
    }
}
