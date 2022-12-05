using VSManagement.Models.VS_EMPLOYEE;
using System.Collections.Generic;
using System.Linq;
using System;

namespace VSManagement.Repository.HRMS
{
    public class TblMigrationEmpRepo
    {
        protected VS_EMPLOYEEContext _context { get; set; }
        public TblMigrationEmpRepo(VS_EMPLOYEEContext context)
        {
            _context = context;
        }

        public List<TblMigrationEmployee> getAllList()
        {
            return _context.TblMigrationEmployee.ToList();
        }
    }
}