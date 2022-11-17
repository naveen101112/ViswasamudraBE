using VSManagement.Models.VISWASAMUDRA;
using System.Collections.Generic;
using System.Linq;
using System;
using io = VSAssetManagement.IOModels;

namespace VSManagement.Repository.AssetManagement
{
    public class ReasonRepo
    {
        protected VISWASAMUDRAContext _context { get; set; }
        public ReasonRepo(VISWASAMUDRAContext context)
        {
            _context = context;
        }

        public List<Reason> getAllList()
        {
            return _context.Reason.ToList();
        }

        public List<dynamic> searchListQuery(io.Reason res)
        {
            IQueryable<Reason> query = _context.Set<Reason>();
            if (res.Guid != Guid.Empty)
            {
                query = query.Where(t => t.Guid == res.Guid);
            }

            IQueryable<LookupTypeValue> lquery = _context.Set<LookupTypeValue>();

            var result = from x in query.Where(x => x.RecordStatus == 1)
                         from y in lquery.Where(y => y.Guid == x.ReasonType)
                         select new io.Reason
                         {
                             Id=x.Id,
                             ReasonName=x.ReasonName,
                             ReasonCode=x.ReasonCode,
                             ReasonType=x.ReasonType,
                             ReasonTypeName = y.Name,
                             CreatedBy=x.CreatedBy,
                             CreatedDateTime=x.CreatedDateTime,
                             LastUpdatedBy=x.LastUpdatedBy,
                             LastUpdatedDateTime=x.LastUpdatedDateTime,
                             RecordStatus=x.RecordStatus,
                             Guid=x.Guid,
                         };
            return result.ToList<dynamic>();
        }

        public Guid createReason(Reason record)
        {
            _context.Reason.Add(record);
            _context.SaveChanges();
            return record.Guid;
        }

        public Reason getById(Guid id)
        {
            return _context.Reason.Where(a => a.Guid == id).FirstOrDefault();
        }

        public int update(Reason record)
        {
            Reason OldRecord = getById(record.Guid);

            Reason NewRecord= OldRecord;
            NewRecord.ReasonCode= record.ReasonCode;
            NewRecord.ReasonName = record.ReasonName;
            NewRecord.ReasonType = record.ReasonType;
            NewRecord.LastUpdatedDateTime = System.DateTime.Now;
            NewRecord.LastUpdatedBy = string.IsNullOrEmpty(record.LastUpdatedBy) ? "SYSTEM" : record.LastUpdatedBy;

            _context.Reason.Update(NewRecord).Property(x => x.Id).IsModified = false; 
            return _context.SaveChanges();
        }

        public int delete(io.Reason request)
        {
            Reason record = getById(request.Guid);
            record.RecordStatus = 0;
            record.LastUpdatedBy = "SYSTEM";
            record.LastUpdatedDateTime = DateTime.Now;
            _context.Update(record).Property(x => x.Id).IsModified = false;
            return _context.SaveChanges();
        }
    }
}