using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using ViswaSamudraUI.Models;
using VSAssetManagement.IOModels;
using io = VSAssetManagement.IOModels;

namespace ViswaSamudraUI.Providers.Assets
{
	public class ReportDetails
    {
        CommonHelper ch = new CommonHelper();        
        public IEnumerable<DetailedReport> GetSummaryReport()
        {
            return (IEnumerable<DetailedReport>)ch.GetRequest<DetailedReport>("reports/summaryreport");
        }

        public IEnumerable<StoreReport> GetStoreSummaryReport(StoreReport PoIoModel)
        {
            return (IEnumerable<StoreReport>)ch.GetDetailsRequest<StoreReport>("reports/storesummaryreport", PoIoModel);
        }

        public IEnumerable<string> GetStoreSummaryReport()
        {
            return (IEnumerable<string>)ch.GetRequest<string>("reports/Dashboardreport");
        }

        


    }
}
