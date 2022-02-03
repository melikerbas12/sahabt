using Microsoft.AspNetCore.Mvc;
using SahaBT.Service.Abstract;
using SahaBT.Shared.Concrete;
using ServiceStack.Redis;

namespace SahaBT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedisController : ControllerBase
    {
        private readonly IRedisService _redisService;
        public RedisController(IRedisService redisService)
        {
             _redisService = redisService;

            using (IRedisClient client = new RedisClient())
            {
                if (client.SearchKeys("Person*").Count == 0)
                {
                    var personvalue = new Personal();
                    personvalue.ID = 1;
                    personvalue.Name = "Melike";
                    personvalue.Surname = "Erbaş";
                    personvalue.Age = 40;

                    var cachedata = client.As<Personal>();
                    cachedata.SetValue("Person" + personvalue.ID, personvalue);

                }
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            const string cacheKey = "Person*";
            var redisdata = _redisService.GetAll(cacheKey);

            return Ok(redisdata);
        }

        [HttpGet("{Id}")]
        public IActionResult Detail(int Id)
        {
            string cacheKey = "Person" + Id;
            var redisdata = _redisService.GetById(Id,cacheKey);

            return Ok(redisdata);
        }
    }
}
