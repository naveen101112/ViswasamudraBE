using mo=VSManagement.Models.VISWASAMUDRA;
using System.Collections.Generic;
using System.Linq;
using io = VSAssetManagement.IOModels;
using System.Data;
using System.IO;
using static System.Net.WebRequestMethods;
using VSAssetManagement.IOModels;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using VSManagement.Models.VISWASAMUDRA;
using System;

namespace VSManagement.Repository.AssetManagement
{
    public class AssetRequisitionRepo
    {
        protected mo.VISWASAMUDRAContext _context { get; set; }        
        public string _connection { get; set; }
       

        public AssetRequisitionRepo(mo.VISWASAMUDRAContext context)
        {
            _context = context;
            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            IConfigurationRoot configuration = builder.Build();
            _connection = configuration.GetConnectionString("VISWASAMUDRA");
        }

        public List<mo.AssetRequisitionHeader> getAllList()
        {
            return _context.AssetRequisitionHeader.ToList();
        }

        public List<io.AssetRequisitionDetails> searchdetailQuery(io.AssetRequisitionHeader res)
        {
            IQueryable<mo.AssetRequisitionDetails> query = _context.Set<mo.AssetRequisitionDetails>();
            if (res.Guid != Guid.Empty)
            {
                query = query.Where(t => t.AssetRequisitionHeader == res.Guid);
            }
            var Result= (from ard in query.Where(x => x.RecordStatus == 1)
                    select new io.AssetRequisitionDetails
                    {
                        StructureType= ard.StructureType,
                        StructureTypeName = String.IsNullOrEmpty(ard.StructureType.ToString()) ? "" : _context.LookupTypeValue.Where(l => l.Guid == ard.StructureType).FirstOrDefault().Name,
                        StructureSubType=ard.StructureSubType,
                        StructureSubTypeName= String.IsNullOrEmpty(ard.StructureSubType.ToString()) ? "" : _context.LookupTypeValue.Where(l => l.Guid == ard.StructureSubType).FirstOrDefault().Name,
                        AssetType= ard.AssetType,
                        AssetTypeName = String.IsNullOrEmpty(ard.AssetType.ToString()) ? "" : _context.LookupTypeValue.Where(l => l.Guid == ard.AssetType).FirstOrDefault().Name,
                        AssetSpecification = ard.AssetSpecification,
                        AssetSpecificationName = String.IsNullOrEmpty(ard.AssetSpecification.ToString()) ? "" : _context.LookupTypeValue.Where(l => l.Guid == ard.AssetSpecification).FirstOrDefault().Name,
                        AssetRequisitionHeader =ard.AssetRequisitionHeader,
                        Uom=ard.Uom,
                        UomName = String.IsNullOrEmpty(ard.Uom.ToString()) ? "" : _context.LookupTypeValue.Where(l => l.Guid == ard.Uom).FirstOrDefault().Name,
                        QuantityRequired = ard.QuantityRequired,
                        CreatedDateTime = ard.CreatedDateTime,
                        LastUpdatedDateTime = ard.LastUpdatedDateTime,
                        CreatedBy = ard.CreatedBy,
                        Guid = ard.Guid,
                        Id = ard.Id,
                        LastUpdatedBy = ard.LastUpdatedBy,                        
                        RecordStatus = ard.RecordStatus
                    }).ToList();

            return (List<io.AssetRequisitionDetails>)Result;
        }

        public List<dynamic> searchListQuery(io.AssetRequisitionHeader res)
        {
            IQueryable<mo.AssetRequisitionHeader> query = _context.Set<mo.AssetRequisitionHeader>();
            if (res.Guid != Guid.Empty)
            {
                query = query.Where(t => t.Guid == res.Guid);
            }

            IQueryable<mo.LookupTypeValue> lquery = _context.Set<mo.LookupTypeValue>();
            IQueryable<mo.Project> prjQuery = _context.Set<mo.Project>();

            var result = from x in query
                         from y in lquery.Where(y => y.Guid == x.TaskType)
                         from z in prjQuery.Where(z => z.Guid == x.Project)
                         select new io.AssetRequisitionHeader
                         {
                             Id = x.Id,
                             AssetRequisitionNo = x.AssetRequisitionNo,
                             AssetRequisitionDate = x.AssetRequisitionDate,
                             TaskType = x.TaskType,
                             Project = x.Project,
                             TaskTypeName = y.Name,
                             ProjectName = z.ProjectName,
                             RequiredFromDate = x.RequiredFromDate,
                             RequiredToDate = x.RequiredToDate,
                             RequestedBy = x.RequestedBy,
                             ApprovedBy = x.ApprovedBy,
                             Remarks = x.Remarks,
                             RequisitionStatus = x.RequisitionStatus,
                             RequisitionStatusName=y.Name,//_context.LookupTypeValue.Where(l => l.Guid == x.RequisitionStatus).FirstOrDefault().Name,
                             CreatedBy = x.CreatedBy,
                             CreatedDateTime = x.CreatedDateTime,
                             LastUpdatedBy = x.LastUpdatedBy,
                             LastUpdatedDateTime = x.LastUpdatedDateTime,
                             RecordStatus = x.RecordStatus,
                             Guid = x.Guid,
                         };
            return result.ToList<dynamic>();
        }

        public DataTable createTableFordetails(mo.AssetRequisition record)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("StructureType");
            dt.Columns.Add("StructureSubType");
            dt.Columns.Add("AssetType");
            dt.Columns.Add("AssetSpecification");
            dt.Columns.Add("QuantityRequired");
            dt.Columns.Add("Uom");

            DataRow dr = null;

            foreach (var detail in record.details)
            {
                dr = dt.NewRow();
                dr["StructureType"] = detail.StructureType;
                dr["StructureSubType"] = detail.StructureSubType;
                dr["AssetType"] = detail.AssetType;
                dr["AssetSpecification"] = detail.AssetSpecification;
                dr["QuantityRequired"] = detail.QuantityRequired;
                dr["Uom"] = detail.Uom;
                dt.Rows.Add(dr);
            }
            return dt;
        }

        public int opsAsserReq(mo.AssetRequisition record,string op)
        {
            DataTable dt = createTableFordetails(record);  
            SqlParameter dtparameter = new SqlParameter("@ardetails", dt)
            {
                SqlDbType = SqlDbType.Structured,
                TypeName = "[dbo].[ASSET_REQUISITION_DETAILS_TYPE]",
                Direction = ParameterDirection.Input,
            };

            SqlConnection con = new SqlConnection(_connection);
            SqlCommand cmd = new SqlCommand("Asset_Requestion_Operation", con);
            if (con.State == ConnectionState.Closed) con.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            if (op == "U") cmd.Parameters.AddWithValue("@guid", record.header.Guid);
            if (op == "U") cmd.Parameters.AddWithValue("@astreqdate", record.header.AssetRequisitionDate);
            cmd.Parameters.AddWithValue("@tasttype", record.header.TaskType);
            cmd.Parameters.AddWithValue("@project", record.header.Project);
            cmd.Parameters.AddWithValue("@astreqfromdate", record.header.RequiredFromDate);
            cmd.Parameters.AddWithValue("@astreqtodate", record.header.RequiredToDate);
            cmd.Parameters.AddWithValue("@requestedBy", record.header.RequestedBy);
            cmd.Parameters.AddWithValue("@approvedBy", record.header.ApprovedBy);
            cmd.Parameters.AddWithValue("@remarks", record.header.Remarks);
            if(op=="I")cmd.Parameters.AddWithValue("@createdby", "System");
            cmd.Parameters.AddWithValue("@updatedby", "System");            
            cmd.Parameters.AddWithValue("@Opstatus", op);
            cmd.Parameters.Add(dtparameter);

            var result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
            
        }

        public mo.AssetRequisitionHeader getById(Guid id)
        {
            return _context.AssetRequisitionHeader.Where(a => a.Guid == id).FirstOrDefault();
        }

        public int delete(Guid id)
        {
            _context.AssetRequisitionHeader.Remove(getById(id));
            return _context.SaveChanges();
        }
    }
}