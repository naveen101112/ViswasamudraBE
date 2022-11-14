using VSManagement.Models.VISWASAMUDRA;
using System.Collections.Generic;
using System.Linq;
using System;
using mo = VSAssetManagement.IOModels;

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
            return _context.LookupType.Where(x=>x.RecordStatus == 1).ToList();
        }

        public Guid create(LookupType record)
        {
            record.CreatedDateTime = DateTime.Now;
            record.LastUpdatedDateTime = DateTime.Now;
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
            _context.Update(record).Property(x => x.Id).IsModified = false; ;
            return _context.SaveChanges();
        }

        public int update(LookupTypeValue record)
        {
            _context.LookupTypeValue.Update(record).Property(x => x.Id).IsModified = false; ;
            return _context.SaveChanges();
        }

        public int delete(mo.LookupType request)
        {
            //_context.LookupTypeValue.Remove(getByGuid(id));
            LookupType record = getByGuid(request.Guid);
            record.RecordStatus = 0;
            record.LastUpdatedBy = "SYSTEM";
            record.LastUpdatedDateTime = DateTime.Now;
            _context.Update(record).Property(x => x.Id).IsModified = false;
            return _context.SaveChanges();
        }

        public LookupType getById(int id, Guid guid)
        {
            return _context.LookupType.Where(a => a.Id == id && a.Guid == guid).FirstOrDefault();
        }

        public Guid getIdByCode(string code)
        {
            return _context.LookupType.Where(a => a.Code == code).FirstOrDefault().Guid;
        }

        public List<LookupType> searchListQuery(LookupType record)
        {
            IQueryable<LookupType> query = _context.Set<LookupType>().OrderByDescending(x => x.Id);
            if (record.Guid != Guid.Empty)
            {
                query = query.Where(t => t.Guid == record.Guid);
            }

            return query.Where(t => t.RecordStatus == record.RecordStatus).ToList<LookupType>();
        }
    }
}