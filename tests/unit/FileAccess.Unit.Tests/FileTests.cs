using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

using FileAccess;
using FluentAssertions;

namespace FileAccess.Unit.Tests
{
    public class FileTests
    {
        private string correctName;
        private DateTime correctLastModificationTime;
        private string correctPhysicalPath;

        public FileTests()
        {
            this.correctName = "filename";
            this.correctLastModificationTime = new DateTime(2020, 1, 1, 10, 0, 0);
            this.correctPhysicalPath = "/home/user/files/filename.pdf";
        }

        #region Constructor

        [Fact]
        public void Constructor_EverythingIsFine_Should_BeFine()
        {
            IFile file = new File(this.correctName, this.correctLastModificationTime, this.correctPhysicalPath);

            file.Should().NotBeNull();
            file.Should().BeOfType(typeof(File));

            file.Name.Should().Be(this.correctName);
            file.LastModification.Should().Be(this.correctLastModificationTime);
            file.PhysicalPath.Should().Be(this.correctPhysicalPath);
        }

        [Fact]
        public void Constructor_WhenNameIsNull_Should_ThrowArgumentNullException()
        {
            string nullName = null;

            Action act = () =>
            {
                IFile file = new File(nullName, this.correctLastModificationTime, this.correctPhysicalPath);
            };

            act.Should().ThrowExactly<ArgumentNullException>();
        }

        [Fact]
        public void Constructor_WhenNameIsNull_Should_ThrowArgumentNullExceptionWithParamName()
        {
            string nullName = null;

            Action act = () =>
            {
                IFile file = new File(nullName, this.correctLastModificationTime, this.correctPhysicalPath);
            };

            act.Should().ThrowExactly<ArgumentNullException>().And.ParamName.Should().Be("name");
        }

        [Fact]
        public void Constructor_WhenPhysicalPathIsNull_Should_ThrowArgumentNullException()
        {
            string nullPhysicalPath = null;

            Action act = () =>
            {
                IFile file = new File(this.correctName, this.correctLastModificationTime, nullPhysicalPath);
            };

            act.Should().ThrowExactly<ArgumentNullException>();
        }

        [Fact]
        public void Constructor_WhenPhysicalPathIsNull_Should_ThrowArgumentNullExceptionWithParamName()
        {
            string nullPhysicalPath = null;

            Action act = () =>
            {
                IFile file = new File(this.correctName, this.correctLastModificationTime, nullPhysicalPath);
            };

            act.Should().ThrowExactly<ArgumentNullException>().And.ParamName.Should().Be("physicalPath");
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("   ")]
        [InlineData("    ")]
        [InlineData("\n")]
        [InlineData("\t")]
        public void Constructor_WhenNameIsEmptyOrWhitespace_Should_ThrowArgumentException(string filename)
        {
            Action act = () =>
            {
                IFile file = new File(filename, this.correctLastModificationTime, this.correctPhysicalPath);
            };

            act.Should().ThrowExactly<ArgumentException>().WithMessage("name");
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("   ")]
        [InlineData("    ")]
        [InlineData("\n")]
        [InlineData("\t")]
        public void Constructor_WhenPhysicalPathIsEmptyOrWhitespace_Should_ThrowArgumentException(string physicalPath)
        {
            Action act = () =>
            {
                IFile file = new File(this.correctName, this.correctLastModificationTime, physicalPath);
            };

            act.Should().ThrowExactly<ArgumentException>().WithMessage("physicalPath");
        }

        [Fact]
        public void Constructor_WhenNameAndPhysicalPathEmpty_Should_ThrowArgumentException()
        {
            string emptyName = string.Empty;
            string emptyPath = string.Empty;

            Action act = () =>
            {
                IFile file = new File(emptyName, this.correctLastModificationTime, emptyPath);
            };

            act.Should().ThrowExactly<ArgumentException>();
        }

        [Fact]
        public void Constructor_WhenNameIsNotSubstringOfPhysicalPath_Should_ThrowFileIncoherentPath()
        {
            string wrongName = "dupa";
            string correctPath = "/home/user/files/images/filename.jpg";

            Action act = () =>
            {
                IFile file = new File(wrongName, this.correctLastModificationTime, correctPath);
            };

            act.Should().ThrowExactly<FileIncoherentPathException>();
        }

        [Fact]
        public void Constructor_WhenNameIsSubstringOfPathOtherCase_Should_ThrowFileIncoherentPath()
        {
            string wrongName = "fileNAME";
            string correctPath = "/home/user/files/images/filename.jpg";

            Action act = () =>
            {
                IFile file = new File(wrongName, this.correctLastModificationTime, correctPath);
            };

            act.Should().ThrowExactly<FileIncoherentPathException>();
        }

        [Fact]
        public void Extension_WhenFileIsPdf_Should_ReturnPdf()
        {
            string filename = "fancyFilename";
            string correctPath = "/usr/share/images/fancyFilename.pdf";
            string expectedExtension = ".pdf";

            IFile file = new File(filename, this.correctLastModificationTime, correctPath);
            string obtainedExtension = file.Extension;

            obtainedExtension.Should().Be(expectedExtension);
        }

        [Fact]
        public void Extension_WhenFileIsPdfUppercaseExtension_Should_ReturnPdfLowercase()
        {
            string filename = "fancyFilename";
            string correctPath = "/usr/share/images/fancyFilename.PDF";
            string expectedExtension = ".pdf";

            IFile file = new File(filename, this.correctLastModificationTime, correctPath);
            string obtainedExtension = file.Extension;

            obtainedExtension.Should().Be(expectedExtension);
        }

        [Fact]
        public void Extension_WhenFileIsJpg_Should_ReturnJpg()
        {
            string filename = "fancyPicture";
            string correctPath = "/usr/share/images/fancyPicture.jpg";
            string expectedExtension = ".jpg";

            IFile file = new File(filename, this.correctLastModificationTime, correctPath);
            string obtainedExtension = file.Extension;

            obtainedExtension.Should().Be(expectedExtension);
        }

        [Fact]
        public void Extension_WhenFileIsJsonWithDotInside_Should_ReturnJson()
        {
            string filename = "application.Development";
            string correctPath = "/usr/share/images/application.Development.json";
            string expectedExtension = ".json";

            IFile file = new File(filename, this.correctLastModificationTime, correctPath);
            string obtainedExtension = file.Extension;

            obtainedExtension.Should().Be(expectedExtension);
        }

        [Fact]
        public void Extension_WhenFileHasNoExtension_Should_ReturnEmptyString()
        {
            string filename = "fileWithNoExtension";
            string correctPath = "/usr/share/images/fileWithNoExtension";
            string expectedExtension = string.Empty;

            IFile file = new File(filename, this.correctLastModificationTime, correctPath);
            string obtainedExtension = file.Extension;

            obtainedExtension.Should().Be(expectedExtension);
        }

        [Theory]
        [InlineData(@"/home/usr/")]
        [InlineData(@"~/usr/")]
        [InlineData(@"home/usr/")]
        [InlineData(@"home/dotnet/ASP/develop/tests/integration/images/")]
        [InlineData(@"C:/dotnet/files")]
        [InlineData(@"D:/Program Files/ASP/")]
        [InlineData(@"D:/Program Files/ASP/develop/tests/integration/images/")]
        public void Extension_WhenLinuxOrWindowsUsedToStorePdf_Should_ReturnPdf(string physicalFilePathWithNoExtension)
        {
            string filename = "filename";
            string expectedExtension = ".pdf";
            string correctPath = $"{physicalFilePathWithNoExtension}{filename}{expectedExtension}";

            IFile file = new File(filename, this.correctLastModificationTime, correctPath);
            string obtainedExtension = file.Extension;

            obtainedExtension.Should().Be(expectedExtension);
        }

        #endregion
    }
}
