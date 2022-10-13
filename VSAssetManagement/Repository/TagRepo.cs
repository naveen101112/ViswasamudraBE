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

        public IEnumerable<dynamic> getDataGrid()
        {
            return (from tag in _context.Tag
                    join status in _context.Status on tag.Status equals status.Id.ToString()
                    select new
                    {
                        Id = tag.Id,
                        Code = tag.Code,
                        Status = status.Description,
                        Name = tag.Name,
                        Guid = tag.Guid
                    }).ToList();

        }

        public int create(Tag record)
        {
            _context.Tag.Add(record);
            _context.SaveChanges();
            return record.Id;
        }

        public Tag getById(int id, Guid guid)
        {
            return _context.Tag.Where(a=>a.Id==id && a.Guid == guid).FirstOrDefault();
        }

        public Tag getByOnlyId(int id)
        {
            return _context.Tag.Where(a => a.Id == id).FirstOrDefault();
        }

        public dynamic getByIdEdit(int id)
        {
            return (from record in _context.Tag
                    join status in _context.Status on record.Status equals status.Id.ToString()
                    where record.Id == id
                    select new
                    {
                        Id = record.Id,
                        Code = record.Code,
                        Status = status.Description,
                        Name = record.Name,
                        Guid = record.Guid
                    }).FirstOrDefault();
        }

        public int update(Tag record)
        {
            _context.Update(record);
            return _context.SaveChanges();
        }

        public int delete(int id)
        {
            _context.Tag.Remove(getByOnlyId(id));
            return _context.SaveChanges();
        }
    }
}