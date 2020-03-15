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
        private readonly IFileRepository fileRepository;

        public CvController(
            ICvFileInfoProvider cvPathProvider,
            IFileRepository fileRepository)
        {
            this.cvPathProvider = cvPathProvider ??
                throw new System.ArgumentNullException(nameof(cvPathProvider));

            this.fileRepository = fileRepository ??
                throw new System.ArgumentNullException(nameof(fileRepository));
        }

        [Route("pdf")]
        [HttpGet]
        public async Task<IActionResult> GetPdf()
        {
            try
            {
                IFile cvFileInfo = this.cvPathProvider.GetPdf();

                var memory = await this.fileRepository.GetFileAsMemoryStreamAsync(cvFileInfo.PhysicalPath);

                return File(memory, "application/pdf", cvFileInfo.Name);
            }
            catch (CvNotFoundException)
            {
                return NotFound("No CV pdf file found");
            }
        }

        [Route("image")]
        [HttpGet]
        public async Task<IActionResult> GetImage()
        {
            try
            {
                IFile cvFileInfo = this.cvPathProvider.GetImage();

                var memory = await this.fileRepository.GetFileAsMemoryStreamAsync(cvFileInfo.PhysicalPath);

                return File(memory, "image/jpeg", cvFileInfo.Name);
            }
            catch (CvNotFoundException)
            {
                return NotFound("No CV image file found");
            }
        }
    }
}