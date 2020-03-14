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

        [Fact]
        public void When_2FilesWithTheSameNameAndDifferentExtension_AreInDirectory_Then_2ElementCollection_Found()
        {
            string fileName = "testFileName";
            string extension1 = ".txt";
            string extension2 = ".pdf";

            using (var helper = new DirectoryHelper())
            {
                helper.CreateFile(fileName, extension1);
                helper.CreateFile(fileName, extension2);

                IFileProvider fileProvider = new PhysicalFileProvider(helper.DirectoryPath);
                IFilesInfoProvider filesInfoProvider = new FilesInfoProvider(fileProvider);

                IEnumerable<IFile> files = filesInfoProvider.GetFiles();

                files.Should().HaveCount(2);
            }
        }

        [Fact]
        public void When_2Files_AreInDirectory_Then_2ElementCollection_FoundWithProperName()
        {
            string fileName1 = "testFilename1";
            string fileName2 = "testFilename2";

            string extension1 = ".txt";
            string extension2 = ".pdf";

            using (var helper = new DirectoryHelper())
            {
                helper.CreateFile(fileName1, extension1);
                helper.CreateFile(fileName2, extension2);

                IFileProvider fileProvider = new PhysicalFileProvider(helper.DirectoryPath);
                IFilesInfoProvider filesInfoProvider = new FilesInfoProvider(fileProvider);

                IEnumerable<IFile> files = filesInfoProvider.GetFiles();

                files.Single(n => n.Name == fileName1);
                files.Single(n => n.Name == fileName2);
            }
        }

        [Fact]
        public void When_2Files_AreInDirectory_Then_2ElementCollection_FoundWithProperNameAndExtension()
        {
            string fileName1 = "testFilename1";
            string fileName2 = "testFilename2";

            string extension1 = ".txt";
            string extension2 = ".pdf";

            using (var helper = new DirectoryHelper())
            {
                helper.CreateFile(fileName1, extension1);
                helper.CreateFile(fileName2, extension2);

                IFileProvider fileProvider = new PhysicalFileProvider(helper.DirectoryPath);
                IFilesInfoProvider filesInfoProvider = new FilesInfoProvider(fileProvider);

                IEnumerable<IFile> files = filesInfoProvider.GetFiles();

                files.Single(n => n.Name == fileName1 && n.Extension == extension1);
                files.Single(n => n.Name == fileName2 && n.Extension == extension2);
            }
        }

        [Fact]
        public void When_2Files_AreInDirectory_Then_TwoElementCollection_Found()
        {
            using (var helper = new DirectoryHelper())
            {
                helper.CreateFile();
                helper.CreateFile();

                IFileProvider fileProvider = new PhysicalFileProvider(helper.DirectoryPath);
                IFilesInfoProvider filesInfoProvider = new FilesInfoProvider(fileProvider);

                IEnumerable<IFile> files = filesInfoProvider.GetFiles();

                files.Should().HaveCount(2);
            }
        }

        [Fact]
        public void When_5Files_AreInDirectory_Then_5ElementCollection_Found()
        {
            using (var helper = new DirectoryHelper())
            {
                helper.CreateFile();
                helper.CreateFile();
                helper.CreateFile();
                helper.CreateFile();
                helper.CreateFile();

                IFileProvider fileProvider = new PhysicalFileProvider(helper.DirectoryPath);
                IFilesInfoProvider filesInfoProvider = new FilesInfoProvider(fileProvider);

                IEnumerable<IFile> files = filesInfoProvider.GetFiles();

                files.Should().HaveCount(5);
            }
        }

        [Fact]
        public void When_15827Files_AreInDirectory_Then_15827ElementCollection_Found()
        {
            using (var helper = new DirectoryHelper())
            {
                for (int i = 0; i < 15827; i++)
                {
                    helper.CreateFile();
                }

                IFileProvider fileProvider = new PhysicalFileProvider(helper.DirectoryPath);
                IFilesInfoProvider filesInfoProvider = new FilesInfoProvider(fileProvider);

                IEnumerable<IFile> files = filesInfoProvider.GetFiles();

                files.Should().HaveCount(15827);
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