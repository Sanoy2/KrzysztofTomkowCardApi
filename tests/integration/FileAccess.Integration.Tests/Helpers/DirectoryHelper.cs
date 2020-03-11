using System;
using System.IO;

namespace FileAccess.Integration.Tests.Helpers
{
    internal sealed class DirectoryHelper : IFileCreator, IDisposable
    {
        private readonly string directoryName;
        private readonly string fullPath;

        internal string DirectoryPath => this.GetPath();

        public DirectoryHelper()
        {
            this.directoryName = Guid.NewGuid().ToString();
            this.fullPath = this.GetPath();

            this.CreateDirectory();
        }

        public DirectoryHelper(string directoryName)
        {
            this.directoryName = directoryName;
            this.fullPath = this.GetPath();

            this.CreateDirectory();
        }

        public void CreateFile()
        {
            string name = Guid.NewGuid().ToString();


            this.CreateFile(name);
        }

        public void CreateFile(string name)
        {
            string extension = this.GetRandomExtension();

            this.CreateFile(name, extension);
        }

        public void CreateFile(string name, string extension)
        {
            if (extension.StartsWith('.') == false)
            {
                extension = '.' + extension;
            }

            string path = $"{this.fullPath}/{name}{extension}";
            System.IO.File.Create(path);
        }

        public void Dispose()
        {
            this.RemoveDirectory();
        }

        private void CreateDirectory()
        {
            this.DeleteDirectoryIfExist();
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

        private void DeleteDirectoryIfExist()
        {
            if (Directory.Exists(this.fullPath))
            {
                this.RemoveDirectory();
            }
        }

        private string GetRandomExtension()
        {
            string[] extensions = { ".txt", ".pdf", ".jpg", ".jpeg", ".png" };

            var random = new Random();
            int randomExtensionIndex = random.Next(extensions.Length);

            return extensions[randomExtensionIndex];
        }
    }
}