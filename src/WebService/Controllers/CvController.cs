using FileAccess;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.Controllers
{
    public class CvController : AbstractController
    {
        private readonly IFileRepository fileRepository;
        private readonly IWebHostEnvironment env;

        public CvController(IFileRepository fileRepository, IWebHostEnvironment env)
        {
            this.fileRepository = fileRepository;
            this.env = env;
        }

        public override IActionResult Get()
        {
            var path = this.env.WebRootPath;
            return Ok(path);
        }
    }
}
