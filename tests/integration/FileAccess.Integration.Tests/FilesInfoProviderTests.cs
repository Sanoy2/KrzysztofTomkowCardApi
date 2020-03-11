using System.Linq;
using System.Collections.Generic;

using Microsoft.Extensions.FileProviders;

using FileAccess.Integration.Tests.Helpers;
using FileAccess.PhysicalFilesAccess;

using FluentAssertions;

using Xunit;

namespace FileAccess.Integration.Tests
{
    public class FilesInfoProviderTests
    {
        [Fact]
        public void When_DirectoryEmpty_Then_ReturnEmptyCollection()
        {
            using (var helper = new DirectoryHelper())
            {
                IFileProvider fileProvider = new PhysicalFileProvider(helper.DirectoryPath);
                IFilesInfoProvider filesInfoProvider = new FilesInfoProvider(fileProvider);

                IEnumerable<IFile> files = filesInfoProvider.GetFiles();

                files.Should().BeEmpty();
            }
        }

        [Fact]
        public void When_OneFile_IsInDirectory_Then_OneElementCollectionFound()
        {
            using (var helper = new DirectoryHelper())
            {
                helper.CreateFile();

                IFileProvider fileProvider = new PhysicalFileProvider(helper.DirectoryPath);
                IFilesInfoProvider filesInfoProvider = new FilesInfoProvider(fileProvider);

                IEnumerable<IFile> files = filesInfoProvider.GetFiles();

                files.Should().HaveCount(1);
            }
        }

        [Fact]
        public void When_testFileName_IsInDirectory_Then_FileWithName_testFileName_Found()
        {
            string fileName = "testFileName";

            using (var helper = new DirectoryHelper())
            {
                helper.CreateFile(fileName);

                IFileProvider fileProvider = new PhysicalFileProvider(helper.DirectoryPath);
                IFilesInfoProvider filesInfoProvider = new FilesInfoProvider(fileProvider);

                IEnumerable<IFile> files = filesInfoProvider.GetFiles();

                files.First().Name.Should().Be(fileName);
            }
        }

        [Fact]
        public void When_testFileName_txt_IsInDirectory_Then_FileWithName_testFileName_txt_Found()
        {
            string fileName = "testFileName";
            string extension = ".txt";

            using (var helper = new DirectoryHelper())
            {
                helper.CreateFile(fileName, extension);

                IFileProvider fileProvider = new PhysicalFileProvider(helper.DirectoryPath);
                IFilesInfoProvider filesInfoProvider = new FilesInfoProvider(fileProvider);

                IEnumerable<IFile> files = filesInfoProvider.GetFiles();

                files.First().Name.Should().Be(fileName);
                files.First().Extension.Should().Be(extension);
            }
        }
    }
}