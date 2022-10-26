using VSManagement.Models.VS_EMPLOYEE;
using System.Collections.Generic;
using System.Linq;
using VSAssetManagement;
using System;

namespace VSManagement.Repository.HRMS
{
    public class DeputationRepo
    {
        protected VS_EMPLOYEEContext _context { get; set; }
        public DeputationRepo(VS_EMPLOYEEContext context)
        {
            _context = context;
        }

        public List<Deputation> getAllList()
        {
            return _context.Deputation.ToList();
        }

        public int create(Deputation record)
        {
            _context.Deputation.Add(record);
            _context.SaveChanges();
            return record.Id;
        }

        public Deputation getById(Guid id)
        {
            return _context.Deputation.Where(a => a.UniqueId == id).FirstOrDefault();
        }

        public int update(Deputation record)
        {
            _context.Deputation.Update(record);
            return _context.SaveChanges();
        }

        public int delete(Guid id)
        {
            _context.Deputation.Remove(getById(id));
            return _context.SaveChanges();
        }
    }
}