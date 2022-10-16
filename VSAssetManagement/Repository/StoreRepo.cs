using VSManagement.Models.VISWASAMUDRA;
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

        public int update(Store record)
        {
            _context.Store.Update(record);
            return _context.SaveChanges();
        }

        public int delete(int id)
        {
            _context.Store.Remove(getById(id));
            return _context.SaveChanges();
        }
    }
}