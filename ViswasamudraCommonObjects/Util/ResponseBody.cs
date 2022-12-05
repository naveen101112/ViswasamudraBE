using System;
using System.Collections.Generic;
using System.Text;

namespace VSManagement.IOModels
{
    public class ResponseBody
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public string UserName { get; set; }
    }
}
