using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace SampleWebApi.Controllers
{
    [Route("api/[controller]")]
    public class SayHelloController : Controller
    {
        // GET api/values
        [HttpGet]
        public string Get()
        {
            return "Hello";
        }

        // GET api/values/5
        [HttpGet("{name}")]
        public string Get(string name)
        {
            return "Hello, "+name;
        }
    }
}
