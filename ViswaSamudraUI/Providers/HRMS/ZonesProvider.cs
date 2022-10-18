using System.Collections.Generic;
using io = VSManagement.IOModels;

namespace ViswaSamudraUI.Providers.HRMS
{
	public class ZonesProvider
	{
        CommonHelper ch = new CommonHelper();
        public IEnumerable<io.Zones> GetAll()
        {
            return (IEnumerable<io.Zones>)ch.GetRequest<io.Zones>("Zones");
        }
    }
}
