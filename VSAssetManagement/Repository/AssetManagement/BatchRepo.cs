using VSManagement.Models.VISWASAMUDRA;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace VSManagement.Repository.AssetManagement
{
    public class BatchRepo
    {
        public VISWASAMUDRAContext _context { get; set; }
        public BatchRepo(VISWASAMUDRAContext context)
        {
            _context = context;
        }

        public List<Batch> getAllList()
        {
            return _context.Batch.ToList();
        }

        public int create(Batch record)
        {
            _context.Batch.Add(record);
            _context.SaveChanges();
            return record.Id;
        }

        public Batch getByOnlyId(int id)
        {
            return _context.Batch.Where(a => a.Id == id).FirstOrDefault();
        }

        public int update(Batch record)
        {
            _context.Update(record);
            return _context.SaveChanges();
        }

        public int delete(int id)
        {
            _context.Batch.Remove(getByOnlyId(id));
            return _context.SaveChanges();
        }

        public Batch getById(int id, Guid guid)
        {
            return _context.Batch.Where(a => a.Id == id && a.Guid == guid).FirstOrDefault();
        }

        public IEnumerable<dynamic> getDataGrid()
        {
            return (from record in _context.Batch
                    select new
                    {
                        record.Id,
                        PurchaseOrderID = record.PurchaseBatchMasterGuid,
                        record.BatchNo,
                        Name = record.BatchName,
                        record.Quantity,
                        record.AssetType,
                        record.AssetSize,
                        record.Guid
                    }).ToList();

        }

        public dynamic getbyIdEdit(int id)
        {
            return (from record in _context.Batch
                    where record.Id == id
                    select new
                    {
                        record.Id,
                        PurchaseOrderID = record.PurchaseBatchMasterGuid,
                        record.BatchNo,
                        Name = record.BatchName,
                        record.Quantity,
                        record.AssetType,
                        record.AssetSize,
                        record.Guid
                    }).FirstOrDefault();

        }
    }
}