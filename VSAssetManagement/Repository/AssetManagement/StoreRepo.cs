using VSManagement.Models.VISWASAMUDRA;
using System.Collections.Generic;
using System.Linq;
using System;
using io = VSAssetManagement.IOModels;

namespace VSManagement.Repository.AssetManagement
{
    public class StoreRepo
    {
        protected VISWASAMUDRAContext _context { get; set; }
        public StoreRepo(VISWASAMUDRAContext context)
        {
            _context = context;
        }

        public List<Store> getAllList()
        {
            return _context.Store.ToList();
        }

        public Guid createAsset(Store record)
        {
            _context.Store.Add(record);
            _context.SaveChanges();
            return record.Guid;
        }

        public Store getById(Guid id)
        {
            return _context.Store.Where(a => a.Guid == id).FirstOrDefault();
        }

        public int update(Store record)
        {
            _context.Store.Update(record).Property(r => r.Id).IsModified = false;
            return _context.SaveChanges();
        }

        public int delete(Guid id)
        {
            _context.Store.Remove(getById(id));
            return _context.SaveChanges();
        }

        public List<Store> searchListQuery(io.Store request)
        {
            IQueryable<Store> query = _context.Set<Store>();
            if (request.Guid != null)
            {
                query = query.Where(t => t.Guid == request.Guid);
            }
            return query.ToList<Store>();
        }
    }
}