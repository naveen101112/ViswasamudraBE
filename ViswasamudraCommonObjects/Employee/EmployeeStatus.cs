using System;

namespace VSManagement.IOModels
{
    public class EmployeeStatus
    {
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public string EmployeeStatusCode { get; set; }
        public string ProbationPeriod { get; set; }
        public DateTime? ConfirmationDate { get; set; }
        public DateTime? ExtConfirmationDate { get; set; }
        public string DesignationName { get; set; }
        public string FunctionalDesignation { get; set; }
        public string GradeName { get; set; }
        public string RelevantExperince { get; set; }
        public string PastExperience { get; set; }
        public string TotalExperience { get; set; }
        public string CategoryName { get; set; }
        public string SalaryGroup { get; set; }
        public string NoticePeriod { get; set; }
        public string BandName { get; set; }
        public string SubDepartmentName { get; set; }
        public string AttCardNumber { get; set; }
        public string InterviewerEmpCode { get; set; }
        public string CostCenterName { get; set; }
        public string SalaryType { get; set; }
        public string Ctc { get; set; }
        public string Incentives { get; set; }
        public string PayComponents { get; set; }
        public string PerformanceBonus { get; set; }
        public string SalaryOnHold { get; set; }
        public string OvertimeApplicable { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string IsActive { get; set; }
    }
}
