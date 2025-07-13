using Microsoft.AspNetCore.Mvc;

namespace WebApiHandsOn.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok(new[] { "Utsav Saxena", "6361856" });
    }
}

