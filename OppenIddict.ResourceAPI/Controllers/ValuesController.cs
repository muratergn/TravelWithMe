using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OppenIddict.ResourceAPI.Controllers
{
    public class ValuesController : Controller
    {
        [HttpGet("[action]")]
        [Authorize("APolicy")]
        public IActionResult A()
        {
            return Ok();
        }

        [HttpGet("[action]")]
        [Authorize("BPolicy")]
        public IActionResult B()
        {
            return Ok();
        }

        [HttpGet("[action]")]
        [Authorize("CPolicy")]
        public IActionResult C()
        {
            return Ok();
        }

        [HttpGet("[action]")]
        [Authorize("DPolicy")]
        public IActionResult D()
        {
            return Ok();
        }
    }
}
