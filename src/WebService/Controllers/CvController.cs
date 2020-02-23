using System.IO;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using FileAccess;

using WebService.PhysicalFilesAccess;
using WebService.PhysicalFilesAccess.Cv;

namespace WebService.Controllers
{
    public class CvController : AbstractController
    {
        private readonly ICvFileInfoProvider cvPathProvider;

        public CvController(ICvFileInfoProvider cvPathProvider)
        {
            this.cvPathProvider = cvPathProvider ??
                throw new System.ArgumentNullException(nameof(cvPathProvider));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                IFile cvFileInfo = this.cvPathProvider.GetFile();

                var memory = new MemoryStream();
                using(var stream = new FileStream(cvFileInfo.PhysicalPath, FileMode.Open))
                {
                    await stream.CopyToAsync(memory);
                }

                memory.Position = 0;
                return File(memory, "application/pdf", cvFileInfo.Name);
            }
            catch (CvNotFoundException)
            {
                return NotFound("No CV file found");
            }
        }
    }
}