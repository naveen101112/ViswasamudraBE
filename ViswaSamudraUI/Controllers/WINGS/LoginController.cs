using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VSManagement.IOModels;

namespace ViswaSamudraUI.Controllers.WINGS
{
    public class LoginController : Controller
    {
        private IConfiguration _config;
        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult authenticate([FromForm] UserLogin model)
        {
            var user = Authenticate(model);
            if(user == null) return Redirect("unuthorized");
            string token = Generate(model);
            return Ok(new LoginResponse { Status = true, Token = token });
        }

        public IActionResult login_bkp([FromForm]UserLogin model)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes("loggedin");
            string authKey = string.Empty;

            if(model.UserName == "admin@mail.com" && model.Password == "Password123")
            {
                authKey = System.Convert.ToBase64String(plainTextBytes);
            }
            else
            {
                return Redirect("unuthorized");
            }
            return Redirect("../Dashboard/Index?authKey=" + authKey);
        }

        private string Generate(UserLogin user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim(ClaimTypes.Email, user.UserName),
                //new Claim(ClaimTypes.GivenName, user.FirstName+" "+user.LastName),
                //new Claim(ClaimTypes.Role, roleRepo.GetRole(user.RoleId))
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              claims,
              expires: DateTime.Now.AddMinutes(Int16.Parse(_config["Jwt:Expiry"])),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private UserLogin Authenticate(UserLogin model)
        {
            if (model.UserName == "admin@mail.com" && model.Password == "Password123")
            {
                return model;
            }
            return null;
        }
    }
}
