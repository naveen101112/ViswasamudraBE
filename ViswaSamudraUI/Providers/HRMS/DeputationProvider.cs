using System.Collections.Generic;
using io = VSManagement.IOModels;

namespace ViswaSamudraUI.Providers.HRMS
{
	public class DeputationProvider
	{
        CommonHelper ch = new CommonHelper();
        public IEnumerable<io.Deputation> GetAll()
        {
            return (IEnumerable<io.Deputation>)ch.GetRequest<io.Deputation>("Deputation");
        }
    }
}
