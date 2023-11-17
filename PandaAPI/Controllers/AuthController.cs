using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PandaApplication.Services;
using PandaApplication.Services.Interfaces;
using PandaDomain.Entities;
using PandaDomain.Models.Request;

namespace PandaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static User user = new User();
        private readonly IAuthService _authService;

        public AuthController(IAuthService _authService)
        {
            _authService = _authService;
        }
        
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            var result = await _authService.Register(request);
            return result != null ? Ok(result) : BadRequest();
        }
    }
}
