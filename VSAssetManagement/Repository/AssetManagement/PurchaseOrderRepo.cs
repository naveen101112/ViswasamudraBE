using VSManagement.Models.VISWASAMUDRA;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Globalization;
using VSAssetManagement;
using io = VSAssetManagement.IOModels;

namespace VSManagement.Repository.AssetManagement
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
        public List<PurchaseOrder> searchListQuery(io.PurchaseOrder po)
        {
            IQueryable<PurchaseOrder> query = _context.Set<PurchaseOrder>();
            if (po.Guid != null)
            {
                query = query.Where(t => t.Guid == po.Guid);
            }
            return query.ToList<PurchaseOrder>();
        }
        public int create(PurchaseOrder record)
        {
            _context.PurchaseOrder.Add(record);
            _context.SaveChanges();
            return record.Id;
        }

        public dynamic getByIdEdit(int id)
        {
            //return _context.PurchaseOrder.Where(a=>a.Id==id).FirstOrDefault();
            return (from record in _context.PurchaseOrder
                    where record.Id == id
                    select new
                    {
                        id = record.Id,
                        record.PurchaseOrderNo,
                        PurchaseOrderDate = StaticData.getDateString(record.PurchaseOrderDate.Value),
                        record.Guid
                    }
                    ).FirstOrDefault();
        }

        public PurchaseOrder getById(int id, Guid guid)
        {
            return _context.PurchaseOrder.Where(a => a.Id == id || a.Guid == guid).FirstOrDefault();
        }

        public PurchaseOrder getByOnlyId(int id)
        {
            return _context.PurchaseOrder.Where(a => a.Id == id).FirstOrDefault();
        }

        public int update(PurchaseOrder record)
        {
            _context.Update(record).Property(x => x.Id).IsModified = false; ;
            return _context.SaveChanges();
        }

        public int delete(int id)
        {
            _context.PurchaseOrder.Remove(getByOnlyId(id));
            return _context.SaveChanges();
        }

        public IEnumerable<dynamic> getDataGrid()
        {
            return (from record in _context.PurchaseOrder
                    select new
                    {
                        record.Id,
                        OrderNo = record.PurchaseOrderNo,
                        OrderDate = StaticData.getDateString(record.PurchaseOrderDate.Value),
                        record.Guid
                    }).ToList();

        }

        public List<PurchaseOrder> getDropDown()
        {
            return (from po in _context.PurchaseOrder
                    select new PurchaseOrder { PurchaseOrderNo=po.PurchaseOrderNo }).ToList();
        }
    }
}