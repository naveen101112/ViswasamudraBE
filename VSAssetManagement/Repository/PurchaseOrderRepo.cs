using VSAssetManagement.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Globalization;

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
                        PurchaseOrderNo = record.PurchaseOrderNo,
                        PurchaseOrderDate = StaticData.getDateString(record.PurchaseOrderDate.Value),
                        ReceivedBy = record.ReceivedBy,
                        ReceivedDate = StaticData.getDateString(record.ReceivedDate.Value),
                        Guid = record.Guid
                    }
                    ).FirstOrDefault();
        }

        public PurchaseOrder getById(int id, Guid guid)
        {
            return _context.PurchaseOrder.Where(a=>a.Id==id && a.Guid == guid).FirstOrDefault();
        }

        public PurchaseOrder getByOnlyId(int id)
        {
            return _context.PurchaseOrder.Where(a => a.Id == id).FirstOrDefault();
        }

        public int update(PurchaseOrder record)
        {
            _context.Update(record);
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
                        Id = record.Id,
                        OrderNo = record.PurchaseOrderNo,
                        OrderDate = StaticData.getDateString(record.PurchaseOrderDate.Value),
                        ReceivedBy = record.ReceivedBy,
                        ReceivedDate = StaticData.getDateString(record.ReceivedDate.Value),
                        Guid = record.Guid
                    }).ToList();

        }
    }
}