using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PandaApplication.Services.Interfaces;
using PandaDomain.Entities;
using PandaDomain.Models.Response;

namespace PandaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _citySerVice;

        public CityController(ICityService citySerVice) { 
            _citySerVice = citySerVice;
        }

        [HttpGet]
        public async Task<ActionResult> GetListCity()
        {
            var result = await _citySerVice.GetListCity();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<City>>> GetCityById(int id)
        {
            var result = await _citySerVice.GetCityById(id);
            return Ok(result);
        }
    }
}
