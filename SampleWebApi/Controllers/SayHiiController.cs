using Microsoft.AspNetCore.Mvc;

namespace SampleWebApi.Controllers
{
    [Route("api/[controller]")]
    public class SayHiiController : Controller
    {
        // GET api/values
        [HttpGet]
        public string Get()
        {
            return "Hii";
        }

        // GET api/values/5
        [HttpGet("{name}")]
        public string Get(string name)
        {
            return "Hii, " + name;
        }
    }
}
