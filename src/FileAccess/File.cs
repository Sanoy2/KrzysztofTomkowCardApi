using System;
using System.Collections.Generic;
using System.Text;

namespace FileAccess
{
    public class File : IFile
    {
        public string Name { get; }
        public DateTime LastModification { get; }
        public string PhysicalPath { get; }

        public File(string name, DateTime lastModification, string physicalPath)
        {
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
            this.LastModification = lastModification;
            this.PhysicalPath = physicalPath ?? throw new ArgumentNullException(nameof(physicalPath));

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(nameof(name));

            if (string.IsNullOrWhiteSpace(physicalPath))
                throw new ArgumentException(nameof(physicalPath));

            if (this.IsPathCoherentWithName() == false)
            {
                throw new FileIncoherentPathException();
            }
        }

        private bool IsPathCoherentWithName()
        {
            return this.PhysicalPath.Contains(this.Name);
        }
    }
}
