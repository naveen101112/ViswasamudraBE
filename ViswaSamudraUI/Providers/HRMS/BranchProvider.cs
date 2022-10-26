using System.Collections.Generic;
using io = VSManagement.IOModels;

namespace ViswaSamudraUI.Providers.HRMS
{
	public class BranchProvider
	{
        CommonHelper ch = new CommonHelper();
        public IEnumerable<io.Branch> GetAll()
        {
            return (IEnumerable<io.Branch>)ch.GetRequest<io.Branch>("Branch");
        }
    }
}
