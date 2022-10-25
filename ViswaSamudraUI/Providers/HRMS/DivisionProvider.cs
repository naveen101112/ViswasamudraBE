using System.Collections.Generic;
using io = VSManagement.IOModels;

namespace ViswaSamudraUI.Providers.HRMS
{
	public class DivisionProvider
	{
        CommonHelper ch = new CommonHelper();
        public IEnumerable<io.Division> GetAll()
        {
            return (IEnumerable<io.Division>)ch.GetRequest<io.Division>("Division");
        }
    }
}
