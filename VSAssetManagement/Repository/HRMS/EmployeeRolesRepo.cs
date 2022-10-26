using VSManagement.Models.VS_EMPLOYEE;
using System.Collections.Generic;
using System.Linq;
using System;

namespace VSManagement.Repository.HRMS
{
    public class EmployeeRolesRepo
    {
        protected VS_EMPLOYEEContext _context { get; set; }
        public EmployeeRolesRepo(VS_EMPLOYEEContext context)
        {
            _context = context;
        }

        public List<EmployeeRoles> getAllList()
        {
            return _context.EmployeeRoles.ToList();
        }

        public int create(EmployeeRoles record)
        {
            _context.EmployeeRoles.Add(record);
            _context.SaveChanges();
            return record.Id;
        }

        public EmployeeRoles getById(Guid guid)
        {
            return _context.EmployeeRoles.Where(a => a.UniqueId == guid).FirstOrDefault();
        }

        public int update(EmployeeRoles record)
        {
            _context.Update(record);
            return _context.SaveChanges();
        }

        public int delete(Guid id)
        {
            _context.EmployeeRoles.Remove(getById(id));
            return _context.SaveChanges();
        }
    }
}