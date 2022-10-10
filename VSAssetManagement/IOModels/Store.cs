using System;

namespace VSAssetManagement.IOModels
{
    public partial class Store
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int MainStoreId { get; set; }
        public int RecordStatus { get; set; }
        public Guid Guid { get; set; }
    }
}
