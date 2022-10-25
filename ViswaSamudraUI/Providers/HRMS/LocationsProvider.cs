using System.Collections.Generic;
using io = VSManagement.IOModels;

namespace ViswaSamudraUI.Providers.HRMS
{
	public class LocationsProvider
	{
        CommonHelper ch = new CommonHelper();
        public IEnumerable<io.Locations> GetAll()
        {
            return (IEnumerable<io.Locations>)ch.GetRequest<io.Locations>("Locations");
        }
    }
}
