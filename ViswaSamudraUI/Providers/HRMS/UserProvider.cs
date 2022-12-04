using Newtonsoft.Json;
using System.Collections.Generic;
using ViswaSamudraUI.Models;
using io = VSManagement.IOModels;

namespace ViswaSamudraUI.Providers.HRMS
{
	public class UserProvider
	{
        CommonHelper ch = new CommonHelper();
        public io.ResponseBody Login(io.UserLogin model)
        {
            ResponseBody res = ch.PostRequest<io.UserLogin>("User/Login", model);
            io.ResponseBody responseBody = JsonConvert.
                DeserializeObject<io.ResponseBody>(res.Message);
            return responseBody;
        }
    }
}
