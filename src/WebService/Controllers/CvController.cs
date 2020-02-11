using FileAccess;
using Microsoft.AspNetCore.Mvc;
using WebService.PhysicalFilesAccess;
using WebService.PhysicalFilesAccess.Cv;

namespace WebService.Controllers
{
    public class CvController : AbstractController
    {
        private readonly ICvPathProvider cvPathProvider;

        public CvController(ICvPathProvider cvPathProvider)
        {
            this.cvPathProvider = cvPathProvider ?? throw new System.ArgumentNullException(nameof(cvPathProvider));
        }

        public override IActionResult Get()
        {
            string path = this.cvPathProvider.GetPhysicalPath();
            return Ok($"path: {path}");
        }
    }
}
