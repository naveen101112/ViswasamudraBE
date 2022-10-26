using System.Collections.Generic;
using io = VSManagement.IOModels;

namespace ViswaSamudraUI.Providers.HRMS
{
	public class CompanyProvider
	{
        CommonHelper ch = new CommonHelper();
        public IEnumerable<io.Company> GetAll()
        {
            return (IEnumerable<io.Company>)ch.GetRequest<io.Company>("Company");
        }
    }
}
