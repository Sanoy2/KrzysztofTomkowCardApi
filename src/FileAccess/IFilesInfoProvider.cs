using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileAccess
{
    public interface IFilesInfoProvider
    {
        IQueryable<IFile> GetFiles();
    }
}
