using Microsoft.AspNetCore.Mvc;

namespace API_StarWars.Controllers
{
    [ApiController]
    [Route("jedi")]
    public class JediController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public ActionResult<string> HelloWorld()
        {
            return Ok("Hello World!");
        }
    }
}