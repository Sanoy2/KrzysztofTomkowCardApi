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

        #endregion
    }
}
