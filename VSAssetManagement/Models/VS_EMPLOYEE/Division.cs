using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace VSManagement.Models.VS_EMPLOYEE
{
    public partial class Division
    {
        public Division()
        {
            EmployeeRoles = new HashSet<EmployeeRoles>();
            Zones = new HashSet<Zones>();
        }

        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public Guid? CompanyUid { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string CompanyCode { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string IsActive { get; set; }

        public virtual Company CompanyU { get; set; }
        public virtual ICollection<EmployeeRoles> EmployeeRoles { get; set; }
        public virtual ICollection<Zones> Zones { get; set; }
    }
}
