using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace VSManagement.Models.VS_EMPLOYEE
{
    public partial class TblMigrationSubdepartment
    {
        public int Id { get; set; }
        public string SubDepartmentCode { get; set; }
        public string SubDepartmentName { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? MigratedDate { get; set; }
    }
}
