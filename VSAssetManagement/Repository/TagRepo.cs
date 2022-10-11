using VSAssetManagement.Models;
using System.Collections.Generic;
using System.Linq;
using System;

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

        public IEnumerable<Tag> getAllListLinq()
        {
            return (from tag in _context.Tag
                    join status in _context.Status on tag.Status equals status.Id.ToString()
                    select new Tag { 
                        CreatedDateTime = tag.CreatedDateTime,
                        LastUpdatedDateTime = tag.LastUpdatedDateTime,
                        AssetOperations = tag.AssetOperations,
                        Code = tag.Code,
                        CreatedBy = tag.CreatedBy,
                        Guid = tag.Guid,
                        Id = tag.Id,
                        LastUpdatedBy = tag.LastUpdatedBy,
                        Name = tag.Name,
                        RecordStatus = tag.RecordStatus,
                        Status = status.Description
                    }).ToList();

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