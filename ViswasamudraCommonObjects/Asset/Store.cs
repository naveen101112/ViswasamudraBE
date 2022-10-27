using System;
using System.Collections.Generic;

namespace VSAssetManagement.IOModels
{
    public class Store
    {
        public string Name { get; set; }
        public int ParentStore { get; set; }
        public int RecordStatus { get; set; }
        public Guid Guid { get; set; }
        public string Code { get; set; }
        public string Project { get; set; }
        public string Incharge { get; set; }
        public string InchargeMobile { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDateTime { get; set; }
        public int Id { get; set; }
        public IEnumerable<string> Regions { get; set; }
    }
}
