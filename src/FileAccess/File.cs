using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FileAccess
{
    public class File : IFile
    {
        public string Name { get; }
        public string Extension { get => this.GetExtension(); }
        public DateTime LastModification { get; }
        public string PhysicalPath { get; }

        public File(string name, DateTime lastModification, string physicalPath)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            this.Name = this.CutExtensionOffFromName(name);
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

        private string GetExtension()
        {
            int indexOfFilename = this.PhysicalPath.LastIndexOf(this.Name);
            string filenameWithExtension = this.PhysicalPath.Substring(indexOfFilename);

            var filenameWithExtensionParts = filenameWithExtension.Split('.');
            if (filenameWithExtensionParts.Count() == 1)
            {
                return string.Empty;
            }

            return $".{filenameWithExtensionParts.Last().ToLower()}";
        }

        private string CutExtensionOffFromName(string filenameWithExtension)
        {
            string[] knownExtensions = { ".txt", ".pdf", ".png", "jpeg", "jpg" };

            if (filenameWithExtension.Length < knownExtensions.Min(n => n.Length))
            {
                return filenameWithExtension;
            }

            bool shouldExtensionBeCutOff = knownExtensions.Any(n => filenameWithExtension.Contains(n));

            if (shouldExtensionBeCutOff == false)
            {
                return filenameWithExtension;
            }

            int indexOfLastDot = filenameWithExtension.LastIndexOf('.');

            return filenameWithExtension.Substring(0, indexOfLastDot);
        }
    }
}
