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

        public int Id { get; set; }
        public string Name { get; set; }
        public int MainStoreId { get; set; }
        public int RecordStatus { get; set; }
        public Guid Guid { get; set; }

        public virtual ICollection<Asset> Asset { get; set; }
    }
}
