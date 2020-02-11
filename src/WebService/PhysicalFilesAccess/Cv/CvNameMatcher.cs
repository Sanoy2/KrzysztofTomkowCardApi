using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.PhysicalFilesAccess.Cv
{
    public class CvNameMatcher : ICvNameMatcher
    {
        public bool IsMatch(string nameTemplate, string name)
        {
            nameTemplate = nameTemplate.Trim();
            name = name.Trim();

            bool result = name.Contains(nameTemplate);

            return result;
        }
    }
}
