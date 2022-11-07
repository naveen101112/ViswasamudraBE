using VSManagement.Models.VISWASAMUDRA;
using System.Collections.Generic;
using System.Linq;
using System;
using io = VSAssetManagement.IOModels;

namespace VSManagement.Repository.AssetManagement
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

        public IEnumerable<io.Tag> getAllListLinq()
        {
            return (from tag in _context.Tag
                    select new io.Tag
                    {
                        CreatedDateTime = tag.CreatedDateTime,
                        LastUpdatedDateTime = tag.LastUpdatedDateTime,
                        Code = tag.Code,
                        Status = String.IsNullOrEmpty(tag.Status.ToString()) ? "" : _context.LookupTypeValue.Where(l=>l.Guid == tag.Status).FirstOrDefault().Name,
                        CreatedBy = tag.CreatedBy,
                        Guid = tag.Guid,
                        Id = tag.Id,
                        LastUpdatedBy = tag.LastUpdatedBy,
                        Name = tag.Name,
                        RecordStatus = tag.RecordStatus
                    }).ToList();

        }

        public IEnumerable<dynamic> getDataGrid()
        {
            return (from tag in _context.Tag
                    select new
                    {
                        tag.Id,
                        tag.Code,
                        tag.Name,
                        tag.Guid
                    }).ToList();

        }

        public int create(Tag record)
        {
            _context.Tag.Add(record);
            _context.SaveChanges();
            return record.Id;
        }

        public Tag getById(Guid guid)
        {
            return _context.Tag.Where(a => a.Guid == guid).FirstOrDefault();
        }

        public Tag getByOnlyId(int id)
        {
            return _context.Tag.Where(a => a.Id == id).FirstOrDefault();
        }

        public dynamic getByIdEdit(int id)
        {
            return (from record in _context.Tag
                    where record.Id == id
                    select new
                    {
                        record.Id,
                        record.Code,
                        record.Name,
                        record.Guid
                    }).FirstOrDefault();
        }

        public int update(Tag record)
        {
            Tag exist = getById(record.Guid);
            record.CreatedBy = exist.CreatedBy;
            record.CreatedDateTime = exist.CreatedDateTime;
            record.LastUpdatedBy = string.IsNullOrEmpty(record.LastUpdatedBy) ? "SYSTEM" : record.LastUpdatedBy;
            record.LastUpdatedDateTime = System.DateTime.Now;
            _context.Update(record).Property(x => x.Id).IsModified = false; 
            return _context.SaveChanges();
        }

        public int delete(int id)
        {
            _context.Tag.Remove(getByOnlyId(id));
            return _context.SaveChanges();
        }

        public List<Tag> searchListQuery(Tag request)
        {
            IQueryable<Tag> query = _context.Set<Tag>();
            if (request.Guid != null)
            {
                query = query.Where(t => t.Guid == request.Guid);
            }
            return query.ToList<Tag>();
        }
    }
}