using VSAssetManagement.Models;
using System.Collections.Generic;
using System.Linq;

namespace VSAssetManagement.Repo
{
    public class BatchRepo
    {
        protected VISWASAMUDRAContext _context { get; set; }
        public BatchRepo(VISWASAMUDRAContext context)
        {
            _context = context;
        }

        public List<Batch> getAllList()
        {
            return _context.Batch.ToList();
        }

        public int createAsset(Batch record)
        {
            _context.Batch.Add(record);
            _context.SaveChanges();
            return record.Id;
        }

        public Batch getById(int id)
        {
            return _context.Batch.Where(a=>a.Id==id).FirstOrDefault();
        }

        public int update(Batch record)
        {
            _context.Batch.Update(record);
            return _context.SaveChanges();
        }

        public int delete(int id)
        {
            _context.Batch.Remove(getById(id));
            return _context.SaveChanges();
        }
    }
}