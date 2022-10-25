using VSManagement.Models.VS_EMPLOYEE;
using System.Collections.Generic;
using System.Linq;
using System;

namespace VSManagement.Repository.HRMS
{
    public class EmployeeStatusRepo
    {
        protected VS_EMPLOYEEContext _context { get; set; }
        public EmployeeStatusRepo(VS_EMPLOYEEContext context)
        {
            _context = context;
        }

        public List<EmployeeStatus> getAllList()
        {
            return _context.EmployeeStatus.ToList();
        }

        public int create(EmployeeStatus record)
        {
            _context.EmployeeStatus.Add(record);
            _context.SaveChanges();
            return record.Id;
        }

        public EmployeeStatus getById(Guid guid)
        {
            return _context.EmployeeStatus.Where(a => a.UniqueId == guid).FirstOrDefault();
        }

        public int update(EmployeeStatus record)
        {
            _context.Update(record);
            return _context.SaveChanges();
        }

        public int delete(Guid id)
        {
            _context.EmployeeStatus.Remove(getById(id));
            return _context.SaveChanges();
        }
    }
}