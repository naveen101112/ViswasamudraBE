using System.ComponentModel.DataAnnotations.Schema;

namespace VSAssetManagement.IOModels
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
            return (this.pageNo - 1) * this.pageSize;
        }

        public int take()
        {
            return this.pageSize == 0 ? 10000000 : this.pageSize;
        }
    }
}
