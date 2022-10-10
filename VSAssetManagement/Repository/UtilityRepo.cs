using VSAssetManagement.Models;
using System.Collections.Generic;
using System.Linq;

namespace VSAssetManagement.Repo
{
    public class UtilityRepo
    {
        protected VISWASAMUDRAContext _context { get; set; }
        public UtilityRepo(VISWASAMUDRAContext context)
        {
            _context = context;
        }

        public List<Status> getStatusListForType(string type)
        {
            return _context.Status.Where(s => s.Type == type).ToList();
        }
    }
}