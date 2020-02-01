using FileAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.Controllers
{
    public class CvController : AbstractController
    {
        private readonly IFileRepository fileRepository;

        public CvController(IFileRepository fileRepository)
        {
            this.fileRepository = fileRepository;
        }
    }
}
