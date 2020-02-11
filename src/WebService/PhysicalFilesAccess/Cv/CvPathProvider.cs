using FileAccess;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.PhysicalFilesAccess.Cv
{
    public class CvPathProvider : ICvPathProvider
    {
        private const string CvName = "CV";
        private readonly IFilesInfoProvider filesInfoProvider;

        public CvPathProvider(IFilesInfoProvider filesInfoProvider)
        {
            this.filesInfoProvider = filesInfoProvider ?? throw new ArgumentNullException(nameof(filesInfoProvider));
        }
        
        public string GetPhysicalPath()
        {
            return this.filesInfoProvider.GetFiles()
                .MatchCvName(CvName)
                .OrderByDescending(n => n.LastModification)
                .First()
                .PhysicalPath;
        }
    }
}
