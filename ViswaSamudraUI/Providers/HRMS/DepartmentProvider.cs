using System.Collections.Generic;
using io = VSManagement.IOModels;

namespace ViswaSamudraUI.Providers.HRMS
{
	public class DepartmentProvider
	{
        CommonHelper ch = new CommonHelper();
        public IEnumerable<io.Department> GetAll()
        {
            return (IEnumerable<io.Department>)ch.GetRequest<io.Department>("Department");
        }
    }
}
