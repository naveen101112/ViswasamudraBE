using VSAssetManagement.Models;
using System.Collections.Generic;
using System.Linq;

namespace VSAssetManagement.Repo
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

        public int createAsset(Store record)
        {
            _context.Store.Add(record);
            _context.SaveChanges();
            return record.Id;
        }

        public Store getById(int id)
        {
            return _context.Store.Where(a=>a.Id==id).FirstOrDefault();
        }
    }
}