using FileAccess;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.PhysicalFilesAccess.Cv
{
    public class CvFileInfoProvider : ICvFileInfoProvider
    {
        private const string CvName = "CV";
        private readonly IFilesInfoProvider filesInfoProvider;

        public CvFileInfoProvider(IFilesInfoProvider filesInfoProvider)
        {
            this.filesInfoProvider = filesInfoProvider ?? throw new ArgumentNullException(nameof(filesInfoProvider));
        }
        
        public IFile GetFile()
        {
            var cvFile = this.filesInfoProvider.GetFiles()
                .MatchCvName(CvName)
                .OrderByDescending(n => n.LastModification)
                .FirstOrDefault();

            if(!(cvFile is IFile))
            {
                throw new CvNotFoundException();
            }

            return cvFile;
        }
    }
}
