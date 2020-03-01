using System;

using Microsoft.Extensions.FileProviders;

using FileAccess.PhysicalFilesAccess;

using FluentAssertions;

using Xunit;
using FileAccess.Integration.Tests.Helpers;

namespace FileAccess.Integration.Tests
{
    public class FilesInfoProviderTests
    {
        [Fact]
        public void ExampleHelperUsage()
        {
            using (var helper = new DirectoryHelper("testDirectory"))
            {
                helper.CreateFile("testFileName", ".txt");

                IFileProvider fileProvider = new PhysicalFileProvider(helper.DirectoryPath);
                IFilesInfoProvider filesInfoProvider = new FilesInfoProvider(fileProvider);
            }
        }
    }
}