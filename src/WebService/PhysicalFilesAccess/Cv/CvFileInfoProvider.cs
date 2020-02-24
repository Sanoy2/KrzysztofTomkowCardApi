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

        public IFile GetPdf()
        {
            var cvFile = this.filesInfoProvider.GetFiles()
                .Where(n => n.Extension == ".pdf")
                .MatchCvName(CvName)
                .OrderByDescending(n => n.LastModification)
                .FirstOrDefault();

            if (!(cvFile is IFile))
            {
                throw new CvNotFoundException();
            }

            return cvFile;
        }

        public IFile GetImage()
        {
            var cvFile = this.filesInfoProvider.GetFiles()
                .Where(n => n.Extension == ".jpg" || n.Extension == ".jpeg")
                .MatchCvName(CvName)
                .OrderByDescending(n => n.LastModification)
                .FirstOrDefault();

            if (!(cvFile is IFile))
            {
                throw new CvNotFoundException();
            }

            return cvFile;
        }
    }
}
