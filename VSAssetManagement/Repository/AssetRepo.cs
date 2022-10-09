using VSAssetManagement.Models;
using System.Collections.Generic;
using System.Linq;

namespace VSAssetManagement.Repo
{
    public class AssetRepo
    {
        protected VISWASAMUDRAContext _context { get; set; }
        public AssetRepo(VISWASAMUDRAContext context)
        {
            _context = context;
        }

        public List<Asset> getAllList()
        {
            return _context.Asset.ToList();
        }

        public int createAsset(Asset asset)
        {
            _context.Asset.Add(asset);
            _context.SaveChanges();
            return asset.Id;
        }

        public Asset getById(int id)
        {
            return _context.Asset.Where(a=>a.Id==id).FirstOrDefault();
        }
    }
}