using VSManagement.Models.VS_EMPLOYEE;
using System.Collections.Generic;
using System.Linq;
using System;
using io = VSManagement.IOModels;

namespace VSManagement.Repository.HRMS
{
    public class UserLoginRepo
    {
        protected VS_EMPLOYEEContext _context { get; set; }
        public UserLoginRepo(VS_EMPLOYEEContext context)
        {
            _context = context;
        }

        public io.ResponseBody login(io.UserLogin request)
        {
            int count = _context.UserLogin.Where(u => u.UserName.ToUpper() == request.UserName.ToUpper()).Count();
            if(count == 0)
            {
                return new io.ResponseBody { Status = false, Message = "Invalid UserName/Password" };
            }

            UserLogin userLogin = _context.UserLogin.Where(u=>u.UserName.ToUpper() == request.UserName.ToUpper()).FirstOrDefault();
            if (userLogin.WrongAttempt >= 3)
            {
                return new io.ResponseBody { Status = false, Message = "Maximum Invalid password count exceeded" };
            }
            else if (userLogin.Password != request.Password)
            {
                userLogin.WrongAttempt++;
                _context.UserLogin.Update(userLogin).Property(x => x.Id).IsModified = false;
                _context.SaveChanges();
                return new io.ResponseBody { Status = false, Message = "Invalid UserName/Password" };
            }else if(userLogin.PasswordReset == 1)
            {
                return new io.ResponseBody { Status = false, Message = "Please reset Password." };
            }
            return new io.ResponseBody { Status = true, Message = "Success", UserName = request.UserName };
        }

        public List<string> getUserNames()
        {
            return (from user in _context.UserLogin
                    join emp in _context.EmployeeMaster on user.UserName equals emp.EmployeeCode
                    where emp.IsActive == "Y"
                    select user.UserName
                    ).ToList();
        }
    }
}