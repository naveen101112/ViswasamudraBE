using System;
using System.Collections.Generic;
using System.Text;

namespace VSAssetManagement.IOModels
{
    public class Reason
    {
        public string ReasonCode { get; set; }
        public string ReasonName { get; set; }
        public string ReasonType { get; set; }
        public string NAME { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDateTime { get; set; }
        public int RecordStatus { get; set; }
        public Guid Guid { get; set; }
        public int Id { get; set; }
    }
}
