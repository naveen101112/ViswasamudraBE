using VSManagement.Models.VISWASAMUDRA;
using System.Collections.Generic;
using System.Linq;

namespace VSManagement.Repository.AssetManagement
{
    public class AssetOperationsRepo
    {
        protected VISWASAMUDRAContext _context { get; set; }
        public AssetOperationsRepo(VISWASAMUDRAContext context)
        {
            _context = context;
        }

        public List<AssetOperations> getAllList()
        {
            return _context.AssetOperations.ToList();
        }

        public int create(AssetOperations asset)
        {
            _context.AssetOperations.Add(asset);
            _context.SaveChanges();
            return asset.Id;
        }

        public AssetOperations getById(int id)
        {
            return _context.AssetOperations.Where(a => a.Id == id).FirstOrDefault();
        }

        public int update(AssetOperations asset)
        {
            _context.AssetOperations.Update(asset);
            return _context.SaveChanges();
        }

        public int delete(int id)
        {
            _context.AssetOperations.Remove(getById(id));
            return _context.SaveChanges();
        }

        public IEnumerable<dynamic> getDataGrid()
        {
            return (from record in _context.AssetOperations
                    select new
                    {
                        record.Id,
                        AssetID = record.AssetGuid,
                        Status = record.AssetStatus,
                        record.Guid
                    }).ToList();

        }
    }
}