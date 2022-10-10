using VSAssetManagement.Models;
using System.Collections.Generic;
using System.Linq;
using io = VSAssetManagement.IOModels;

namespace VSAssetManagement.Repo
{
    public class AssetRepo
    {
        protected VISWASAMUDRAContext _context { get; set; }
        public AssetRepo(VISWASAMUDRAContext context)
        {
            _context = context;
        }

        public List<Asset> getAllList(io.Pagination page)
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

        public Asset getById(int id)
        {
            return _context.Asset.Where(a=>a.Id==id).FirstOrDefault();
        }

        public int update(Asset asset)
        {
            _context.Asset.Update(asset);
            return _context.SaveChanges();
        }

        public int delete(int id)
        {
            _context.Asset.Remove(getById(id));
            return _context.SaveChanges();
        }

        public int countById(int id)
        {
            return _context.Asset.Where(a=>a.Id == id).Count();
        }
    }
}