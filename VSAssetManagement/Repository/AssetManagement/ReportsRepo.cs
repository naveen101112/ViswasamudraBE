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
using VSManagement.SQLHelper;
using Newtonsoft.Json;

namespace VSManagement.Repository.AssetManagement
{
    public class ReportsRepo
    {
        protected mo.VISWASAMUDRAContext _context { get; set; }
        public string _connection { get; set; }
        SqlConnection con;
        public ReportsRepo(mo.VISWASAMUDRAContext context)
        {
            _context = context;
            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            IConfigurationRoot configuration = builder.Build();
            _connection = configuration.GetConnectionString("VISWASAMUDRA");            
        }

        public List<io.DetailedReport> GetStoreWiseData()
        {
            try
            {
                List<io.DetailedReport> detailedReport = new List<io.DetailedReport>();

                SqlConnection con = new SqlConnection(_connection);
                SqlCommand cmd = new SqlCommand("GET_DETAILED_SUMMARY_REPORT", con);
                if (con.State == ConnectionState.Closed) con.Open();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                List<io.DetailedReport> firstdetailedReport =
                JsonConvert.DeserializeObject<List<io.DetailedReport>>
                (JsonConvert.SerializeObject(getSummaryDetailStructure(ds.Tables[0])));

                List<io.SubStructureReport> seconddetailedReport =
                JsonConvert.DeserializeObject<List<io.SubStructureReport>>
                (JsonConvert.SerializeObject(getSummaryDetailSubstructure(ds.Tables[1])));

                List<io.AssertTypeReport> thirddetailedReport =
                JsonConvert.DeserializeObject<List<io.AssertTypeReport>>
                (JsonConvert.SerializeObject(getSummaryDetailAssettype(ds.Tables[2])));

                List<io.AssertSpecReport> fourthdetailedReport =
                JsonConvert.DeserializeObject<List<io.AssertSpecReport>>
                (JsonConvert.SerializeObject(getSummaryDetailAssetspec(ds.Tables[3])));


                foreach (var item in firstdetailedReport)
                {
                    DetailedReport detailedReport1 = new DetailedReport();
                    List<SubStructureReport> subStructureReportlst = new List<SubStructureReport>();

                    detailedReport1.STRUCTURE = item.STRUCTURE;
                    detailedReport1.TOTAL = item.TOTAL;
                    detailedReport1.AVAILABLE = item.AVAILABLE;
                    detailedReport1.UNDER_USE = item.UNDER_USE;
                    detailedReport1.TRFR_INWARD = item.TRFR_INWARD;
                    detailedReport1.TRFR_OUTWARD = item.TRFR_OUTWARD;
                    detailedReport1.UNDER_REPAIR = item.UNDER_REPAIR;
                    detailedReport1.UNDER_SCRAP = item.UNDER_SCRAP;
                    detailedReport1.PURCHASED_QTY = item.PURCHASED_QTY;
                    
                    var subStructureDetails = seconddetailedReport.Where(q => q.STRUCTURE == item.STRUCTURE).ToList();
                    foreach (var item1 in subStructureDetails)
                    {
                        SubStructureReport subStructureReport = new SubStructureReport();
                        List<AssertTypeReport> assertTypeReportlst = new List<AssertTypeReport>();
                        subStructureReport.SUB_STRUCTURE = item1.SUB_STRUCTURE;
                        subStructureReport.STRUCTURE = item1.STRUCTURE;
                        subStructureReport.TOTAL = item1.TOTAL;
                        subStructureReport.AVAILABLE = item1.AVAILABLE;
                        subStructureReport.UNDER_USE = item1.UNDER_USE;
                        subStructureReport.TRFR_INWARD = item1.TRFR_INWARD;
                        subStructureReport.TRFR_OUTWARD = item1.TRFR_OUTWARD;
                        subStructureReport.UNDER_REPAIR = item1.UNDER_REPAIR;
                        subStructureReport.UNDER_SCRAP = item1.UNDER_SCRAP;
                        subStructureReport.PURCHASED_QTY = item1.PURCHASED_QTY;
                        var assettypeinloop = thirddetailedReport.Where
                            (q => q.STRUCTURE == item.STRUCTURE && q.SUB_STRUCTURE == item1.SUB_STRUCTURE).ToList();

                        foreach (var item2 in assettypeinloop)
                        {                            
                            AssertTypeReport assertTypeReport = new AssertTypeReport();
                            List<AssertSpecReport> assertSpecReportlst = new List<AssertSpecReport>();
                            assertTypeReport.ASSET_TYPE = item2.ASSET_TYPE;
                            assertTypeReport.SUB_STRUCTURE = item2.SUB_STRUCTURE;
                            assertTypeReport.STRUCTURE = item2.STRUCTURE;
                            assertTypeReport.TOTAL = item2.TOTAL;
                            assertTypeReport.AVAILABLE = item2.AVAILABLE;
                            assertTypeReport.UNDER_USE = item2.UNDER_USE;
                            assertTypeReport.TRFR_INWARD = item2.TRFR_INWARD;
                            assertTypeReport.TRFR_OUTWARD = item2.TRFR_OUTWARD;
                            assertTypeReport.UNDER_REPAIR = item2.UNDER_REPAIR;
                            assertTypeReport.UNDER_SCRAP = item2.UNDER_SCRAP;
                            assertTypeReport.PURCHASED_QTY = item2.PURCHASED_QTY;
                            var assetSpecinloop = fourthdetailedReport.Where
                                (q => q.STRUCTURE == item2.STRUCTURE &&
                                      q.SUB_STRUCTURE == item2.SUB_STRUCTURE &&
                                      q.ASSET_TYPE == item2.ASSET_TYPE).ToList();
                            foreach (var item3 in assetSpecinloop)
                            {
                                AssertSpecReport assertSpecReport = new AssertSpecReport();
                                assertSpecReport.ASSET_TYPE = item3.ASSET_TYPE;
                                assertSpecReport.ASSET_SPEC = item3.ASSET_SPEC;
                                assertSpecReport.SUB_STRUCTURE = item3.SUB_STRUCTURE;
                                assertSpecReport.STRUCTURE = item3.STRUCTURE;
                                assertSpecReport.TOTAL = item3.TOTAL;
                                assertSpecReport.AVAILABLE = item3.AVAILABLE;
                                assertSpecReport.UNDER_USE = item3.UNDER_USE;
                                assertSpecReport.TRFR_INWARD = item3.TRFR_INWARD;
                                assertSpecReport.TRFR_OUTWARD = item3.TRFR_OUTWARD;
                                assertSpecReport.UNDER_REPAIR = item3.UNDER_REPAIR;
                                assertSpecReport.UNDER_SCRAP = item3.UNDER_SCRAP;
                                assertSpecReport.PURCHASED_QTY = item3.PURCHASED_QTY;                                                                
                                assertSpecReportlst.Add(assertSpecReport);
                            }

                            assertTypeReport.assertSpecReport = assertSpecReportlst;
                            assertTypeReportlst.Add(assertTypeReport);
                        }

                        subStructureReport.assertTypeReport = assertTypeReportlst;
                        subStructureReportlst.Add(subStructureReport);
                    }
                    detailedReport1.subStructureDetails = subStructureReportlst;
                    detailedReport.Add(detailedReport1);
                }
                
                return detailedReport;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public List<io.StoreReport> GetStore_projectWiseData(StoreReport asr)
        {
            try
            {
                List<StoreReport> storeReportlst = new List<StoreReport>();

                SqlConnection con = new SqlConnection(_connection);
                SqlCommand cmd = new SqlCommand("GET_DETAILED_SUMMARY_REPORT_STR_PRO", con);
                if (con.State == ConnectionState.Closed) con.Open();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);



                List<io.StoreReport> storedetailedReport =
                JsonConvert.DeserializeObject<List<io.StoreReport>>
                (JsonConvert.SerializeObject(getSummaryDetailStore(ds.Tables[0])));

                List<io.ProjectReport> projectdetailedReport =
                JsonConvert.DeserializeObject<List<io.ProjectReport>>
                (JsonConvert.SerializeObject(getSummaryDetailProject(ds.Tables[1])));

                var storeinloop = storedetailedReport.Where
                    (q => q.STRUCTURE == asr.STRUCTURE &&
                    q.SUB_STRUCTURE == asr.SUB_STRUCTURE &&
                    q.ASSET_TYPE == asr.ASSET_TYPE &&
                    q.ASSET_SPEC == asr.ASSET_SPEC).ToList();


                foreach (var storeitem in storeinloop)
                {
                    StoreReport storeReport = new StoreReport();                                   
                    List<ProjectReport> projectReportlst = new List<ProjectReport>();

                    storeReport.ASSET_TYPE = storeitem.ASSET_TYPE;
                    storeReport.ASSET_SPEC = storeitem.ASSET_SPEC;
                    storeReport.SUB_STRUCTURE = storeitem.SUB_STRUCTURE;
                    storeReport.STRUCTURE = storeitem.STRUCTURE;
                    storeReport.STORE_CODE = storeitem.STORE_CODE;
                    storeReport.STORE_NAME = storeitem.STORE_NAME;
                    storeReport.TOTAL = storeitem.TOTAL;
                    storeReport.AVAILABLE = storeitem.AVAILABLE;
                    storeReport.UNDER_USE = storeitem.UNDER_USE;
                    storeReport.TRFR_INWARD = storeitem.TRFR_INWARD;
                    storeReport.TRFR_OUTWARD = storeitem.TRFR_OUTWARD;
                    storeReport.UNDER_REPAIR = storeitem.UNDER_REPAIR;
                    storeReport.UNDER_SCRAP = storeitem.UNDER_SCRAP;
                    storeReport.PURCHASED_QTY = storeitem.PURCHASED_QTY;

                    var projectinloop = projectdetailedReport.Where
                        (q => q.STRUCTURE == storeitem.STRUCTURE &&
                              q.SUB_STRUCTURE == storeitem.SUB_STRUCTURE &&
                              q.ASSET_TYPE == storeitem.ASSET_TYPE &&
                              q.ASSET_SPEC == storeitem.ASSET_SPEC &&
                              q.STORE_CODE == storeitem.STORE_CODE &&
                              q.STORE_NAME == storeitem.STORE_NAME).ToList();

                    foreach (var projectitem in projectinloop)
                    {
                        ProjectReport projectReport = new ProjectReport();
                        projectReport.ASSET_TYPE = projectitem.ASSET_TYPE;
                        projectReport.ASSET_SPEC = projectitem.ASSET_SPEC;
                        projectReport.SUB_STRUCTURE = projectitem.SUB_STRUCTURE;
                        projectReport.STRUCTURE = projectitem.STRUCTURE;
                        projectReport.STORE_CODE = projectitem.STORE_CODE;
                        projectReport.STORE_NAME = projectitem.STORE_NAME;
                        projectReport.PROJECT_CODE = projectitem.PROJECT_CODE;
                        projectReport.PROJECT_NAME = projectitem.PROJECT_NAME;
                        projectReport.STORE_NAME = projectitem.STORE_NAME;
                        projectReport.TOTAL = projectitem.TOTAL;
                        projectReport.AVAILABLE = projectitem.AVAILABLE;
                        projectReport.UNDER_USE = projectitem.UNDER_USE;
                        projectReport.TRFR_INWARD = projectitem.TRFR_INWARD;
                        projectReport.TRFR_OUTWARD = projectitem.TRFR_OUTWARD;
                        projectReport.UNDER_REPAIR = projectitem.UNDER_REPAIR;
                        projectReport.UNDER_SCRAP = projectitem.UNDER_SCRAP;
                        projectReport.PURCHASED_QTY = projectitem.PURCHASED_QTY;
                        projectReportlst.Add(projectReport);
                    }
                    storeReport.projectReports = projectReportlst;
                    storeReportlst.Add(storeReport);                    
                }

                return storeReportlst;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<string> Get_DashBoard_Data()
        {
            try
            {
                SqlConnection con = new SqlConnection(_connection);
                if (con.State == ConnectionState.Closed) con.Open();
                List<string> storedetailedReport= new List<string>();                
                SqlCommand cmd = new SqlCommand("GET_DASHBOARD_DATA", con);                
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);                
                foreach(DataRow dr in ds.Tables[0].Rows)
                {                    
                    storedetailedReport.Add(dr[0].ToString());                    
                }                           
                return storedetailedReport;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<dynamic> getSummaryDetailStructure(DataTable dt)
        {            
            var data = dt.AsEnumerable().Select(row =>
                new
                {
                    STRUCTURE = row["STRUCTURE"].ToString(),
                    TOTAL = row["TOTAL"].ToString(),
                    AVAILABLE = row["AVAILABLE"].ToString(),
                    UNDER_USE = row["UNDER_USE"].ToString(),
                    TRFR_INWARD = row["TRFR_INWARD"].ToString(),
                    TRFR_OUTWARD = row["TRFR_OUTWARD"].ToString(),
                    UNDER_REPAIR = row["UNDER_REPAIR"].ToString(),
                    UNDER_SCRAP = row["UNDER_SCRAP"].ToString(),
                    PURCHASED_QTY = row["PURCHASED_QTY"].ToString(),                    
                });
            return data.ToList();
        }
        public IEnumerable<dynamic> getSummaryDetailSubstructure(DataTable dt)
        {            
            var data = dt.AsEnumerable().Select(row =>
            new
            {
                STRUCTURE = row["STRUCTURE"].ToString(),
                SUB_STRUCTURE = row["SUB_STRUCTURE"].ToString(),
                TOTAL = row["TOTAL"].ToString(),
                AVAILABLE = row["AVAILABLE"].ToString(),
                UNDER_USE = row["UNDER_USE"].ToString(),
                TRFR_INWARD = row["TRFR_INWARD"].ToString(),
                TRFR_OUTWARD = row["TRFR_OUTWARD"].ToString(),
                UNDER_REPAIR = row["UNDER_REPAIR"].ToString(),
                UNDER_SCRAP = row["UNDER_SCRAP"].ToString(),
                PURCHASED_QTY = row["PURCHASED_QTY"].ToString(),                
            });
            return data.ToList();
        }
        public IEnumerable<dynamic> getSummaryDetailAssettype(DataTable dt)
        {            
            var data = dt.AsEnumerable().Select(row =>
            new
            {
                STRUCTURE = row["STRUCTURE"].ToString(),
                SUB_STRUCTURE = row["SUB_STRUCTURE"].ToString(),
                ASSET_TYPE = row["ASSET_TYPE"].ToString(),
                TOTAL = row["TOTAL"].ToString(),
                AVAILABLE = row["AVAILABLE"].ToString(),
                UNDER_USE = row["UNDER_USE"].ToString(),
                TRFR_INWARD = row["TRFR_INWARD"].ToString(),
                TRFR_OUTWARD = row["TRFR_OUTWARD"].ToString(),
                UNDER_REPAIR = row["UNDER_REPAIR"].ToString(),
                UNDER_SCRAP = row["UNDER_SCRAP"].ToString(),
                PURCHASED_QTY = row["PURCHASED_QTY"].ToString(),               
            });
            return data.ToList();
        }
        public IEnumerable<dynamic> getSummaryDetailAssetspec(DataTable dt)
        {            
            var data = dt.AsEnumerable().Select(row =>
            new
            {
                STRUCTURE = row["STRUCTURE"].ToString(),
                SUB_STRUCTURE = row["SUB_STRUCTURE"].ToString(),
                ASSET_TYPE = row["ASSET_TYPE"].ToString(),
                ASSET_SPEC = row["ASSET_SPEC"].ToString(),
                TOTAL = row["TOTAL"].ToString(),
                AVAILABLE = row["AVAILABLE"].ToString(),
                UNDER_USE = row["UNDER_USE"].ToString(),
                TRFR_INWARD = row["TRFR_INWARD"].ToString(),
                TRFR_OUTWARD = row["TRFR_OUTWARD"].ToString(),
                UNDER_REPAIR = row["UNDER_REPAIR"].ToString(),
                UNDER_SCRAP = row["UNDER_SCRAP"].ToString(),
                PURCHASED_QTY = row["PURCHASED_QTY"].ToString(),                
            });
            return data.ToList();
        }
        public IEnumerable<dynamic> getSummaryDetailStore(DataTable dt)
        {           
            var data = dt.AsEnumerable().Select(row =>
            new
            {
                STRUCTURE = row["STRUCTURE"].ToString(),
                SUB_STRUCTURE = row["SUB_STRUCTURE"].ToString(),
                ASSET_TYPE = row["ASSET_TYPE"].ToString(),
                ASSET_SPEC = row["ASSET_SPEC"].ToString(),
                STORE_CODE = row["STORE_CODE"].ToString(),
                STORE_NAME = row["STORE_NAME"].ToString(),
                TOTAL = row["TOTAL"].ToString(),
                AVAILABLE = row["AVAILABLE"].ToString(),
                UNDER_USE = row["UNDER_USE"].ToString(),
                TRFR_INWARD = row["TRFR_INWARD"].ToString(),
                TRFR_OUTWARD = row["TRFR_OUTWARD"].ToString(),
                UNDER_REPAIR = row["UNDER_REPAIR"].ToString(),
                UNDER_SCRAP = row["UNDER_SCRAP"].ToString(),
                PURCHASED_QTY = row["PURCHASED_QTY"].ToString(),                
            });
            return data.ToList();
        }
        public IEnumerable<dynamic> getSummaryDetailProject(DataTable dt)
        {
           
            var data = dt.AsEnumerable().Select(row =>
            new
            {
                STRUCTURE = row["STRUCTURE"].ToString(),
                SUB_STRUCTURE = row["SUB_STRUCTURE"].ToString(),
                ASSET_TYPE = row["ASSET_TYPE"].ToString(),
                ASSET_SPEC = row["ASSET_SPEC"].ToString(),
                STORE_CODE = row["STORE_CODE"].ToString(),
                STORE_NAME = row["STORE_NAME"].ToString(),
                PROJECT_CODE = row["PROJECT_CODE"].ToString(),
                PROJECT_NAME = row["PROJECT_NAME"].ToString(),
                TOTAL = row["TOTAL"].ToString(),
                AVAILABLE = row["AVAILABLE"].ToString(),
                UNDER_USE = row["UNDER_USE"].ToString(),
                TRFR_INWARD = row["TRFR_INWARD"].ToString(),
                TRFR_OUTWARD = row["TRFR_OUTWARD"].ToString(),
                UNDER_REPAIR = row["UNDER_REPAIR"].ToString(),
                UNDER_SCRAP = row["UNDER_SCRAP"].ToString(),
                PURCHASED_QTY = row["PURCHASED_QTY"].ToString(),                
            });
            return data.ToList();
        }

    }
}