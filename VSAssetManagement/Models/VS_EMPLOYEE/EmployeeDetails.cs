using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace VSManagement.Models.VS_EMPLOYEE
{
    public partial class EmployeeDetails
    {
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public string MaritalStatus { get; set; }
        public DateTime? WeddingAnniversary { get; set; }
        public string Smoker { get; set; }
        public string Handicap { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string CityName { get; set; }
        public string StateName { get; set; }
        public string PinCode { get; set; }
        public string Mobile { get; set; }
        public string Home { get; set; }
        public string Other { get; set; }
        public string EmailWork { get; set; }
        public string EmailPersonal { get; set; }
        public string PAddress1 { get; set; }
        public string PAddress2 { get; set; }
        public string PCityName { get; set; }
        public string PStateName { get; set; }
        public string PPinCode { get; set; }
        public string PMobile { get; set; }
        public string PHome { get; set; }
        public string EmegContactName { get; set; }
        public string Relation { get; set; }
        public string EmegAddress1 { get; set; }
        public string EmegAddress2 { get; set; }
        public string EmegCityName { get; set; }
        public string EmegStateName { get; set; }
        public string EmegPinCode { get; set; }
        public string EmegMobile { get; set; }
        public string EmegHome { get; set; }
        public string EmegEmailPersonal { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string IsActive { get; set; }

        public virtual EmployeeMaster Unique { get; set; }
    }
}
