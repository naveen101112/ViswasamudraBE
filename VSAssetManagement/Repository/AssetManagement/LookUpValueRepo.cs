using VSManagement.Models.VISWASAMUDRA;
using mo = VSAssetManagement.IOModels;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace VSManagement.Repository.AssetManagement
{
    public class LookUpValueRepo
    {
        public VISWASAMUDRAContext _context { get; set; }
        public LookUpValueRepo(VISWASAMUDRAContext context)
        {
            _context = context;
        }

        public List<LookupTypeValue> getAllList()
        {
            return _context.LookupTypeValue.ToList();
        }

        public Guid create(LookupTypeValue record)
        {
            record.CreatedDateTime = DateTime.Now;
            record.LastUpdatedDateTime = DateTime.Now;
            _context.LookupTypeValue.Add(record);
            _context.SaveChanges();
            return record.Guid;
        }

        public LookupTypeValue getByOnlyId(int id)
        {
            return _context.LookupTypeValue.Where(a => a.Id == id).FirstOrDefault();
        }



        public int delete(Guid id)
        {
            _context.LookupTypeValue.Remove(getByGuid(id));
            return _context.SaveChanges();
        }

        public LookupTypeValue getById(int id, Guid guid)
        {
            return _context.LookupTypeValue.Where(a => a.Id == id && a.Guid == guid).FirstOrDefault();
        }

        public LookupTypeValue getByGuid(Guid guid)
        {
            return _context.LookupTypeValue.Where(a => a.Guid == guid).FirstOrDefault();
        }

        public List<dynamic> searchListQuery(mo.LookupTypeValue record)
        {
            IQueryable<LookupTypeValue> TypeValuequery = _context.Set<LookupTypeValue>();
            IQueryable<LookupType> Typequery = _context.Set<LookupType>();

            if (record.Guid != Guid.Empty)
            {
                TypeValuequery = TypeValuequery.Where(t => t.Guid == record.Guid);
            }
            if (record.LookupTypeId != Guid.Empty)
            {
                TypeValuequery = TypeValuequery.Where(t => t.LookupTypeId == record.LookupTypeId);
            }
            var result = from x in TypeValuequery
                         from y in Typequery.Where(y => y.Guid == x.LookupTypeId)
                         select new
                         {
                             x.Guid,
                             x.Id,
                             x.Code,
                             x.Name,
                             x.LookupTypeId,
                             LookupTypeName = y.Name,
                             LookupTypeCode=y.Code

                         };

            return result.ToList<dynamic>();
        }

        public dynamic getLookUpDropDownById(Guid id)
        {
            return (from value in _context.LookupTypeValue
                    join lookup in _context.LookupType
                    on value.LookupTypeId equals lookup.Guid
                    where lookup.Guid == id
                       && lookup.RecordStatus != 1
                       && value.RecordStatus != 1
                    select new
                    {
                        value.Guid,
                        value.Code,
                        value.Name
                    }
             );
        }

        public dynamic getLookUpDropDownByCode(string code)
        {
            return (from value in _context.LookupTypeValue
                    join lookup in _context.LookupType
                    on value.LookupTypeId equals lookup.Guid
                    where lookup.Code == code
                       && lookup.RecordStatus == 1
                       && value.RecordStatus == 1
                    select new
                    {
                        value.Guid,
                        value.Code,
                        value.Name
                    }
             );
        }
    }
}