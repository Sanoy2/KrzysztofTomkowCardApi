using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.PhysicalFilesAccess.Cv
{
    public interface ICvNameMatcher
    {
        bool IsMatch(string nameTemplate, string name);
    }
}
