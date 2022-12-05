using VSManagement.Models.VISWASAMUDRA;
using System.Collections.Generic;
using System.Linq;
using VSAssetManagement;
using io = VSAssetManagement.IOModels;
using System;
using Microsoft.EntityFrameworkCore;

namespace VSManagement.Repository.AssetManagement
{
    public class ProjectRepo
    {
        protected VISWASAMUDRAContext _context { get; set; }
        public ProjectRepo(VISWASAMUDRAContext context)
        {
            _context = context;
        }

        public List<io.Project> getAllList()
        {
            //return _context.Project.ToList();
            IQueryable<Project> prjQuery = _context.Set<Project>();
            var result = from x in prjQuery
                         where x.RecordStatus == 1
                         select new io.Project
                         {
                             Id = x.Id,
                             ProjectName = x.ProjectName,
                             ProjectCode = x.ProjectCode,
                             ProjectType = string.IsNullOrEmpty(x.ProjectType.ToString()) ? "" : _context.LookupTypeValue.Where(l=>l.Guid == x.ProjectType).FirstOrDefault().Name,
                             ClientName = x.ClientName,
                             ProjectStartDate = x.ProjectStartDate,
                             ProjectEndDate = x.ProjectEndDate,
                             ProjectSiteHead = x.ProjectSiteHead,
                             SiteHeadMobile = x.SiteHeadMobile,
                             GstinNo = x.GstinNo,
                             CityTown = x.CityTown,
                             AddressLine1 = x.AddressLine1,
                             AddressLine2 = x.AddressLine2,
                             CreatedBy = x.CreatedBy,
                             CreatedDateTime = x.CreatedDateTime,
                             LastUpdatedBy = x.LastUpdatedBy,
                             LastUpdatedDateTime = x.LastUpdatedDateTime,
                             Guid = x.Guid

                         };

            return result.ToList();
        }

        public int create(Project record)
        {
            if (_context.Project.Where(a => (a.ProjectName == record.ProjectName || a.ProjectCode == record.ProjectCode) && a.RecordStatus == 1).Count() <= 0)
            {
                _context.Project.Add(record);
                _context.SaveChanges();
                return record.Id;
            }
            else
            {
                return -1;
            }
        }

        public Project getById(int id)
        {
            return _context.Project.Where(a => a.Id == id).FirstOrDefault();
        }

        public Project getByGUId(Guid id)
        {
            return _context.Project.AsNoTracking().Where(a => a.Guid == id).FirstOrDefault();
        }

        public int update(Project record)
        {
            if (_context.Project.Where(a => (a.ProjectName == record.ProjectName || a.ProjectCode == record.ProjectCode) && a.RecordStatus == 1 && a.Guid != record.Guid).Count() <= 0)
            {
                Project exist = getByGUId(record.Guid);
                record.LastUpdatedBy = string.IsNullOrEmpty(record.LastUpdatedBy) ? "SYSTEM" : record.LastUpdatedBy;
                record.LastUpdatedDateTime = System.DateTime.Now;
                _context.Project.Update(record).Property(r => r.Id).IsModified = false;
                return _context.SaveChanges();
            }
            else return -1;
        }

        public int delete(io.Project request)
        {
            Project record = getByGUId(request.Guid);
            record.RecordStatus = 0;
            record.LastUpdatedBy = "SYSTEM";
            record.LastUpdatedDateTime = DateTime.Now;
            _context.Update(record).Property(x => x.Id).IsModified = false;
            return _context.SaveChanges();
        }

        public IEnumerable<dynamic> getDataGrid()
        {
            return (from record in _context.Project
                    where record.RecordStatus == 1
                    select new
                    {
                        record.Id,
                        record.ProjectCode,
                        record.ProjectName,
                        record.ProjectType,
                        record.ClientName,
                        StartDate = StaticData.getDateString(record.ProjectStartDate.Value),
                        EndDate = StaticData.getDateString(record.ProjectEndDate.Value),
                        record.ProjectSiteHead,
                        record.SiteHeadMobile,
                        GSTINNo = record.GstinNo,
                        record.CityTown,
                        Address1 = record.AddressLine1,
                        Address2 = record.AddressLine2,
                        record.Guid
                    }).ToList();

        }

        public dynamic getByIdEdit(int id)
        {
            return (from record in _context.Project
                    where record.Id == id && record.RecordStatus == 1
                    select new
                    {
                        record.Id,
                        record.ProjectCode,
                        record.ProjectName,
                        record.ProjectType,
                        record.ClientName,
                        StartDate = StaticData.getDateString(record.ProjectStartDate.Value),
                        EndDate = StaticData.getDateString(record.ProjectEndDate.Value),
                        record.ProjectSiteHead,
                        record.SiteHeadMobile,
                        GSTINNo = record.GstinNo,
                        record.CityTown,
                        record.AddressLine1,
                        record.AddressLine2,
                        record.Guid
                    }).FirstOrDefault();
        }

        public List<Project> searchListQuery(io.Project po)
        {
            IQueryable<Project> query = _context.Set<Project>();
            if (po.Guid != null)
            {
                query = query.Where(t => t.Guid == po.Guid && t.RecordStatus == 1);
            }
            return query.ToList<Project>();
        }

        public List<Project> getDropDown()
        {
            return (from project in _context.Project where project.RecordStatus == 1
                    select new Project { ProjectCode = project.ProjectCode, ProjectName = project.ProjectName, Guid = project.Guid, Id=project.Id }).ToList();
        }
    }
}