using PandaApplication.Services.Interfaces;
using PandaDomain.Entities;
using PandaDomain.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace PandaApplication.Services
{
    public class AuthService : IAuthService
    {
        public static User user = new User();
        public async Task<User> Register(UserDto request)
        {
            user.UserName = request.UserName;
            user.PasswordHash = await HashPasswordAsync("password");
            user.PasswordSalt = Encoding.UTF8.GetBytes(BC.GenerateSalt());
            return user; 
        }

        private Task<byte[]> HashPasswordAsync(string password)
        {
            return Task.Run(() =>
            {
                // Hash the password and convert it to a byte array
                string hashedPassword = BC.HashPassword(password);
                return Encoding.UTF8.GetBytes(hashedPassword);
            });
        }    
    }
}
