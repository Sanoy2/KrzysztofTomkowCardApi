using System;
using System.IO;

namespace FileAccess.Integration.Tests.Helpers
{
    internal sealed class DirectoryHelper : IDisposable
    {
        private readonly string directoryName;
        private readonly string fullPath;

        internal string DirectoryPath => this.GetPath();

        public DirectoryHelper(string directoryName)
        {
            this.directoryName = directoryName;
            this.fullPath = this.GetPath();
        }

        public void Dispose()
        {
            this.RemoveDirectory();
        }

        private void CreateDirectory()
        {
            Directory.CreateDirectory(this.fullPath);
        }

        private void RemoveDirectory()
        {
            Directory.Delete(this.fullPath, true);
        }

        private string GetPath()
        {
            return $"{this.GetCurrentDirectory()}/{this.directoryName}";
        }

        private string GetCurrentDirectory()
        {
            return Directory.GetCurrentDirectory();
        }
    }
}