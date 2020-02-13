﻿using FileAccess;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;
using WebService.PhysicalFilesAccess;
using WebService.PhysicalFilesAccess.Cv;

namespace WebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CvController : ControllerBase
    {
        private readonly ICvFileInfoProvider cvPathProvider;

        public CvController(ICvFileInfoProvider cvPathProvider)
        {
            this.cvPathProvider = cvPathProvider ?? throw new System.ArgumentNullException(nameof(cvPathProvider));
        }

        public async Task<IActionResult> Get()
        {
            IFile cvFileInfo = this.cvPathProvider.GetPhysicalPath();

            var memory = new MemoryStream();
            using (var stream = new FileStream(cvFileInfo.PhysicalPath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }

            memory.Position = 0;
            return File(memory, "application/pdf", cvFileInfo.Name);
        }
    }
}
