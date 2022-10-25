using VSManagement.Models.VS_EMPLOYEE;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace VSManagement.Repository.HRMS
{
    public class DepartmentRepo
    {
        public VS_EMPLOYEEContext _context { get; set; }
        public DepartmentRepo(VS_EMPLOYEEContext context)
        {
            _context = context;
        }

        public List<Department> getAllList()
        {
            return _context.Department.ToList();
        }

        public int create(Department record)
        {
            _context.Department.Add(record);
            _context.SaveChanges();
            return record.Id;
        }

        public int update(Department record)
        {
            _context.Update(record);
            return _context.SaveChanges();
        }

        public int delete(Guid id)
        {
            _context.Department.Remove(getById(id));
            return _context.SaveChanges();
        }

        public Department getById(Guid guid)
        {
            return _context.Department.Where(a => a.UniqueId == guid).FirstOrDefault();
        }
    }
}