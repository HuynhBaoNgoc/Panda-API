using Microsoft.AspNetCore.Mvc;
using PandaDomain.Entities;
using PandaDomain.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaApplication.Services.Interfaces
{
    public interface IAuthService
    {
        Task<User> Register(UserDto request);
    }
}
