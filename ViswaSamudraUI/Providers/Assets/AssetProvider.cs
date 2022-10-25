using System.Collections.Generic;
using io = VSAssetManagement.IOModels;

namespace ViswaSamudraUI.Providers.Assets
{
	public class AssetProvider
	{
        CommonHelper ch = new CommonHelper();
        public IEnumerable<io.Asset> GetAll()
        {
            return (IEnumerable<io.Asset>)ch.GetRequest<io.Asset>("Asset");
        }
    }
}
