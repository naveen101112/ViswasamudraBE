using System;

namespace VSManagement.IOModels
{
    public partial class EmployeeMaster
    {
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public string EmployeeCode { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string FatherHusbandName { get; set; }
        public DateTime? DateofBirth { get; set; }
        public string PlaceofBirth { get; set; }
        public string Nationality { get; set; }
        public string Religion { get; set; }
        public string Caste { get; set; }
        public string Language { get; set; }
        public string BloodGroup { get; set; }
        public string AdharNo { get; set; }
        public string AdharName { get; set; }
        public DateTime? DateOfJoining { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string IsActive { get; set; }
    }
}
