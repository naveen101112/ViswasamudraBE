using VSManagement.Models.VISWASAMUDRA;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace VSManagement.Repository.AssetManagement
{
    public class LookUpRepo
    {
        public VISWASAMUDRAContext _context { get; set; }
        public LookUpRepo(VISWASAMUDRAContext context)
        {
            _context = context;
        }

        public List<LookupType> getAllList()
        {
            return _context.LookupType.ToList();
        }

        public Guid create(LookupType record)
        {
            _context.LookupType.Add(record);
            _context.SaveChanges();
            return record.Guid;
        }

        public LookupType getByOnlyId(int id)
        {
            return _context.LookupType.Where(a => a.Id == id).FirstOrDefault();
        }

        public LookupType getByGuid(Guid id)
        {
            return _context.LookupType.Where(a => a.Guid == id).FirstOrDefault();
        }

        public int update(LookupType record)
        {
            _context.Update(record);
            return _context.SaveChanges();
        }

        public int delete(Guid id)
        {
            _context.LookupType.Remove(getByGuid(id));
            return _context.SaveChanges();
        }

        public LookupType getById(int id, Guid guid)
        {
            return _context.LookupType.Where(a => a.Id == id && a.Guid == guid).FirstOrDefault();
        }
    }
}