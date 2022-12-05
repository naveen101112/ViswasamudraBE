using System;
using System.Collections.Generic;
using ViswaSamudraUI.Models;
using io = VSAssetManagement.IOModels;

namespace ViswaSamudraUI.Providers.Assets
{
    public class AssetRequistionProvider
    {
        CommonHelper ch = new CommonHelper();
        public IEnumerable<io.AssetRequisition> GetAll(io.AssetRequisition assetreqmodel)
        {
            return (IEnumerable<io.AssetRequisition>)ch.GetDetailsRequest<io.AssetRequisition>("assetRequisition/search", assetreqmodel);
        }
        public ResponseBody Add(io.AssetRequisition model = null)
        {
            if (model.header.Guid == System.Guid.Empty)
            {
                return ch.PostRequest<io.AssetRequisition>("assetRequisition/createAssetRequisition", model);
            }
            else
                return ch.PostRequest<io.AssetRequisition>("assetRequisition/updateAssetRequisition", model);
        }

        public ResponseBody Delete(io.AssetRequisition model)
        {
            return ch.PostRequest<io.AssetRequisition>("assetRequisition/DeleteAssetRequisition", model);
        }
    }
}
