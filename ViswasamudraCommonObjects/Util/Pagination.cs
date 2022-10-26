using System.ComponentModel.DataAnnotations.Schema;

namespace ViswasamudraCommonObjects.Util
{
    public class Pagination
    {
        [NotMapped]
        public int pageNo { get; set; }
        [NotMapped]
        public int pageSize { get; set; }
        [NotMapped]
        public string searchParam { get; set; }

        public int skip()
        {
            return (pageNo - 1) * pageSize;
        }

        public int take()
        {
            return pageSize == 0 ? 10000000 : pageSize;
        }
    }
}
