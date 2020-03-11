using FileAccess;
using Microsoft.Extensions.FileProviders;
using System;
using System.IO;
using System.Linq;

namespace FileAccess.PhysicalFilesAccess
{
    public class FilesInfoProvider : IFilesInfoProvider
    {
        private readonly IFileProvider fileProvider;

        public FilesInfoProvider(IFileProvider fileProvider)
        {
            this.fileProvider = fileProvider ?? throw new ArgumentNullException(nameof(fileProvider));
        }

        public IQueryable<IFile> GetFiles()
        {
            return this.fileProvider.GetDirectoryContents(string.Empty)
                .Where(n => n.IsDirectory == false)
                .Select(n => new File(
                    n.Name,
                    n.LastModified.DateTime,
                    n.PhysicalPath))
                .AsQueryable();
        }
    }
}
