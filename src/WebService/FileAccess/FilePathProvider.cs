using FileAccess;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.FileAccess
{
    public class FilePathProvider : IPathProvider
    {
        private readonly IWebHostEnvironment env;

        public FilePathProvider(IWebHostEnvironment env)
        {
            this.env = env;
        }

        public string GetFilePath(string filename)
        {
            string path = $"{filename}.pdf";
            return env.WebRootFileProvider.GetFileInfo(path)?.PhysicalPath;
        }
    }
}
