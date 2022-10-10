using VSAssetManagement.Models;
using System.Collections.Generic;
using System.Linq;

namespace VSAssetManagement.Repo
{
    public class TagRepo
    {
        protected VISWASAMUDRAContext _context { get; set; }
        public TagRepo(VISWASAMUDRAContext context)
        {
            _context = context;
        }

        public List<Tag> getAllList()
        {
            return _context.Tag.ToList();
        }

        public int create(Tag record)
        {
            _context.Tag.Add(record);
            _context.SaveChanges();
            return record.Id;
        }

        public Tag getById(int id)
        {
            return _context.Tag.Where(a=>a.Id==id).FirstOrDefault();
        }

        public int update(Tag record)
        {
            _context.Tag.Update(record);
            return _context.SaveChanges();
        }

        public int delete(int id)
        {
            _context.Tag.Remove(getById(id));
            return _context.SaveChanges();
        }
    }
}