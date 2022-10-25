using System;

namespace VSManagement.IOModels
{
    public class Locations
    {
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public Guid? BranchUid { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string BranchCode { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string IsActive { get; set; }
    }
}
