﻿using VSManagement.Models.VS_EMPLOYEE;
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
            int empCount = _context.EmployeeMaster.Where(e => e.EmployeeCode.ToUpper() == request.UserName.ToUpper()).Count();
            if(count == 0 || empCount == 0)
            {
                return new io.ResponseBody { Status = false, Message = "Invalid UserName/Password" };
            }

            if(_context.EmployeeMaster.Where(e => e.EmployeeCode.ToUpper() == request.UserName.ToUpper()).FirstOrDefault().IsActive != "Y")
            {
                return new io.ResponseBody { Status = false, Message = "User Inative." };
            }

            var base64EncodedBytes = System.Convert.FromBase64String(request.Password);
            request.Password = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
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
    }
}