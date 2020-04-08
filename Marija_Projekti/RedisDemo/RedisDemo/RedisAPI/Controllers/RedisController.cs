using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedisAPI.Services;

namespace RedisAPI.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class RedisController : ControllerBase
    {
        private readonly ICacheService _cacheService;
        public RedisController(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        [HttpGet("redis/{key}")]
        public async Task<IActionResult> GetCacheValue([FromRoute] string key)
        {
            var value = await _cacheService.GetCacheValueAsync(key);
            return string.IsNullOrEmpty(value) ? (IActionResult)NotFound() : Ok(value);
        }

        [HttpPost("redis")]
        public async Task<IActionResult> SetCacheValue([FromBody] MyModel request)
        {
            await _cacheService.SetCacheValueAsync(request.Key, request.Value);
            return Ok();
        }
    }

    public class MyModel
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}