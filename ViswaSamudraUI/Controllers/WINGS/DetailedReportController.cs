using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using ViswaSamudraUI.Providers.Assets;
using VSAssetManagement.IOModels;

namespace ViswaSamudraUI.Controllers.WINGS
{
    public class DetailedReportController : Controller
    {
        ReportDetails Provider = new ReportDetails();
        public IActionResult Index()
        {
            IEnumerable<DetailedReport> drp =Provider.GetSummaryReport();
            string data = "";
            data = data + TableStart()+ TableHeader("Structure");
            data = data+"<tbody>";
            int i=1;
            foreach (var item in drp)
            {                
                data = data + "<tr>";
                data = data + CreateChildLink(item.STRUCTURE+"_Link"+i.ToString());
                data = data + "<td>"+ i.ToString() + "</td> ";
                data = data + "<td>"+ item.STRUCTURE + "</td> ";
                data = data + "<td>" + item.TOTAL + "</td> ";
                data = data + "<td>" + item.AVAILABLE + "</td> ";
                data = data + "<td>" + item.UNDER_USE + "</td> ";
                data = data + "<td>" + item.TRFR_INWARD + "</td> ";
                data = data + "<td>" + item.TRFR_OUTWARD + "</td> ";
                data = data + "<td>" + item.UNDER_REPAIR + "</td> ";
                data = data + "<td>" + item.UNDER_SCRAP + "</td> ";
                data = data + "<td>" + item.PURCHASED_QTY + "</td> ";
                data = data+ " </tr>";

                data = data + "<tr>";
                data = data + innertablehead(item.STRUCTURE + "_Link" + i.ToString(),1);                             
                data = data + TableHeader("SubStructure");
                int j = 1;
                foreach(var substructure in item.subStructureDetails)
                {
                    data = data + "<tr>";
                    data = data + CreateChildLink(substructure.SUB_STRUCTURE + "_Link" + j.ToString());
                    data = data + "<td>" + j.ToString() + "</td> ";
                    data = data + "<td>" + substructure.SUB_STRUCTURE + "</td> ";
                    data = data + "<td>" + substructure.TOTAL + "</td> ";
                    data = data + "<td>" + substructure.AVAILABLE + "</td> ";
                    data = data + "<td>" + substructure.UNDER_USE + "</td> ";
                    data = data + "<td>" + substructure.TRFR_INWARD + "</td> ";
                    data = data + "<td>" + substructure.TRFR_OUTWARD + "</td> ";
                    data = data + "<td>" + substructure.UNDER_REPAIR + "</td> ";
                    data = data + "<td>" + substructure.UNDER_SCRAP + "</td> ";
                    data = data + "<td>" + substructure.PURCHASED_QTY + "</td> ";
                    data = data + " </tr>";

                    data = data + "<tr>";
                    data = data + innertablehead(substructure.SUB_STRUCTURE + "_Link" + j.ToString(),2);
                    data = data + TableHeader("Asset Type");
                    int k = 1;
                    foreach (var assetType in substructure.assertTypeReport)
                    {
                        data = data + "<tr>";
                        data = data + CreateChildLink(assetType.ASSET_TYPE + "_Link" + k.ToString());
                        data = data + "<td>" + k.ToString() + "</td> ";
                        data = data + "<td>" + assetType.ASSET_TYPE + "</td> ";
                        data = data + "<td>" + assetType.TOTAL + "</td> ";
                        data = data + "<td>" + assetType.AVAILABLE + "</td> ";
                        data = data + "<td>" + assetType.UNDER_USE + "</td> ";
                        data = data + "<td>" + assetType.TRFR_INWARD + "</td> ";
                        data = data + "<td>" + assetType.TRFR_OUTWARD + "</td> ";
                        data = data + "<td>" + assetType.UNDER_REPAIR + "</td> ";
                        data = data + "<td>" + assetType.UNDER_SCRAP + "</td> ";
                        data = data + "<td>" + assetType.PURCHASED_QTY + "</td> ";     
                        data = data + "</tr>";

                        data = data + "<tr>";
                        data = data + innertablehead(assetType.ASSET_TYPE + "_Link" + k.ToString(),3);
                        data = data + TableHeader("Asset Specification");
                        int l = 1;
                        foreach (var assetSpec in assetType.assertSpecReport)
                        {
                            data = data + "<tr>";
                            data = data + CreateAssetChildLink(assetSpec);
                            data = data + "<td>" + l.ToString() + "</td> ";
                            data = data + "<td>" + assetSpec.ASSET_SPEC + "</td> ";
                            data = data + "<td>" + assetSpec.TOTAL + "</td> ";
                            data = data + "<td>" + assetSpec.AVAILABLE + "</td> ";
                            data = data + "<td>" + assetSpec.UNDER_USE + "</td> ";
                            data = data + "<td>" + assetSpec.TRFR_INWARD + "</td> ";
                            data = data + "<td>" + assetSpec.TRFR_OUTWARD + "</td> ";
                            data = data + "<td>" + assetSpec.UNDER_REPAIR + "</td> ";
                            data = data + "<td>" + assetSpec.UNDER_SCRAP + "</td> ";
                            data = data + "<td>" + assetSpec.PURCHASED_QTY + "</td> ";
                            data = data + " </tr>";
                        }
                        data = data + "</tbody>";
                        data = data + "</table>";
                        k++;
                    }
                    data = data + "</tbody>";
                    data = data + "</table>";
                    j++;
                }
                data = data + "</tbody>";
                data = data + "</table>";
                i++;
            }
            data = data + "</tbody>";
            data =data+ "</table>";
            ViewBag.HtmlStr = data.Replace("'",@"""").Replace("$SC", "'");
            return View(drp);
        }

        public async Task<string> ShowStoreAndProject(AssertSpecReport asr)
        {
            StoreReport srp = new StoreReport();
            srp.STRUCTURE=asr.STRUCTURE;
            srp.SUB_STRUCTURE = asr.SUB_STRUCTURE;
            srp.ASSET_TYPE = asr.ASSET_TYPE;
            srp.ASSET_SPEC = asr.ASSET_SPEC;

            IEnumerable<StoreReport> drp = Provider.GetStoreSummaryReport(srp);
            string data = "";
            data = data + TableStart() + TableHeader("Store Code","Store Code");
            data = data + "<tbody>";
            int i = 1;
            foreach (var item in drp)
            {
                data = data + "<tr>";
                data = data + CreateChildLink(item.STORE_NAME + "_Link" + i.ToString());
                data = data + "<td>" + i.ToString() + "</td> ";
                data = data + "<td>" + item.STORE_CODE + "</td> ";
                data = data + "<td>" + item.STORE_NAME + "</td> ";
                data = data + "<td>" + item.TOTAL + "</td> ";
                data = data + "<td>" + item.AVAILABLE + "</td> ";
                data = data + "<td>" + item.UNDER_USE + "</td> ";
                data = data + "<td>" + item.TRFR_INWARD + "</td> ";
                data = data + "<td>" + item.TRFR_OUTWARD + "</td> ";
                data = data + "<td>" + item.UNDER_REPAIR + "</td> ";
                data = data + "<td>" + item.UNDER_SCRAP + "</td> ";
                data = data + "<td>" + item.PURCHASED_QTY + "</td> ";
                data = data + " </tr>";
                data = data + "<tr>";
                data = data + innertprotablehead(item.STORE_NAME + "_Link" + i.ToString(), 1);
                data = data + TableHeader("Project Code", "Project Code");
                int j = 1;
                foreach (var assetSpec in item.projectReports)
                {
                    data = data + "<tr>";
                    data = data + "<td></td> ";
                    data = data + "<td>" + j.ToString() + "</td> ";
                    data = data + "<td>" + assetSpec.PROJECT_CODE + "</td> ";
                    data = data + "<td>" + assetSpec.PROJECT_NAME + "</td> ";
                    data = data + "<td>" + assetSpec.TOTAL + "</td> ";
                    data = data + "<td>" + assetSpec.AVAILABLE + "</td> ";
                    data = data + "<td>" + assetSpec.UNDER_USE + "</td> ";
                    data = data + "<td>" + assetSpec.TRFR_INWARD + "</td> ";
                    data = data + "<td>" + assetSpec.TRFR_OUTWARD + "</td> ";
                    data = data + "<td>" + assetSpec.UNDER_REPAIR + "</td> ";
                    data = data + "<td>" + assetSpec.UNDER_SCRAP + "</td> ";
                    data = data + "<td>" + assetSpec.PURCHASED_QTY + "</td> ";
                    data = data + " </tr>";
                }
                data = data + "</tbody>";
                data = data + "</table>";
                i++;
            }
            data = data + "</tbody>";
            data = data + "</table>";
            return data;
        }

        public async Task<IEnumerable<string>> GetDashboardData()
        {
            return Provider.GetStoreSummaryReport();
        }

        public string CreateChildLink(string Name,bool bo=false)
        {
            string view= bo==false?"feather icon-chevrons-right": "feather icon-eye";
            if (bo != true)
            {
                return
                    "<td>" +
                    "<a class='" + view + "' data-toggle='collapse' href='#" + Name.Replace(" ", "") + "' role='button' aria-expanded='false' aria-controls='collapseExample'></a>" +
                    "</td>";
            }
            else
            {                
                return "<td>" +
                "<a class='" + view + "' id='#" + Name.Replace(" ", "") + "' role='button' aria-expanded='false' aria-controls='collapseExample'></a>" +
                "</td>";
            }
        }

        public string CreateAssetChildLink(AssertSpecReport asr)
        {
            return "<td>" +
                "<a class='feather icon-eye' id='assetspec' onclick='openstoredetails($SC"+ asr.STRUCTURE + "$SC,$SC" + asr.SUB_STRUCTURE + "$SC," +
                "$SC" + asr.ASSET_TYPE + "$SC,$SC" + asr.ASSET_SPEC + "$SC); return false;'></a>" +                
                "</td>";            
        }

        public string innertablehead(string Name,int i)
        {
            return
           "<tr class='collapse' id='" + Name.Replace(" ","") + "'>" +
           "<td colspan='11' style='padding:inherit;margin:0'> " +
           "<div class='card-body' style='padding:inherit;margin:0;padding-left:15px'> " +
           "<div class='dataTables_scrollBody' style='position:relative;overflow:auto;max-height:75vh;width:100%;'>" +
           "<table class='tabletable-stripedtable-borderedtable-hovernowrap' style='border:1.2px solid "+ Getcolor(i) + ";width:100%;'>";
        }

        public string innertprotablehead(string Name, int i)
        {
            return
           "<tr class='collapse' id='" + Name.Replace(" ", "") + "'>" +
           "<td colspan='12' style='padding:inherit;margin:0'> " +
           "<div class='card-body' style='padding:inherit;margin:0;padding-left:15px'> " +
           "<div class='dataTables_scrollBody' style='position:relative;overflow:auto;max-height:75vh;width:100%;'>" +
           "<table class='tabletable-stripedtable-borderedtable-hovernowrap' style='border:1.2px solid " + Getcolor(i) + ";width:100%;'>";
        }

        public string TableStart()=>$"<table class='table table-striped table-bordered nowrap'>";

        public string TableHeader(string Name,string Code=null)
        {
            if (Code != null)
            {
                return
                    "<thead>"+
                    "<tr>"+
                    "<th></th>"+
                    "<th>Sno</th>"+
                    "<th>"+ Code + "</th>"+
                    "<th>"+ Name + "</th>"+
                    "<th>Total</th>"+
                    "<th>Available</th>"+
                    "<th>UnderUse</th>"+
                    "<th>In-Ward</th>"+
                    "<th>Out-Ward</th>"+
                    "<th>Repair</th>"+
                    "<th>Scrape</th>"+
                    "<th>PurchaseQuantity</th>"+
                    "</tr>"+
                    "</thead>";
            }
            else
            {
                return
                    "<thead>" +
                    "<tr>" +
                    "<th></th>" +
                    "<th>Sno</th>" +
                    "<th>" + Name + "</th>" +                    
                    "<th>Total</th>" +
                    "<th>Available</th>" +
                    "<th>UnderUse</th>" +
                    "<th>In-Ward</th>" +
                    "<th>Out-Ward</th>" +
                    "<th>Repair</th>" +
                    "<th>Scrape</th>" +
                    "<th>PurchaseQuantity</th>" +
                    "</tr>" +
                    "</thead>";
            }
        }

        public string Getcolor(int i)
        {
            if(i==1)
            {
                return "#9A99FD";
            }
            else if (i == 2)
            {
                return "#FDFB99";
            }
            else if (i == 3)
            {
                return "#99FDA8";
            }
            else if (i == 4)
            {
                return "#9A99FD";
            }
            else
            {
                return "#CCCCCB";
            }

        }

    }
}
