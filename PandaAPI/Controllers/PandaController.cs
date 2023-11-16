using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PandaApplication.Services.Interfaces;
using PandaDomain.Models.Response;
using Serilog;

namespace PandaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PandaController : ControllerBase
    {
        private readonly IPandaService _pandaSerVice;

        public PandaController(IPandaService pandaSerVice)
        {
            _pandaSerVice = pandaSerVice;
        }

        [HttpGet]
        public async Task<ActionResult<List<CityResponse>>> GetListPanda()
        {
            var result = await _pandaSerVice.GetListPanda();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<FoodResponse>>> GetListFavoriteFood(int id)
        {
            var result = await _pandaSerVice.GetListFavoriteFood(id);
            return Ok(result);
        }
    }
}
