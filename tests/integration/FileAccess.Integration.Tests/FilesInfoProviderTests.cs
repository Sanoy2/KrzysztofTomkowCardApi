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

                files.Single().Name.Should().Be(fileName);
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

                files.Single().Name.Should().Be(fileName);
                files.Single().Extension.Should().Be(extension);
            }
        }

        [Theory]
        [InlineData(".pdf")]
        [InlineData(".txt")]
        [InlineData(".jpg")]
        [InlineData(".jpeg")]
        [InlineData(".png")]
        public void When_file_WithGivenKnownExtension_IsInDirectory_Then_FileWithGivenExtensionCutOffFromName_Found(string extension)
        {
            string fileName = "testFileName";

            using (var helper = new DirectoryHelper())
            {
                helper.CreateFile(fileName, extension);

                IFileProvider fileProvider = new PhysicalFileProvider(helper.DirectoryPath);
                IFilesInfoProvider filesInfoProvider = new FilesInfoProvider(fileProvider);

                IEnumerable<IFile> files = filesInfoProvider.GetFiles();

                files.Single().Name.Should().Be(fileName);
                files.Single().Extension.Should().Be(extension);
            }
        }

        [Theory]
        [InlineData(".a")]
        [InlineData(".cs")]
        [InlineData(".cpp")]
        [InlineData(".somestrangeextension")]
        [InlineData(".gif")]
        [InlineData(".xml")]
        [InlineData(".json")]
        public void When_file_WithGivenUnknownExtension_IsInDirectory_Then_FileWithGivenExtensionInName_Found(string extension)
        {
            string fileName = "testFileName";

            using (var helper = new DirectoryHelper())
            {
                helper.CreateFile(fileName, extension);

                IFileProvider fileProvider = new PhysicalFileProvider(helper.DirectoryPath);
                IFilesInfoProvider filesInfoProvider = new FilesInfoProvider(fileProvider);

                IEnumerable<IFile> files = filesInfoProvider.GetFiles();

                files.Single().Name.Should().Be($"{fileName}{extension}");
                files.Single().Extension.Should().Be(extension);
            }
        }
    }
}