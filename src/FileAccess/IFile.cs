﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FileAccess
{
    public interface IFile
    {
        string Name { get; }
        string Extension { get; }
        DateTime LastModification { get; }
        string PhysicalPath { get; }
    }
}
