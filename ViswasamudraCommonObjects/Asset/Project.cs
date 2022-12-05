using System;

namespace VSAssetManagement.IOModels
{
    public class Project
    {
        public int Id { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public string ProjectType { get; set; }
        public string ClientName { get; set; }
        public DateTime? ProjectStartDate { get; set; } = DateTime.Now;
        public DateTime? ProjectEndDate { get; set; } = DateTime.Now;
        public string ProjectSiteHead { get; set; }
        public string SiteHeadMobile { get; set; }
        public string GstinNo { get; set; }
        public string CityTown { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDateTime { get; set; }
        public int RecordStatus { get; set; }
        public Guid Guid { get; set; }
    }
}
