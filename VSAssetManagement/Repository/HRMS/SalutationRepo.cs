using VSManagement.Models.VS_EMPLOYEE;
using System.Collections.Generic;
using System.Linq;
using System;

namespace VSManagement.Repository.HRMS
{
    public class SalutationRepo
    {
        protected VS_EMPLOYEEContext _context { get; set; }
        public SalutationRepo(VS_EMPLOYEEContext context)
        {
            _context = context;
        }

        public List<Salutation> getAllList()
        {
            return _context.Salutation.ToList();
        }

        public int create(Salutation asset)
        {
            _context.Salutation.Add(asset);
            _context.SaveChanges();
            return asset.Id;
        }

        public Salutation getById(Guid id)
        {
            return _context.Salutation.Where(a => a.UniqueId == id).FirstOrDefault();
        }

        public int update(Salutation asset)
        {
            _context.Salutation.Update(asset);
            return _context.SaveChanges();
        }

        public int delete(Guid id)
        {
            _context.Salutation.Remove(getById(id));
            return _context.SaveChanges();
        }
    }
}