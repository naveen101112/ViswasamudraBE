using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace VSManagement.Models.VISWASAMUDRA
{
    public partial class Project
    {
        public Project()
        {
            Asset = new HashSet<Asset>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string ClientName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ProjectSiteHead { get; set; }
        public string SiteHeadMobile { get; set; }
        public string GstinNo { get; set; }
        public string CityTown { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreateDateTime { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDateTime { get; set; }
        public int RecordStatus { get; set; }
        public Guid Guid { get; set; }
        public string CompanyCode { get; set; }
        public string DeptCode { get; set; }
        public string ProjectHead { get; set; }
        public string UserCode { get; set; }

        public virtual ICollection<Asset> Asset { get; set; }
    }
}
