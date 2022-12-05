using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace VSManagement.Models.VISWASAMUDRA
{
    public partial class AssetRequisition
    {
        public AssetRequisitionHeader header { get; set; }
        public List<AssetRequisitionDetails> details { get; set; }
    }
}
