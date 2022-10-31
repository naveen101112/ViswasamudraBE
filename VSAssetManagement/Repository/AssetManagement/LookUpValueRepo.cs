using VSManagement.Models.VISWASAMUDRA;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace VSManagement.Repository.AssetManagement
{
    public class LookUpValueRepo
    {
        public VISWASAMUDRAContext _context { get; set; }
        public LookUpValueRepo(VISWASAMUDRAContext context)
        {
            _context = context;
        }

        public List<LookupTypeValue> getAllList()
        {
            return _context.LookupTypeValue.ToList();
        }

        public Guid create(LookupTypeValue record)
        {
            _context.LookupTypeValue.Add(record);
            _context.SaveChanges();
            return record.Guid;
        }

        public LookupTypeValue getByOnlyId(int id)
        {
            return _context.LookupTypeValue.Where(a => a.Id == id).FirstOrDefault();
        }

        public int update(LookupTypeValue record)
        {
            _context.Update(record).Property(x => x.Id).IsModified = false; ;
            return _context.SaveChanges();
        }

        public int delete(Guid id)
        {
            _context.LookupTypeValue.Remove(getByGuid(id));
            return _context.SaveChanges();
        }

        public LookupTypeValue getById(int id, Guid guid)
        {
            return _context.LookupTypeValue.Where(a => a.Id == id && a.Guid == guid).FirstOrDefault();
        }

        public LookupTypeValue getByGuid(Guid guid)
        {
            return _context.LookupTypeValue.Where(a => a.Guid == guid).FirstOrDefault();
        }

        public List<LookupTypeValue> searchListQuery(LookupTypeValue record)
        {
            IQueryable<LookupTypeValue> query = _context.Set<LookupTypeValue>();
            if (record.Guid != null)
            {
                query = query.Where(t => t.Guid == record.Guid);
            }
            return query.ToList<LookupTypeValue>();
        }

        public dynamic getLookUpDropDownById(Guid id)
        {
            return (from value in _context.LookupTypeValue
                     join lookup in _context.LookupType
                     on value.LookupTypeId equals lookup.Guid
                     where lookup.Guid == id 
                        && lookup.RecordStatus != 1
                        && value.RecordStatus != 1
                     select new
                     {
                         value.Guid,
                         value.Code,
                         value.Name
                     }
             );
        }

        public dynamic getLookUpDropDownByCode(string code)
        {
            return (from value in _context.LookupTypeValue
                    join lookup in _context.LookupType
                    on value.LookupTypeId equals lookup.Guid
                    where lookup.Code == code
                       && lookup.RecordStatus == 1
                       && value.RecordStatus == 1
                    select new
                    {
                        value.Guid,
                        value.Code,
                        value.Name
                    }
             );
        }
    }
}