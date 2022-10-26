using System.Collections.Generic;
using io = VSManagement.IOModels;

namespace ViswaSamudraUI.Providers.HRMS
{
	public class SalutationProvider
	{
        CommonHelper ch = new CommonHelper();
        public IEnumerable<io.Salutation> GetAll()
        {
            return (IEnumerable<io.Salutation>)ch.GetRequest<io.Salutation>("Salutation");
        }
    }
}
