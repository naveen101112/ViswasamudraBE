using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace VSManagement.Models.VISWASAMUDRA
{
    public partial class Store
    {
        public Store()
        {
            Asset = new HashSet<Asset>();
        }

        public string Name { get; set; }
        public int ParentStore { get; set; }
        public int RecordStatus { get; set; }
        public Guid Guid { get; set; }
        public string Code { get; set; }
        public string Project { get; set; }
        public string Incharge { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDateTime { get; set; }
        public int Id { get; set; }

        public virtual ICollection<Asset> Asset { get; set; }
    }
}
