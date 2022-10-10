﻿using VSAssetManagement.Models;
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
    }
}