using Microsoft.AspNetCore.Mvc;

namespace WebService.Controllers
{
    public class DiagnosticController : AbstractController
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("It works");
        }
    }
}