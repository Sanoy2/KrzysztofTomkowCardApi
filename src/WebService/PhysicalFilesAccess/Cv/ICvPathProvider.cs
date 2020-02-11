using FileAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.PhysicalFilesAccess.Cv
{
    public interface ICvPathProvider
    {
        string GetPhysicalPath();
    }
}
