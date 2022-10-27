using VSManagement.Models.VISWASAMUDRA;
using System.Collections.Generic;
using System.Linq;

namespace VSManagement.Repository.AssetManagement
{
    public class StatusRepo
    {
        protected VISWASAMUDRAContext _context { get; set; }
        public StatusRepo(VISWASAMUDRAContext context)
        {
            _context = context;
        }

        public List<Status> getAllList()
        {
            return _context.Status.ToList();
        }

        public int create(Status record)
        {
            _context.Status.Add(record);
            _context.SaveChanges();
            return record.Id;
        }

        public Status getById(int id)
        {
            return _context.Status.Where(a => a.Id == id).FirstOrDefault();
        }

        public int update(Status record)
        {
            _context.Status.Update(record).Property(x => x.Id).IsModified = false; ;
            return _context.SaveChanges();
        }

        public int delete(int id)
        {
            _context.Status.Remove(getById(id));
            return _context.SaveChanges();
        }
    }
}