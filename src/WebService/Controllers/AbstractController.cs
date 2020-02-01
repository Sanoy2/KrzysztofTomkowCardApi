using Microsoft.AspNetCore.Mvc;
using System;

namespace WebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public abstract class AbstractController : ControllerBase
    {
        public virtual IActionResult Get()
        {
            Type thisType = GetType();

            return Ok($"{thisType.Name}");
        }
    }
}
