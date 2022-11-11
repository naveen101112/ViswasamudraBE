using VSManagement.Models.VISWASAMUDRA;
using System.Collections.Generic;
using System.Linq;
using System;
using io = VSAssetManagement.IOModels;

namespace VSManagement.Repository.AssetManagement
{
    public class AssetRequisitionHeaderRepo
    {
        protected VISWASAMUDRAContext _context { get; set; }
        public AssetRequisitionHeaderRepo(VISWASAMUDRAContext context)
        {
            _context = context;
        }

        public List<AssetRequisitionHeader> getAllList()
        {
            return _context.AssetRequisitionHeader.ToList();
        }

        public List<dynamic> searchListQuery(io.AssetRequisitionHeader res)
        {
            IQueryable<AssetRequisitionHeader> query = _context.Set<AssetRequisitionHeader>();
            if (res.Guid != Guid.Empty)
            {
                query = query.Where(t => t.Guid == res.Guid);
            }

            IQueryable<LookupTypeValue> lquery = _context.Set<LookupTypeValue>();
            IQueryable<Project> prjQuery = _context.Set<Project>();

            var result = from x in query
                         from y in lquery.Where(y => y.Guid == x.TaskType)
                         from z in prjQuery.Where(z=>z.Guid == x.Project)
                         select new io.AssetRequisitionHeader
                         {
                             Id=x.Id,
                             AssetRequisitionNo = x.AssetRequisitionNo,
                             AssetRequisitionDate = x.AssetRequisitionDate,
                             TaskType=y.Name,
                             Project=z.ProjectName,
                             RequiredFromDate = x.RequiredFromDate,
                             RequestedBy = x.RequestedBy,
                             ApprovedBy=x.ApprovedBy,
                             Remarks=x.Remarks,
                             RequisitionStatus=x.RequisitionStatus,
                             CreatedBy=x.CreatedBy,
                             CreatedDateTime=x.CreatedDateTime,
                             LastUpdatedBy=x.LastUpdatedBy,
                             LastUpdatedDateTime=x.LastUpdatedDateTime,
                             RecordStatus=x.RecordStatus,
                             Guid=x.Guid,
                         };
            return result.ToList<dynamic>();
        }

        public Guid createReason(AssetRequisitionHeader record)
        {
            _context.AssetRequisitionHeader.Add(record);
            _context.SaveChanges();
            return record.Guid;
        }

        public AssetRequisitionHeader getById(Guid id)
        {
            return _context.AssetRequisitionHeader.Where(a => a.Guid == id).FirstOrDefault();
        }

        public int update(AssetRequisitionHeader record)
        {
            AssetRequisitionHeader OldRecord = getById(record.Guid);

            AssetRequisitionHeader NewRecord = OldRecord;
            NewRecord.LastUpdatedDateTime = System.DateTime.Now;
            NewRecord.LastUpdatedBy = string.IsNullOrEmpty(record.LastUpdatedBy) ? "SYSTEM" : record.LastUpdatedBy;

            _context.AssetRequisitionHeader.Update(NewRecord).Property(x => x.Id).IsModified = false; 
            return _context.SaveChanges();
        }

        public int delete(Guid id)
        {
            _context.AssetRequisitionHeader.Remove(getById(id));
            return _context.SaveChanges();
        }
    }
}