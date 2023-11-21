using Microsoft.IdentityModel.Tokens;
using PandaApplication.Services.Interfaces;
using PandaDomain.Entities;
using PandaDomain.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace PandaApplication.Services
{
    public class AuthService : IAuthService
    {
        public async Task<User> Register(UserDto request)
        {
            User user = new User();
            user.UserName = request.UserName;
            user.PasswordHash = BC.HashPassword(request.Password);
            user.PasswordSalt = BC.GenerateSalt();
            return user; 
        }

        public async Task<string> Login(UserDto request)
        {
            User user = new User();
            user.UserName = request.UserName;
            user.PasswordHash = BC.HashPassword(request.Password);
            user.PasswordSalt = BC.GenerateSalt();
            if (user.UserName != request.UserName)
            {
                return "User not found";
            }
            return BC.Verify(request.Password, user.PasswordHash) ? "token" : "Password wrong";
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName)
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(user.UserName));
            return "";
        }
    }
}
