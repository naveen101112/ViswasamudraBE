using mo=VSManagement.Models.VISWASAMUDRA;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using io = VSAssetManagement.IOModels;
using VSAssetManagement.IOModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using System.Data.SqlClient;
using VSManagement.Models.VISWASAMUDRA;

namespace VSManagement.Repository.AssetManagement
{
    public class BatchRepo
    {
        public mo.VISWASAMUDRAContext _context { get; set; }
        public string _connection { get; set; }
        public BatchRepo(mo.VISWASAMUDRAContext context)
        {
            _context = context;
            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            IConfigurationRoot configuration = builder.Build();
            _connection = configuration.GetConnectionString("VISWASAMUDRA");
        }

        public List<mo.Batch> getAllList()
        {
            return _context.Batch.ToList();
        }

        public int create(mo.Batch record)
        {
            SqlConnection con = new SqlConnection(_connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("Create_Batch", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BatchDescription", record.BatchDescription);
            cmd.Parameters.AddWithValue("@BatchNo", record.BatchNo);
            cmd.Parameters.AddWithValue("@AssetSpecification", record.AssetSpecification);
            cmd.Parameters.AddWithValue("@AssetType", record.AssetType);
            cmd.Parameters.AddWithValue("@PurchaseOrderId", record.PurchaseOrderId);
            cmd.Parameters.AddWithValue("@BatchQuantity", record.BatchQuantity);
            cmd.Parameters.AddWithValue("@BatchStatus", record.BatchStatus);
            cmd.Parameters.AddWithValue("@InvoiceNo", record.InvoiceNo);
            cmd.Parameters.AddWithValue("@InvoiceDate", record.InvoiceDate);
            cmd.Parameters.AddWithValue("@ReceivedDate", record.ReceivedDate);
            cmd.Parameters.AddWithValue("@ReceivedBy", record.ReceivedBy);
            cmd.Parameters.AddWithValue("@StructureType", record.StructureType);
            cmd.Parameters.AddWithValue("@UseFrequency", record.UseFrequency);
            cmd.Parameters.AddWithValue("@StructureSubType", record.StructureSubType);
            cmd.Parameters.AddWithValue("@UsageUom", record.UsageUom);
            cmd.Parameters.AddWithValue("@Uom", record.Uom);
            cmd.Parameters.AddWithValue("@CreatedBy", "SYSTEM");
            cmd.Parameters.AddWithValue("@UpdatedBy", "SYSTEM");
            var result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
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