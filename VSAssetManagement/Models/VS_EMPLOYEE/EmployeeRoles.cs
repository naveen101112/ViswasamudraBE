using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace VSManagement.Models.VS_EMPLOYEE
{
    public partial class EmployeeRoles
    {
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public Guid? EmployeeUid { get; set; }
        public string CompanyCode { get; set; }
        public string DivisionCode { get; set; }
        public string ZoneCode { get; set; }
        public string BranchCode { get; set; }
        public string LocationCode { get; set; }
        public string DepartmentCode { get; set; }
        public string DeputationCode { get; set; }
        public string Salutation { get; set; }
        public string OrgChartReportingCode { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string IsActive { get; set; }

        public virtual Branch EmployeeU { get; set; }
        public virtual Department EmployeeU1 { get; set; }
        public virtual Deputation EmployeeU2 { get; set; }
        public virtual Division EmployeeU3 { get; set; }
        public virtual EmployeeMaster EmployeeU4 { get; set; }
        public virtual Locations EmployeeU5 { get; set; }
        public virtual Salutation EmployeeU6 { get; set; }
        public virtual Zones EmployeeU7 { get; set; }
        public virtual Company EmployeeUNavigation { get; set; }
    }
}
