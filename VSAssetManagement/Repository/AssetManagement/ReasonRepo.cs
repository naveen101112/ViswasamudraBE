using VSManagement.Models.VISWASAMUDRA;
using System.Collections.Generic;
using System.Linq;
using System;
using io = VSAssetManagement.IOModels;

namespace VSManagement.Repository.AssetManagement
{
    public class ReasonRepo
    {
        protected VISWASAMUDRAContext _context { get; set; }
        public ReasonRepo(VISWASAMUDRAContext context)
        {
            _context = context;
        }

        public List<Reason> getAllList()
        {
            return _context.Reason.ToList();
        }

        public List<Reason> searchListQuery(io.Reason res)
        {
            IQueryable<Reason> query = _context.Set<Reason>();
            if (res.Guid != null)
            {
                query = query.Where(t => t.Guid == res.Guid);
            }
            return query.ToList<Reason>();
        }

        public Guid createAsset(Reason record)
        {
            _context.Reason.Add(record);
            _context.SaveChanges();
            return record.Guid;
        }

        public Reason getById(Guid id)
        {
            return _context.Reason.Where(a => a.Guid == id).FirstOrDefault();
        }

        public int update(Reason record)
        {
            _context.Reason.Update(record).Property(x => x.Id).IsModified = false; 
            return _context.SaveChanges();
        }

        public int delete(Guid id)
        {
            _context.Reason.Remove(getById(id));
            return _context.SaveChanges();
        }
    }
}