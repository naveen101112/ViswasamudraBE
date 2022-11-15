using System.Collections.Generic;
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
    }
}
