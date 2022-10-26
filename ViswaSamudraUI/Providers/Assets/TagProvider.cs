using System.Collections.Generic;
using io = VSAssetManagement.IOModels;

namespace ViswaSamudraUI.Providers.Assets
{
	public class TagProvider
	{
        CommonHelper ch = new CommonHelper();
        public IEnumerable<io.Tag> GetAll()
        {
            return (IEnumerable<io.Tag>)ch.GetRequest<io.Tag>("Tag");
        }
    }
}
