using VSManagement.Models.VISWASAMUDRA;
using ViswasamudraCommonObjects.Util;
using System.Collections.Generic;
using System.Linq;

namespace VSManagement.Repository.AssetManagement
{
    public class UtilityRepo
    {
        protected VISWASAMUDRAContext _context { get; set; }
        public UtilityRepo(VISWASAMUDRAContext context)
        {
            _context = context;
        }
    }
}