using VSManagement.Models.VS_EMPLOYEE;
using System.Collections.Generic;
using System.Linq;
using System;

namespace VSManagement.Repository.HRMS
{
    public class ZonesRepo
    {
        protected VS_EMPLOYEEContext _context { get; set; }
        public ZonesRepo(VS_EMPLOYEEContext context)
        {
            _context = context;
        }

        public List<Zones> getAllList()
        {
            return _context.Zones.ToList();
        }

        public int create(Zones asset)
        {
            _context.Zones.Add(asset);
            _context.SaveChanges();
            return asset.Id;
        }

        public Zones getById(Guid id)
        {
            return _context.Zones.Where(a => a.UniqueId == id).FirstOrDefault();
        }

        public int update(Zones asset)
        {
            _context.Zones.Update(asset);
            return _context.SaveChanges();
        }

        public int delete(Guid id)
        {
            _context.Zones.Remove(getById(id));
            return _context.SaveChanges();
        }
    }
}