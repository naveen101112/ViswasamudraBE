using VSManagement.Models.VS_EMPLOYEE;
using System.Collections.Generic;
using System.Linq;
using VSManagement.Models.VS_EMPLOYEE;
using System;

namespace VSManagement.Repository.HRMS
{
    public class LocationsRepo
    {
        protected VS_EMPLOYEEContext _context { get; set; }
        public LocationsRepo(VS_EMPLOYEEContext context)
        {
            _context = context;
        }

        public List<Locations> getAllList()
        {
            return _context.Locations.ToList();
        }

        public int create(Locations asset)
        {
            _context.Locations.Add(asset);
            _context.SaveChanges();
            return asset.Id;
        }

        public Locations getById(Guid id)
        {
            return _context.Locations.Where(a => a.UniqueId == id).FirstOrDefault();
        }

        public int update(Locations asset)
        {
            _context.Locations.Update(asset);
            return _context.SaveChanges();
        }

        public int delete(Guid id)
        {
            _context.Locations.Remove(getById(id));
            return _context.SaveChanges();
        }
    }
}