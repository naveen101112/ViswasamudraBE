using System;

namespace VSManagement.IOModels
{
    public class EmployeeRoles
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
    }
}
