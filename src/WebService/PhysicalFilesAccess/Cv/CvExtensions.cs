using FileAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.PhysicalFilesAccess.Cv
{
    public static class CvExtensions
    {
        public static ICvNameMatcher CvNameMatcher { private get; set; } = new CvNameMatcher();

        public static IQueryable<IFile> MatchCvName(this IQueryable<IFile> files, string cvNameTemplate)
        {
            return files.Where(n => CvNameMatcher.IsMatch(cvNameTemplate, n.Name)).AsQueryable();
        }
    }
}
