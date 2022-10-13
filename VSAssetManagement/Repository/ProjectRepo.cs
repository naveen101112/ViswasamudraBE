using VSAssetManagement.Models;
using System.Collections.Generic;
using System.Linq;

namespace VSAssetManagement.Repo
{
    public class ProjectRepo
    {
        protected VISWASAMUDRAContext _context { get; set; }
        public ProjectRepo(VISWASAMUDRAContext context)
        {
            _context = context;
        }

        public List<Project> getAllList()
        {
            return _context.Project.ToList();
        }

        public int create(Project record)
        {
            _context.Project.Add(record);
            _context.SaveChanges();
            return record.Id;
        }

        public Project getById(int id)
        {
            return _context.Project.Where(a=>a.Id==id).FirstOrDefault();
        }

        public int update(Project record)
        {
            _context.Project.Update(record);
            return _context.SaveChanges();
        }

        public int delete(int id)
        {
            _context.Project.Remove(getById(id));
            return _context.SaveChanges();
        }

        public IEnumerable<dynamic> getDataGrid()
        {
            return (from record in _context.Project
                    select new
                    {
                        Id = record.Id,
                        Code = record.Code,
                        Name = record.Name,
                        Type = record.Type,
                        ClientName = record.ClientName,
                        StartDate = StaticData.getDateString(record.StartDate.Value),
                        EndDate = StaticData.getDateString(record.EndDate.Value),
                        ProjectSiteHead = record.ProjectSiteHead,
                        SiteHeadMobile = record.SiteHeadMobile,
                        GSTINNo = record.GstinNo,
                        CityTown = record.CityTown,
                        Address1 = record.AddressLine1,
                        Address2 = record.AddressLine2,
                        Guid = record.Guid
                    }).ToList();

        }

        public dynamic getByIdEdit(int id)
        {
            return (from record in _context.Project
                    where record.Id == id
                    select new
                    {
                        Id = record.Id,
                        Code = record.Code,
                        Name = record.Name,
                        Type = record.Type,
                        ClientName = record.ClientName,
                        StartDate = StaticData.getDateString(record.StartDate.Value),
                        EndDate = StaticData.getDateString(record.EndDate.Value),
                        ProjectSiteHead = record.ProjectSiteHead,
                        SiteHeadMobile = record.SiteHeadMobile,
                        GSTINNo = record.GstinNo,
                        CityTown = record.CityTown,
                        AddressLine1 = record.AddressLine1,
                        AddressLine2 = record.AddressLine2,
                        Guid = record.Guid
                    }).FirstOrDefault();
        }
    }
}