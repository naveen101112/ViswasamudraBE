using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace VSManagement.Models.VS_EMPLOYEE
{
    public partial class Locations
    {
        public Locations()
        {
            EmployeeRoles = new HashSet<EmployeeRoles>();
        }

        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public Guid? BranchUid { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string BranchCode { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string IsActive { get; set; }

        public virtual Branch BranchU { get; set; }
        public virtual ICollection<EmployeeRoles> EmployeeRoles { get; set; }
    }
}
