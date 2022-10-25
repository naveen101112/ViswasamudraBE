using VSManagement.Models.VS_EMPLOYEE;
using System.Collections.Generic;
using System.Linq;
using System;

namespace VSManagement.Repository.HRMS
{
    public class CompanyRepo
    {
        protected VS_EMPLOYEEContext _context { get; set; }
        public CompanyRepo(VS_EMPLOYEEContext context)
        {
            _context = context;
        }

        public List<Company> getAllList()
        {
            return _context.Company.ToList();
        }

        public int create(Company asset)
        {
            _context.Company.Add(asset);
            _context.SaveChanges();
            return asset.Id;
        }

        public Company getById(Guid id)
        {
            return _context.Company.Where(a => a.UniqueId == id).FirstOrDefault();
        }

        public int update(Company asset)
        {
            _context.Company.Update(asset);
            return _context.SaveChanges();
        }

        public int delete(Guid id)
        {
            _context.Company.Remove(getById(id));
            return _context.SaveChanges();
        }
    }
}