using mo=VSManagement.Models.VISWASAMUDRA;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using io = VSAssetManagement.IOModels;
using VSAssetManagement.IOModels;

namespace VSManagement.Repository.AssetManagement
{
    public class BatchRepo
    {
        public mo.VISWASAMUDRAContext _context { get; set; }
        public BatchRepo(mo.VISWASAMUDRAContext context)
        {
            _context = context;
        }

        public List<mo.Batch> getAllList()
        {
            return _context.Batch.ToList();
        }

        public int create(mo.Batch record)
        {
            _context.Batch.Add(record);
            _context.SaveChanges();
            return record.Id;
        }

        public mo.Batch getByOnlyId(int id)
        {
            return _context.Batch.Where(a => a.Id == id).FirstOrDefault();
        }

        public int update(mo.Batch record)
        {
            _context.Update(record);
            return _context.SaveChanges();
        }

        public List<dynamic> searchListQuery(io.BatchSearch batch)
        {
            IQueryable<mo.Batch> Batchquery = _context.Set<mo.Batch>();
            IQueryable<mo.PurchaseOrder> POquery = _context.Set<mo.PurchaseOrder>();

            var result = from x in Batchquery
                         from y in POquery.Where(y => y.Guid == x.PurchaseBatchMasterGuid)
                         select new
                         {
                             x.Id,
                             x.BatchNo,
                             x.BatchDescription,
                             x.Quantity,
                             x.AssetType,
                             x.AssetSpecification,
                             x.CreatedBy,
                             x.CreatedDateTime,
                             x.LastUpdatedBy,
                             x.LastUpdatedDateTime,
                             x.RecordStatus,
                             x.Guid,
                             x.PurchaseBatchMasterGuid,
                             y.PurchaseOrderNo,
                             y.PurchaseOrderDate,
                             y.ReceivedBy,
                             y.ReceivedDate

                         };

            if (batch.Guid != Guid.Empty)
            {
                result = result.Where(t => t.Guid == batch.Guid);
            }

            return result.ToList<dynamic>();
        }

        public int delete(int id)
        {
            _context.Batch.Remove(getByOnlyId(id));
            return _context.SaveChanges();
        }

        public mo.Batch getById(int id, Guid guid)
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
                        Name = record.BatchDescription,
                        record.Quantity,
                        record.AssetType,
                        record.AssetSpecification,
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
                        Name = record.BatchDescription,
                        record.Quantity,
                        record.AssetType,
                        record.AssetSpecification,
                        record.Guid
                    }).FirstOrDefault();

        }
    }
}