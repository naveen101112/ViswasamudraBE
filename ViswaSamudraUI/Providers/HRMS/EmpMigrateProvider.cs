using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using ViswaSamudraUI.Models;
using io = VSManagement.IOModels;

namespace ViswaSamudraUI.Providers.Assets
{
	public class EmpMigrateProvider
	{
        CommonHelper ch = new CommonHelper();
        public IEnumerable<io.TblMigrationEmployee> GetAll()
        {
            return (IEnumerable<io.TblMigrationEmployee>)ch.GetRequest<io.TblMigrationEmployee>("migrate-emp");
        }
    }
}
