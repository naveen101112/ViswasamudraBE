using VSManagement.Models.VS_EMPLOYEE;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Globalization;
using VSAssetManagement;

namespace VSManagement.Repository.HRMS
{
    public class DivisionRepo
    {
        protected VS_EMPLOYEEContext _context { get; set; }
        public DivisionRepo(VS_EMPLOYEEContext context)
        {
            _context = context;
        }

        public List<Division> getAllList()
        {
            return _context.Division.ToList();
        }

        public int create(Division record)
        {
            _context.Division.Add(record);
            _context.SaveChanges();
            return record.Id;
        }

        public Division getById(Guid guid)
        {
            return _context.Division.Where(a => a.UniqueId == guid).FirstOrDefault();
        }

        public int update(Division record)
        {
            _context.Update(record);
            return _context.SaveChanges();
        }

        public int delete(Guid id)
        {
            _context.Division.Remove(getById(id));
            return _context.SaveChanges();
        }
    }
}