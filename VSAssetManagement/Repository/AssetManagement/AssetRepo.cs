using mo=VSManagement.Models.VISWASAMUDRA;
using System.Collections.Generic;
using System.Linq;
using io = VSAssetManagement.IOModels;
using System;
using ViswasamudraCommonObjects.Util;
using VSAssetManagement.IOModels;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using VSManagement.Models.VISWASAMUDRA;

namespace VSManagement.Repository.AssetManagement
{
    public class AssetRepo
    {
        protected mo.VISWASAMUDRAContext _context { get; set; }
        public string _connection { get; set; }
        public AssetRepo(mo.VISWASAMUDRAContext context)
        {
            _context = context;
            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            IConfigurationRoot configuration = builder.Build();
            _connection = configuration.GetConnectionString("VISWASAMUDRA");
        }

        public List<mo.Asset> getDropDown()
        {
            return (from asset in _context.Asset
                    where asset.RecordStatus == 1
                    select new mo.Asset { AssetCode = asset.AssetCode, AssetName = asset.AssetName, Guid = asset.Guid, Id = asset.Id }).ToList();
        }

        public List<dynamic> GetAssetData(io.Asset asset)
        {
            IQueryable<mo.Asset> Assetquery = _context.Set<mo.Asset>().OrderByDescending(x => x.Id); 
            IQueryable<mo.AssetHistory> AssetHistoryquery = _context.Set<mo.AssetHistory>();
            IQueryable<mo.Tag> Tagquery = _context.Set<mo.Tag>();

            var result = from x in Assetquery
                         join y in AssetHistoryquery on x.Guid equals y.AssetId 
                         join z in Tagquery.DefaultIfEmpty() on x.TagId equals z.Guid into AssetHistoryAndTag 
                         from z in AssetHistoryAndTag.DefaultIfEmpty()
                         select new io.Asset
                         {
                             Id = x.Id,
                             AssetCode = x.AssetCode,
                             AssetName = x.AssetName,
                             TagId = x.TagId,
                             TagName = z.Name,
                             StructureType =x.StructureType,
                             StructureName = _context.LookupTypeValue.Where(l => l.Guid == x.StructureType).FirstOrDefault().Name,
                             StructureSubType = x.StructureSubType,
                             StructureSubName = _context.LookupTypeValue.Where(l => l.Guid == x.StructureSubType).FirstOrDefault().Name,
                             AssetType = x.AssetType,
                             AssetTypeName = _context.LookupTypeValue.Where(l => l.Guid == x.AssetType).FirstOrDefault().Name,
                             AssetSpecification = x.AssetSpecification,
                             AssetSpecificationName = _context.LookupTypeValue.Where(l => l.Guid == x.AssetSpecification).FirstOrDefault().Name,
                             CompanyName=x.CompanyName,
                             ProjectCode=x.ProjectCode,
                             ProjectCodeName = _context.Project.Where(l => l.Guid == x.ProjectCode).FirstOrDefault().ProjectName,
                             Store = x.Store,
                             StoreName = _context.Store.Where(l => l.Guid == x.Store).FirstOrDefault().Name,
                             BatchNo=x.BatchNo,
                             AssetStatus=y.AssetStatus,                             
                             AssetStatusName = _context.LookupTypeValue.Where(l => l.Guid == y.AssetStatus).FirstOrDefault().Name,
                             CreatedBy = x.CreatedBy,
                             CreatedDateTime = x.CreatedDateTime,
                             LastUpdatedBy = x.LastUpdatedBy,
                             LastUpdatedDateTime = x.LastUpdatedDateTime,
                             RecordStatus = x.RecordStatus,
                             Guid = x.Guid
                         };
            if (asset.Guid != Guid.Empty)
            {
                result = result.Where(t => t.Guid == asset.Guid);
            }
            result = result.Where(t => t.RecordStatus == 1);

            return result.ToList<dynamic>();
        }

        public List<mo.Asset> getAllListQuery(Pagination page)
        {
            if (page.searchParam == null)
            {
                return _context.Asset.Skip(page.skip()).Take(page.take()).ToList();
            }
            else
            {
                return _context.Asset.Skip(page.skip()).Take(page.take()).ToList();
            }
        }

        public int create(mo.Asset asset)
        {
            _context.Asset.Add(asset);
            _context.SaveChanges();
            return asset.Id;
        }

        public mo.Asset getByOnlyId(int id)
        {
            return _context.Asset.Where(a => a.Id == id).FirstOrDefault();
        }
        public mo.Asset getByGuid(Guid guid)
        {
            return _context.Asset.Where(a => a.Guid == guid).FirstOrDefault();
        }

        public mo.Asset getById(int id, Guid guid)
        {
            return _context.Asset.Where(a => a.Id == id || a.Guid == guid).FirstOrDefault();
        }

        public int update(mo.Asset asset)
        {
            SqlConnection con = new SqlConnection(_connection);
            SqlCommand cmd = new SqlCommand("Asset_Updations", con);
            if (con.State == ConnectionState.Closed) con.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@guid",asset.Guid);
            cmd.Parameters.AddWithValue("@assetCode",asset.AssetCode);
            cmd.Parameters.AddWithValue("@assetName", asset.AssetName);
            cmd.Parameters.AddWithValue("@assetSpec", asset.AssetSpecification);
            cmd.Parameters.AddWithValue("@assetType", asset.AssetType);
            cmd.Parameters.AddWithValue("@batchNo", asset.BatchNo);
            cmd.Parameters.AddWithValue("@company", asset.CompanyName);
            cmd.Parameters.AddWithValue("@updatedby", asset.LastUpdatedBy);
            cmd.Parameters.AddWithValue("@updateddate", asset.LastUpdatedDateTime);
            cmd.Parameters.AddWithValue("@project", asset.ProjectCode);
            cmd.Parameters.AddWithValue("@store", asset.Store);
            cmd.Parameters.AddWithValue("@structureType", asset.StructureType);
            cmd.Parameters.AddWithValue("@structureSubType", asset.StructureSubType);
            cmd.Parameters.AddWithValue("@tagId", asset.TagId);
            var result = cmd.ExecuteNonQuery();
            con.Close();
            return result;

            //_context.Asset.Update(asset).Property(x => x.Id).IsModified = false;
            //return _context.SaveChanges();
        }

        public int delete(int id)
        {
            _context.Asset.Remove(getByOnlyId(id));
            return _context.SaveChanges();
        }

        public int countById(int id)
        {
            return _context.Asset.Where(a => a.Id == id).Count();
        }

        public dynamic getByIdEdit(int id)
        {
            return (from asset in _context.Asset
                    where asset.Id == id
                    select new
                    {
                        asset.Id,
                        asset.AssetCode,
                        asset.AssetName,
                        asset.CompanyName,
                        asset.ProjectCode,
                        asset.Store,
                        asset.BatchNo,
                        asset.Guid
                    }).FirstOrDefault();
        }

        public IEnumerable<dynamic> getDataGrid()
        {
            return (from asset in _context.Asset
                    select new
                    {
                        asset.Id,
                        asset.AssetCode,
                        asset.AssetName,
                        asset.CompanyName,
                        asset.ProjectCode,
                        asset.Store,
                        asset.BatchNo,
                        asset.Guid
                    }).ToList();
        }
    }
}