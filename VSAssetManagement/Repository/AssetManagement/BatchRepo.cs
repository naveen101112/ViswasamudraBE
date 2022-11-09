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
            _context.Update(record).Property(x => x.Id).IsModified = false; ;
            return _context.SaveChanges();
        }

        public List<dynamic> GetAllWithPO()
        {
            IQueryable<mo.Batch> Batchquery = _context.Set<mo.Batch>();
            IQueryable<mo.PurchaseOrder> POquery = _context.Set<mo.PurchaseOrder>();

            var result = from x in Batchquery
                         from y in POquery.Where(y => y.Guid == x.PurchaseOrderId)
                         select new io.Batch
                         {
                             Id=x.Id,
                             BatchNo=x.BatchNo,
                             BatchDescription=x.BatchDescription,
                             BatchQuantity=x.BatchQuantity,
                             AssetType= _context.LookupTypeValue.Where(l => l.Guid == x.AssetType).FirstOrDefault().Name,
                             AssetSpecification= _context.LookupTypeValue.Where(l => l.Guid == x.AssetSpecification).FirstOrDefault().Name,
                             CreatedBy=x.CreatedBy,
                             CreatedDateTime=x.CreatedDateTime,
                             LastUpdatedBy=x.LastUpdatedBy,
                             LastUpdatedDateTime=x.LastUpdatedDateTime,
                             RecordStatus=x.RecordStatus,
                             Guid=x.Guid,
                             Uom=_context.LookupTypeValue.Where(l=>l.Guid == x.Uom).FirstOrDefault().Name,
                             StructureSubType=_context.LookupTypeValue.Where(l => l.Guid == x.StructureSubType).FirstOrDefault().Name,
                             StructureType=_context.LookupTypeValue.Where(l => l.Guid == x.StructureType).FirstOrDefault().Name,
                             BatchStatus=x.BatchStatus,
                             UsageUom= _context.LookupTypeValue.Where(l => l.Guid == x.UsageUom).FirstOrDefault().Name,
                             UseFrequency= x.UseFrequency,
                             InvoiceNo =x.InvoiceNo,
                             InvoiceDate=x.InvoiceDate,
                             ReceivedBy=x.ReceivedBy,
                             ReceivedDate=x.ReceivedDate,
                             PurchaseOrderId=y.Id.ToString(),
                             PurchaseOrderNo=y.PurchaseOrderNo,
                             PurchaseOrderDate=y.PurchaseOrderDate

                         };

            return result.ToList<dynamic>();
        }

        public List<dynamic> searchListQuery(io.BatchSearch batch)
        {
            IQueryable<mo.Batch> Batchquery = _context.Set<mo.Batch>();
            IQueryable<mo.PurchaseOrder> POquery = _context.Set<mo.PurchaseOrder>();

            var result = from x in Batchquery
                         from y in POquery.Where(y => y.Guid == x.PurchaseOrderId)
                         select new
                         {
                             x.Id,
                             x.BatchNo,
                             x.BatchDescription,
                             x.BatchQuantity,
                             x.AssetType,
                             x.AssetSpecification,
                             x.CreatedBy,
                             x.CreatedDateTime,
                             x.LastUpdatedBy,
                             x.LastUpdatedDateTime,
                             x.RecordStatus,
                             x.Guid,
                             x.Uom,
                             x.StructureSubType,
                             x.StructureType,
                             x.BatchStatus,
                             x.UsageUom,
                             x.UseFrequency,
                             x.InvoiceNo,
                             x.InvoiceDate,
                             x.ReceivedBy,
                             x.ReceivedDate,
                             x.PurchaseOrderId,
                             y.PurchaseOrderNo,
                             y.PurchaseOrderDate

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

        public mo.Batch getById(Guid guid)
        {
            return _context.Batch.Where(a =>a.Guid == guid).FirstOrDefault();
        }

        public IEnumerable<dynamic> getDataGrid()
        {
            return (from record in _context.Batch
                    select new
                    {
                        record.Id,
                        PurchaseOrderID = record.PurchaseOrderId,
                        record.BatchNo,
                        Name = record.BatchDescription,
                        record.BatchQuantity,
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
                        PurchaseOrderID = record.PurchaseOrderId,
                        record.BatchNo,
                        Name = record.BatchDescription,
                        record.BatchQuantity,
                        record.AssetType,
                        record.AssetSpecification,
                        record.Guid
                    }).FirstOrDefault();

        }
    }
}