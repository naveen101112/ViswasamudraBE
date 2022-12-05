using VSManagement.Models.VISWASAMUDRA;
using System.Collections.Generic;
using System.Linq;
using System;
using io = VSAssetManagement.IOModels;
using Microsoft.EntityFrameworkCore;

namespace VSManagement.Repository.AssetManagement
{
    public class StoreRepo
    {
        protected VISWASAMUDRAContext _context { get; set; }
        public StoreRepo(VISWASAMUDRAContext context)
        {
            _context = context;
        }

        public List<io.Store> getAllList()
        {
            //return _context.Store.ToList();
            IQueryable<Store> storeQuery = _context.Set<Store>();
            IQueryable<Project> prjQuery = _context.Set<Project>();
            var result = from x in storeQuery.Where(x => x.RecordStatus == 1)
                         from y in prjQuery.Where(y => y.Guid == x.Project)
                         select new io.Store
                         {
                             Id = x.Id,
                             Name = x.Name,
                             Code = x.Code,
                             Project = y.ProjectName,
                             Incharge = x.Incharge,
                             InchargeMobile = x.InchargeMobile,
                             ParentStore = string.IsNullOrEmpty(x.ParentStore.ToString()) ? "" : storeQuery.Where(s=>s.Guid == x.ParentStore).FirstOrDefault().Name,
                             CreatedBy = x.CreatedBy,
                             CreatedDateTime = x.CreatedDateTime,
                             LastUpdatedBy = x.LastUpdatedBy,
                             LastUpdatedDateTime = x.LastUpdatedDateTime,
                             Guid = x.Guid

                         };

            return result.ToList();
        }

        public int createStore(Store record)
        {
            string Project = _context.Project.Where(p => p.Guid == record.Project).FirstOrDefault().ProjectCode;            
            if (_context.Store.Where(a => (a.Name == record.Name || a.Code.Contains("/"+record.Code)) && a.RecordStatus == 1).Count() <= 0)
            {
                int prjCount = _context.Store.Where(a => a.Project == record.Project).Count();
                string strCode = Project + "/" + record.Code;
                record.Code = strCode;
                record.CreatedBy = "SYSTEM";
                record.CreatedDateTime = System.DateTime.Now;
                _context.Store.Add(record);
                _context.SaveChanges();
                return record.Id;
            }
            else
            {
                return -1;
            }
        }

        public Store getById(Guid id)
        {
            return _context.Store.AsNoTracking().Where(a => a.Guid == id).FirstOrDefault();
        }

        public List<Store> getDropDown(int id)
        {
            return (from store in _context.Store
                    where store.Id != id && store.RecordStatus == 1 
                    select new Store { Code=store.Code, Name = store.Name, Guid=store.Guid }).ToList();
        }

        public List<Store> getDropDownByProject(int id,Guid guid)
        {
            return (from store in _context.Store
                    where store.Id != id && store.RecordStatus == 1 && store.Project == guid
                    select new Store { Code = store.Code, Name = store.Name, Guid = store.Guid }).ToList();
        }

        public int update(Store record)
        {
            string Project = _context.Project.Where(p => p.Guid == record.Project).FirstOrDefault().ProjectCode;
            string[] values = record.Code.Split('/');
            if (_context.Store.Where(a => (a.Name == record.Name || a.Code.Contains("/" + values[1])) && a.RecordStatus == 1 && a.Guid!=record.Guid).Count() <= 0)
            {
                Store OldRecord = getById(record.Guid);

                record.CreatedBy = OldRecord.CreatedBy;
                record.CreatedDateTime = OldRecord.CreatedDateTime;
                record.Code = Project + "/" + values[1];
                record.LastUpdatedBy = string.IsNullOrEmpty(record.LastUpdatedBy) ? "SYSTEM" : record.LastUpdatedBy;
                record.LastUpdatedDateTime = System.DateTime.Now;                
                record.RecordStatus = 1;
                _context.Update(record).Property(r => r.Id).IsModified = false;
                return _context.SaveChanges();
            }
            else return -1;
        }

        public int delete(io.Store request)
        {
            //_context.Store.Remove(getById(id));
            Store record = getById(request.Guid);
            record.RecordStatus = 0;
            record.LastUpdatedBy = "SYSTEM";
            record.LastUpdatedDateTime = DateTime.Now;
            _context.Update(record).Property(x => x.Id).IsModified = false;
            return _context.SaveChanges();
        }

        public List<Store> searchListQuery(io.Store request)
        {
            IQueryable<Store> query = _context.Set<Store>();
            if (request.Guid != null)
            {
                query = query.Where(t => t.Guid == request.Guid && t.RecordStatus == 1);
            }
            return query.ToList<Store>();
        }
    }
}