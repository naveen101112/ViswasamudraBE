using System;
using System.Collections.Generic;
using System.Text;

namespace VSAssetManagement.IOModels
{
    public class StoreReport
    {  
        public string STRUCTURE { get; set; }
        public string SUB_STRUCTURE { get; set; }
        public string ASSET_TYPE { get; set; }
        public string ASSET_SPEC { get; set; }
        public string STORE_CODE { get; set; }
        public string STORE_NAME { get; set; }
        public string TOTAL { get; set; }
        public string AVAILABLE { get; set; }
        public string UNDER_USE { get; set; }
        public string TRFR_INWARD { get; set; }
        public string TRFR_OUTWARD { get; set; }
        public string UNDER_REPAIR { get; set; }
        public string UNDER_SCRAP { get; set; }
        public string PURCHASED_QTY { get; set; }
       
        public List<ProjectReport> projectReports { get; set; }
    }
}
