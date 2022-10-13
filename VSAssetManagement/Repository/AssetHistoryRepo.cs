using VSAssetManagement.Models;
using System.Collections.Generic;
using System.Linq;

namespace VSAssetManagement.Repo
{
    public class AssetHistoryRepo
    {
        protected VISWASAMUDRAContext _context { get; set; }
        public AssetHistoryRepo(VISWASAMUDRAContext context)
        {
            _context = context;
        }

        public List<AssetHistory> getAllList()
        {
            return _context.AssetHistory.ToList();
        }

        public int create(AssetHistory asset)
        {
            _context.AssetHistory.Add(asset);
            _context.SaveChanges();
            return asset.Id;
        }

        public AssetHistory getById(int id)
        {
            return _context.AssetHistory.Where(a=>a.Id==id).FirstOrDefault();
        }

        public int update(AssetHistory asset)
        {
            _context.AssetHistory.Update(asset);
            return _context.SaveChanges();
        }

        public int delete(int id)
        {
            _context.AssetHistory.Remove(getById(id));
            return _context.SaveChanges();
        }

        public IEnumerable<dynamic> getDataGrid()
        {
            return (from record in _context.AssetHistory
                    join status in _context.Status on record.AssetStatus equals status.Id.ToString()
                    select new
                    {
                        Id = record.Id,
                        AssetID = record.AssetGuid,
                        TagID = record.TagId,
                        Status = status.Description,
                        Guid = record.Guid
                    }).ToList();

        }
    }
}