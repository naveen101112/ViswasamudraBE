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

        public List<Status> getStatusListForType(Pagination page)
        {
            return _context.Status.Where(s => s.Type.ToUpper() == page.searchParam.ToUpper()).ToList();
        }
    }
}