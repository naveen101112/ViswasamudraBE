using System;
using System.Collections.Generic;
using System.Linq;
using VSManagement.Models.VS_EMPLOYEE;

namespace VSManagement.Repository.HRMS
{
    public class BranchRepo
    {
        protected VS_EMPLOYEEContext _context { get; set; }
        public BranchRepo(VS_EMPLOYEEContext context)
        {
            _context = context;
        }

        public List<Branch> getAllList()
        {
            return _context.Branch.ToList();
        }

        public int create(Branch asset)
        {
            _context.Branch.Add(asset);
            _context.SaveChanges();
            return asset.Id;
        }

        public Branch getById(Guid id)
        {
            return _context.Branch.Where(a => a.UniqueId == id).FirstOrDefault();
        }

        public int update(Branch asset)
        {
            _context.Branch.Update(asset);
            return _context.SaveChanges();
        }

        public int delete(Guid id)
        {
            _context.Branch.Remove(getById(id));
            return _context.SaveChanges();
        }
    }
}