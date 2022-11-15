using System;

namespace VSManagement.IOModels
{
    public class UserLogin
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string OldPassword { get; set; }
        public int? WrongAttempt { get; set; }
        public int? PasswordReset { get; set; }
        public int? LoggedIn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDateTime { get; set; }
        public Guid? Guid { get; set; }
    }
}
