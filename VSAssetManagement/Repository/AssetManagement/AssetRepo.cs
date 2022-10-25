using VSManagement.Models.VISWASAMUDRA;
using System.Collections.Generic;
using System.Linq;
using io = VSAssetManagement.IOModels;
using System;
using ViswasamudraCommonObjects.Util;

namespace VSManagement.Repository.AssetManagement
{
    public class AssetRepo
    {
        protected VISWASAMUDRAContext _context { get; set; }
        public AssetRepo(VISWASAMUDRAContext context)
        {
            _context = context;
        }

        public List<Asset> getAllList(Pagination page)
        {
            if (page.searchParam == null)
            {
                return _context.Asset.Skip(page.skip()).Take(page.take()).ToList();
            }
            else
            {
                return _context.Asset.Skip(page.skip()).Take(page.take()).ToList();
            }
        }

        public List<Asset> getAllListQuery(Pagination page)
        {
            if (page.searchParam == null)
            {
                return _context.Asset.Skip(page.skip()).Take(page.take()).ToList();
            }
            else
            {
                return _context.Asset.Skip(page.skip()).Take(page.take()).ToList();
            }
        }

        public int create(Asset asset)
        {
            _context.Asset.Add(asset);
            _context.SaveChanges();
            return asset.Id;
        }

        public Asset getByOnlyId(int id)
        {
            return _context.Asset.Where(a => a.Id == id).FirstOrDefault();
        }

        public Asset getById(int id, Guid guid)
        {
            return _context.Asset.Where(a => a.Id == id && a.Guid == guid).FirstOrDefault();
        }

        public int update(Asset asset)
        {
            _context.Asset.Update(asset);
            return _context.SaveChanges();
        }

        public int delete(int id)
        {
            _context.Asset.Remove(getByOnlyId(id));
            return _context.SaveChanges();
        }

        public int countById(int id)
        {
            return _context.Asset.Where(a => a.Id == id).Count();
        }

        public dynamic getByIdEdit(int id)
        {
            return (from asset in _context.Asset
                    where asset.Id == id
                    select new
                    {
                        asset.Id,
                        asset.Code,
                        asset.Name,
                        asset.CompanyName,
                        asset.ProjectGuid,
                        asset.StoreGuid,
                        asset.BatchGuid,
                        asset.Guid
                    }).FirstOrDefault();
        }

        public IEnumerable<dynamic> getDataGrid()
        {
            return (from asset in _context.Asset
                    select new
                    {
                        asset.Id,
                        asset.Code,
                        asset.Name,
                        asset.CompanyName,
                        asset.ProjectGuid,
                        asset.StoreGuid,
                        asset.BatchGuid,
                        asset.Guid
                    }).ToList();
        }
    }
}