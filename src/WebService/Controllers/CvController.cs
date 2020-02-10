using FileAccess;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebService.Configuration;

namespace WebService.Controllers
{
    public class CvController : AbstractController
    {
        private readonly IFileRepository fileRepository;
        private readonly IWebHostEnvironment env;
        private readonly IPathProvider pathProvider;
        private readonly GeneralSettings settings;

        public CvController(IFileRepository fileRepository, IWebHostEnvironment env, IPathProvider pathProvider, GeneralSettings settings)
        {
            this.fileRepository = fileRepository;
            this.env = env;
            this.pathProvider = pathProvider;
            this.settings = settings;
        }

        public override IActionResult Get()
        {
            var provider = new PhysicalFileProvider("D:\\tmp\\dotnet1");
            var contents = provider.GetDirectoryContents(string.Empty);
            string message = "";
            foreach (var item in contents)
            {
                message += item.PhysicalPath;
            }

            string path = contents.First().PhysicalPath;
            string name = contents.First().Name;
            return Ok($"path: {path} ; name: {name}");
        }
    }
}
