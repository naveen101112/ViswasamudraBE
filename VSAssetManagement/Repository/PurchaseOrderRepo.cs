using VSAssetManagement.Models;
using System.Collections.Generic;
using System.Linq;

namespace VSAssetManagement.Repo
{
    public class PurchaseOrderRepo
    {
        protected VISWASAMUDRAContext _context { get; set; }
        public PurchaseOrderRepo(VISWASAMUDRAContext context)
        {
            _context = context;
        }

        public List<PurchaseOrder> getAllList()
        {
            return _context.PurchaseOrder.ToList();
        }

        public int createAsset(PurchaseOrder record)
        {
            _context.PurchaseOrder.Add(record);
            _context.SaveChanges();
            return record.Id;
        }

        public PurchaseOrder getById(int id)
        {
            return _context.PurchaseOrder.Where(a=>a.Id==id).FirstOrDefault();
        }

        public int update(PurchaseOrder record)
        {
            _context.PurchaseOrder.Update(record);
            return _context.SaveChanges();
        }

        public int delete(int id)
        {
            _context.PurchaseOrder.Remove(getById(id));
            return _context.SaveChanges();
        }
    }
}