using VSAssetManagement.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace VSAssetManagement.Repo
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
            return _context.Batch.Where(a=>a.Id==id).FirstOrDefault();
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
                        Id = record.Id,
                        PurchaseOrderID = record.PurchaseBatchMasterGuid,
                        BatchNo = record.BatchNo,
                        Name = record.BatchName,
                        Quantity = record.Quantity,
                        AssetType = record.AssetType,
                        AssetSize = record.AssetSize,
                        Guid = record.Guid
                    }).ToList();

        }

        public dynamic getbyIdEdit(int id)
        {
            return (from record in _context.Batch
                    where record.Id == id
                    select new
                    {
                        Id = record.Id,
                        PurchaseOrderID = record.PurchaseBatchMasterGuid,
                        BatchNo = record.BatchNo,
                        Name = record.BatchName,
                        Quantity = record.Quantity,
                        AssetType = record.AssetType,
                        AssetSize = record.AssetSize,
                        Guid = record.Guid
                    }).FirstOrDefault();

        }
    }
}