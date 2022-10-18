using VSManagement.Models.VS_EMPLOYEE;
using System.Collections.Generic;
using System.Linq;
using System;

namespace VSManagement.Repository.HRMS
{
    public class EmployeeDetailsRepo
    {
        protected VS_EMPLOYEEContext _context { get; set; }
        public EmployeeDetailsRepo(VS_EMPLOYEEContext context)
        {
            _context = context;
        }

        public List<EmployeeDetails> getAllList()
        {
            return _context.EmployeeDetails.ToList();
        }

        public int createAsset(EmployeeDetails record)
        {
            _context.EmployeeDetails.Add(record);
            _context.SaveChanges();
            return record.Id;
        }

        public EmployeeDetails getById(Guid id)
        {
            return _context.EmployeeDetails.Where(a => a.UniqueId == id).FirstOrDefault();
        }

        public int update(EmployeeDetails record)
        {
            _context.EmployeeDetails.Update(record);
            return _context.SaveChanges();
        }

        public int delete(Guid id)
        {
            _context.EmployeeDetails.Remove(getById(id));
            return _context.SaveChanges();
        }
    }
}