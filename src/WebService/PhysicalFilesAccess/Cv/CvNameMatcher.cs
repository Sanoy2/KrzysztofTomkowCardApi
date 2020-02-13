using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.PhysicalFilesAccess.Cv
{
    public class CvNameMatcher : ICvNameMatcher
    {
        public bool IsMatch(string cvNameTemplate, string comparedName)
        {
            if (cvNameTemplate is null)
            {
                throw new ArgumentNullException(nameof(cvNameTemplate));
            }

            if (string.IsNullOrWhiteSpace(cvNameTemplate) || cvNameTemplate == string.Empty)
            {
                throw new ArgumentException(nameof(cvNameTemplate));
            }

            if (comparedName is null)
            {
                throw new ArgumentNullException(nameof(comparedName));
            }

            cvNameTemplate = cvNameTemplate.Trim();
            comparedName = comparedName.Trim();

            bool result = comparedName.Contains(cvNameTemplate);

            return result;
        }
    }
}
