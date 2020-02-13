using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using WebService.PhysicalFilesAccess.Cv;
using Xunit;

namespace WebService.Unit.Tests.Cv
{
    public class CvNameMatcherTests
    {
        private readonly CvNameMatcher cvNameMatcher;

        public CvNameMatcherTests()
        {
            this.cvNameMatcher = new CvNameMatcher();
        }

        #region Should not be valid

        [Fact]
        public void WhenNameDoesNotMatchCase_Should_BeFalse()
        {
            string cvFilenameTemplate = "CV";
            string cvFilename = "cv";

            bool result = this.cvNameMatcher.IsMatch(cvFilenameTemplate, cvFilename);

            result.Should().BeFalse();
        }

        [Theory]
        [InlineData("cev")]
        [InlineData("c_v")]
        [InlineData("newOne")]
        [InlineData("oldCW")]
        [InlineData("super_vc_02_s")]
        public void WhenNameNotInTemplate_Should_BeFalse(string cvFilename)
        {
            string cvFilenameTemplate = "CV";

            bool result = this.cvNameMatcher.IsMatch(cvFilenameTemplate, cvFilename);

            result.Should().BeFalse();
        }

        [Theory]
        [InlineData("new_Cv")]
        [InlineData("cV_NOWE")]
        [InlineData("cv_Color")]
        [InlineData("Brand_new_Cvv_thebest")]
        [InlineData("cV-Cv")]
        [InlineData("New-2020-Cv-kt-.net")]
        public void WhenNameContainedByTemplateButOtherCase_Should_BeFalse(string cvFilename)
        {
            string cvFilenameTemplate = "CV";

            bool result = this.cvNameMatcher.IsMatch(cvFilenameTemplate, cvFilename);

            result.Should().BeFalse();
        }

        [Fact]
        public void WhenNameShorterThanTemplate_Should_BeFalse()
        {
            string cvFilenameTemplate = "CV";
            string cvFilename = "C";

            bool result = this.cvNameMatcher.IsMatch(cvFilenameTemplate, cvFilename);

            result.Should().BeFalse();
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("   ")]
        [InlineData("    ")]
        [InlineData("\n")]
        [InlineData("\t")]
        public void WhenNameEmptyOrWhitespace_Should_BeFalse(string cvFilename)
        {
            string cvFilenameTemplate = "CV";

            bool result = this.cvNameMatcher.IsMatch(cvFilenameTemplate, cvFilename);

            result.Should().BeFalse();
        }

        #endregion

        #region Should be valid

        [Fact]
        public void WhenNameEqualTemplate_Should_BeTrue()
        {
            string cvFilenameTemplate = "CV";
            string cvFilename = "CV";

            bool result = this.cvNameMatcher.IsMatch(cvFilenameTemplate, cvFilename);

            result.Should().BeTrue();
        }

        [Theory]
        [InlineData("CV ")]
        [InlineData("CV   ")]
        [InlineData(" CV ")]
        [InlineData("  CV  ")]
        [InlineData(" CV")]
        [InlineData("  CV")]
        [InlineData("\tCV")]
        [InlineData("\nCV")]
        [InlineData("CV\n")]
        [InlineData("CV\n\t\n")]
        public void WhenNameEqualTemplateAndHasWhitespaceOnEdge_Should_BeTrue(string cvFilename)
        {
            string cvFilenameTemplate = "CV";

            bool result = this.cvNameMatcher.IsMatch(cvFilenameTemplate, cvFilename);

            result.Should().BeTrue();
        }

        [Theory]
        [InlineData("CV ")]
        [InlineData("CV   ")]
        [InlineData(" CV ")]
        [InlineData("  CV  ")]
        [InlineData(" CV")]
        [InlineData("  CV")]
        [InlineData("\tCV")]
        [InlineData("\nCV")]
        [InlineData("CV\n")]
        [InlineData("CV\n\t\n")]
        public void WhenNameEqualTemplateAndTemplateHasWhitespaceOnEdge_Should_BeTrue(string cvFilenameTemplate)
        {
            string cvFilename = "CV";

            bool result = this.cvNameMatcher.IsMatch(cvFilenameTemplate, cvFilename);

            result.Should().BeTrue();
        }

        [Theory]
        [InlineData("new_CV")]
        [InlineData("CV_NOWE")]
        [InlineData("CV_Color")]
        [InlineData("CVV_Color")]
        [InlineData("CVv_black")]
        [InlineData("Brand_new_CV_thebest")]
        [InlineData("CV-CV")]
        [InlineData("CV-CCV")]
        [InlineData("CCV-cCV")]
        [InlineData("cv-CCCVVV-cw")]
        [InlineData("New-2020-CV-kt-.net")]
        public void WhenNameContainedByTemplate_Should_BeTrue(string cvFilename)
        {
            string cvFilenameTemplate = "CV";

            bool result = this.cvNameMatcher.IsMatch(cvFilenameTemplate, cvFilename);

            result.Should().BeTrue();
        }

        #endregion

        #region Exceptions

        [Fact]
        public void WhenNameIsNull_Should_ThrowArgumentNullException()
        {
            string cvFilenameTemplate = "CV";
            string cvFilename = null;

            Action act = () =>
            {
                bool result = this.cvNameMatcher.IsMatch(cvFilenameTemplate, cvFilename);
            };

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void WhenNameIsNull_Should_ThrowArgumentNullExceptionWithParamName()
        {
            string cvFilenameTemplate = "CV";
            string cvFilename = null;

            Action act = () =>
            {
                bool result = this.cvNameMatcher.IsMatch(cvFilenameTemplate, cvFilename);
            };

            act.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("comparedName");
        }

        [Fact]
        public void WhenTemplateIsNull_Should_ThrowArgumentNullException()
        {
            string cvFilenameTemplate = null;
            string cvFilename = "CV";

            Action act = () =>
            {
                bool result = this.cvNameMatcher.IsMatch(cvFilenameTemplate, cvFilename);
            };

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void WhenTemplateIsNull_Should_ThrowArgumentNullExceptionWithParamName()
        {
            string cvFilenameTemplate = null;
            string cvFilename = "CV";

            Action act = () =>
            {
                bool result = this.cvNameMatcher.IsMatch(cvFilenameTemplate, cvFilename);
            };

            act.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("cvNameTemplate");
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("   ")]
        [InlineData("    ")]
        [InlineData("\n")]
        [InlineData("\t")]
        public void WhenTemplateIsEmptyOrWhitespace_Should_ThrowArgumentException(string cvFilenameTemplate)
        {
            string cvFilename = "CV";

            Action act = () =>
            {
                bool result = this.cvNameMatcher.IsMatch(cvFilenameTemplate, cvFilename);
            };

            act.Should().Throw<ArgumentException>();
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("   ")]
        [InlineData("    ")]
        [InlineData("\n")]
        [InlineData("\t")]
        public void WhenTemplateIsEmptyOrWhitespace_Should_ThrowArgumentExceptionWithParamName(string cvFilenameTemplate)
        {
            string cvFilename = "CV";

            Action act = () =>
            {
                bool result = this.cvNameMatcher.IsMatch(cvFilenameTemplate, cvFilename);
            };

            act.Should().Throw<ArgumentException>().WithMessage("cvNameTemplate");
        }

        #endregion
    }
}
