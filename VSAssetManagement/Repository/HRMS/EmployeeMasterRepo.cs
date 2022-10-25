using VSManagement.Models.VS_EMPLOYEE;
using System.Collections.Generic;
using System.Linq;
using System;

namespace VSManagement.Repository.HRMS
{
    public class EmployeeMasterRepo
    {
        protected VS_EMPLOYEEContext _context { get; set; }
        public EmployeeMasterRepo(VS_EMPLOYEEContext context)
        {
            _context = context;
        }

        public List<EmployeeMaster> getAllList()
        {
            return _context.EmployeeMaster.ToList();
        }

        public int create(EmployeeMaster record)
        {
            _context.EmployeeMaster.Add(record);
            _context.SaveChanges();
            return record.Id;
        }

        public EmployeeMaster getById(Guid id)
        {
            return _context.EmployeeMaster.Where(a => a.UniqueId == id).FirstOrDefault();
        }

        public int update(EmployeeMaster record)
        {
            _context.EmployeeMaster.Update(record);
            return _context.SaveChanges();
        }

        public int delete(Guid id)
        {
            _context.EmployeeMaster.Remove(getById(id));
            return _context.SaveChanges();
        }
    }
}