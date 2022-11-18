using System;
using System.Collections.Generic;
using ViswaSamudraUI.Models;
using io = VSAssetManagement.IOModels;

namespace ViswaSamudraUI.Providers.Assets
{
	public class AssetProvider
	{
        CommonHelper ch = new CommonHelper();
        public IEnumerable<io.Asset> GetAll(io.Asset assetmodel)
        {
            return (IEnumerable<io.Asset>)ch.GetDetailsRequest<io.Asset>("asset/search", assetmodel);
        }
        public ResponseBody Add(io.Asset model = null)
        {
            if (model != null)
            {   
                return ch.PostRequest<io.Asset>("asset/assetUpdate", model);
            }
            else
                return null;
        }
    }
}
