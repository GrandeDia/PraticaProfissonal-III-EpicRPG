using Microsoft.AspNetCore.Mvc;

namespace EpicRPG_API.Controllers
{
    [Route("api/[controller]")]
    public class HeroiController : Controller
    {
        public HeroiController(params)
        {

        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
        
        [HttpGet("{AlunoRA}")]
        public IActionResult Get(int idHeroi)
        {
            return Ok();
        }
        [HttpPost]
        public IActionResult post()
        {
            return Ok();
        }

        [HttpPut("{AlunoRA}")]
        public IActionResult put(int idHeroi)
        {
            return Ok();
        }
        [HttpDelete("{AlunoRA}")]
        public IActionResult delete(int idHeroi)
        {
        return Ok();
        }
    }
}