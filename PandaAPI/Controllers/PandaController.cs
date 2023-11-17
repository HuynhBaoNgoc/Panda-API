using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using PandaApplication.Services;
using PandaApplication.Services.Interfaces;
using PandaDomain.Models.Response;
using Serilog;

namespace PandaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PandaController : ControllerBase
    {
        private readonly IPandaService _pandaService;
        private readonly IMemoryCache _memoryCache;

        public PandaController(IPandaService pandaService, IMemoryCache memoryCache)
        {
            _pandaService = pandaService;
            _memoryCache = memoryCache;
        }

        [HttpGet]
        [ResponseCache(Duration = 60)]
        public async Task<ActionResult<List<PandaResponse>>> GetListPanda()
        {
            var cacheKey = "ListPanda";
            if (!_memoryCache.TryGetValue(cacheKey, out List<PandaResponse> result))
            {
                result = await _pandaService.GetListPanda();

                // Cache the result
                _memoryCache.Set(cacheKey, result, new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(60) // Cache for 60 seconds
                });
            }
            //var result = await _pandaService.GetListPanda();
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ResponseCache(Duration = 60)]
        public async Task<ActionResult<List<FoodResponse>>> GetListFavoriteFood(int id)
        {
            var cacheKey = "ListFavoriteFood";
            if (!_memoryCache.TryGetValue(cacheKey, out List<FoodResponse> result))
            {
                result = await _pandaService.GetListFavoriteFood(id);

                // Cache the result
                _memoryCache.Set(cacheKey, result, new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(60) // Cache for 60 seconds
                });
            }
            return Ok(result);
        }
    }
}
