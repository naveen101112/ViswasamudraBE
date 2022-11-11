
using System.Collections.Generic;

namespace VSAssetManagement.IOModels
{
    public class AssetRequisition
    {
        public AssetRequisitionHeader header { get; set; }
        public List<AssetRequisitionDetails> details { get; set; }
    }
}
