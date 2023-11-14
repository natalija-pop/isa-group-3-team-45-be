using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    public class ErrorsController : ControllerBase
    {
        [HttpGet]
        [Route("/error")]
        public IActionResult HandleErrors() => Problem();
    }
}
