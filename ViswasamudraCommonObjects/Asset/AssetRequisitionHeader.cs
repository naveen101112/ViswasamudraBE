using System;
using System.Collections.Generic;

namespace VSAssetManagement.IOModels
{
    public class AssetRequisitionHeader
    {
        public int Id { get; set; }
        public string AssetRequisitionNo { get; set; }
        public DateTime? AssetRequisitionDate { get; set; }
        public Guid? TaskType { get; set; }
        public string TaskTypeName { get; set; }
        public Guid? Project { get; set; }
        public string ProjectName { get; set; }
        public DateTime? RequiredFromDate { get; set; }
        public DateTime? RequiredToDate { get; set; }
        public string RequestedBy { get; set; }
        public string RequestedByName { get; set; }
        public string ApprovedBy { get; set; }
        public string ApprovedByName { get; set; }
        public string Remarks { get; set; }
        public Guid? RequisitionStatus { get; set; }
        public string RequisitionStatusName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDateTime { get; set; }
        public int? RecordStatus { get; set; }
        public Guid Guid { get; set; }

        public static implicit operator AssetRequisitionHeader(List<AssetRequisitionHeader> v)
        {
            throw new NotImplementedException();
        }
    }
}
