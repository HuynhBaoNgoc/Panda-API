using Microsoft.AspNetCore.Mvc;
using PandaApplication.Services.Interfaces;
using PandaDomain.Entities;
using PandaDomain.Models.Request;
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
        public async Task<ActionResult<List<CityResponse>>> GetListCity()
        {
            var result = await _citySerVice.GetListCity();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<City>>> GetCityById(int id)
        {
            var result = await _citySerVice.GetCityById(id);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<List<CityResponse>>> AddCity(AddCityRequest cityRequest)
        {
            var result = await _citySerVice.AddCity(cityRequest);
            return result != null ? Ok(result) : BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult<CityResponse>> UpdateCity(UpdateCityRequest cityRequest)
        {
            var result = await _citySerVice.UpdateCity(cityRequest); //empty
            return result != null ? Ok(result) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<CityResponse>>> Delete(int id)
        {
            var result = await _citySerVice.Delete(id);
            return result != null ? Ok(result) : NotFound();
        }
    }
}
