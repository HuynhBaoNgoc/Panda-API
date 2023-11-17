using PandaApplication.Services.Interfaces;
using PandaDomain.Entities;
using PandaDomain.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaApplication.Services
{
    public class AuthService : IAuthService
    {
        public Task<User> Register(UserDto request)
        {
            throw new NotImplementedException();
        }
    }
}
