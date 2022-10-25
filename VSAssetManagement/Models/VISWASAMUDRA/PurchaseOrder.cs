using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace VSManagement.Models.VISWASAMUDRA
{
    public partial class PurchaseOrder
    {
        public PurchaseOrder()
        {
            Batch = new HashSet<Batch>();
        }

        public int Id { get; set; }
        public string PurchaseOrderNo { get; set; }
        public DateTime? PurchaseOrderDate { get; set; }
        public string ReceivedBy { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDateTime { get; set; }
        public int RecordStatus { get; set; }
        public Guid Guid { get; set; }
        public string CompanyCode { get; set; }
        public string DeptCode { get; set; }
        public string UserCode { get; set; }

        public virtual ICollection<Batch> Batch { get; set; }
    }
}
