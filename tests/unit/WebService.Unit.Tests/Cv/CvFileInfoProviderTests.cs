using FileAccess;
using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebService.PhysicalFilesAccess.Cv;
using Xunit;

namespace WebService.Unit.Tests.Cv
{
    public class CvFileInfoProviderTests
    {
        private readonly ICvFileInfoProvider cvFileInfoProvider;
        private readonly IFilesInfoProvider filesInfoProvider;

        public CvFileInfoProviderTests()
        {
            this.filesInfoProvider = Substitute.For<IFilesInfoProvider>();

            ICvNameMatcher alwaysTrueCvNameMatcher = Substitute.For<ICvNameMatcher>();
            alwaysTrueCvNameMatcher.IsMatch(Arg.Any<string>(), Arg.Any<string>()).Returns(true);
            CvExtensions.CvNameMatcher = alwaysTrueCvNameMatcher;

            this.cvFileInfoProvider = new CvFileInfoProvider(filesInfoProvider);
        }

        [Fact]
        public void WhenFilesInfoProviderIsNull_Should_ThrowArgumentNullException()
        {
            IFilesInfoProvider nullProvider = null;

            Action act = () => { ICvFileInfoProvider cvFileInfoProvider = new CvFileInfoProvider(nullProvider); };

            act.Should().ThrowExactly<ArgumentNullException>();
        }

        [Fact]
        public void WhenNoFileAvailable_Should_ThrowInvalidOperationException()
        {
            var returnedFiles = new List<IFile>();
            this.filesInfoProvider.GetFiles().Returns(returnedFiles.AsQueryable());

            Action act = () => { IFile cvFile = this.cvFileInfoProvider.GetFile(); };

            act.Should().ThrowExactly<CvNotFoundException>();
        }

        [Fact]
        public void WhenOneFileAvailable_Should_ReturnThatFile()
        {
            var returnedFiles = new List<IFile>();
            returnedFiles.Add(new File("CV", DateTime.Now, "/home/CV.pdf"));
            this.filesInfoProvider.GetFiles().Returns(returnedFiles.AsQueryable());

            IFile cvFile = this.cvFileInfoProvider.GetFile();

            cvFile.Name.Should().Be("CV");
            cvFile.PhysicalPath.Should().Be("/home/CV.pdf");
        }

        [Fact]
        public void WhenTwoFileAvailable_Should_ReturnYoungerFile()
        {
            var returnedFiles = new List<IFile>();
            returnedFiles.Add(new File("CV", new DateTime(2015, 10, 28), "/home/CV.pdf"));
            returnedFiles.Add(new File("CV_New", new DateTime(2015, 11, 05), "/home/CV_New.pdf"));
            this.filesInfoProvider.GetFiles().Returns(returnedFiles.AsQueryable());

            IFile cvFile = this.cvFileInfoProvider.GetFile();

            cvFile.Name.Should().Be("CV_New");
            cvFile.LastModification.Should().Be(new DateTime(2015, 11, 05));
            cvFile.PhysicalPath.Should().Be("/home/CV_New.pdf");
        }
    }
}
