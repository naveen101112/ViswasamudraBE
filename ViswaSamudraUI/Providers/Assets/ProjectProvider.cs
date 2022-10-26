using System.Collections.Generic;
using io = VSAssetManagement.IOModels;

namespace ViswaSamudraUI.Providers.Assets
{
	public class ProjectProvider
    {
        CommonHelper ch = new CommonHelper();
        public IEnumerable<io.Project> GetAll()
        {
            return (IEnumerable<io.Project>)ch.GetRequest<io.Project>("Project");
        }
    }
}
