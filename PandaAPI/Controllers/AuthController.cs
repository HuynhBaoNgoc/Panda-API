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

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            var result = await _authService.Register(request);
            return result != null ? Ok(result) : BadRequest();
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDto request)
        {

            //if (request.UserName != request.UserName)
            //{
            //    return NotFound();
            //}
            var result = await _authService.Login(request);
            return result != null ? Ok(result) : BadRequest();
        }
    }
}
