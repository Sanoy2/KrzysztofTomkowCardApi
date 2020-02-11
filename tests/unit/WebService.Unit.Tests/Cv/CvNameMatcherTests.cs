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
            string template = "CV";
            string name = "cv";

            bool result = this.cvNameMatcher.IsMatch(template, name);

            result.Should().BeFalse();
        }

        [Theory]
        [InlineData("cev")]
        [InlineData("c_v")]
        [InlineData("newOne")]
        [InlineData("oldCW")]
        [InlineData("super_vc_02_s")]
        public void WhenNameNotInTemplate_Should_BeFalse(string name)
        {
            string template = "CV";

            bool result = this.cvNameMatcher.IsMatch(template, name);

            result.Should().BeFalse();
        }

        [Theory]
        [InlineData("new_Cv")]
        [InlineData("cV_NOWE")]
        [InlineData("cv_Color")]
        [InlineData("Brand_new_Cvv_thebest")]
        [InlineData("cV-Cv")]
        [InlineData("New-2020-Cv-kt-.net")]
        public void WhenNameContainedByTemplateButOtherCase_Should_BeFalse(string name)
        {
            string template = "CV";

            bool result = this.cvNameMatcher.IsMatch(template, name);

            result.Should().BeFalse();
        }

        #endregion Shold not be valid

        #region Should not valid

        [Fact]
        public void WhenNameEqualTemplate_Should_BeTrue()
        {
            string template = "CV";
            string name = "CV";

            bool result = this.cvNameMatcher.IsMatch(template, name);

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
        public void WhenNameEqualTemplateAndHasWhitespaceOnEdge_Should_BeTrue(string name)
        {
            string template = "CV";

            bool result = this.cvNameMatcher.IsMatch(template, name);

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
        public void WhenNameEqualTemplateAndTemplateHasWhitespaceOnEdge_Should_BeTrue(string template)
        {
            string name = "CV";

            bool result = this.cvNameMatcher.IsMatch(template, name);

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
        public void WhenNameContainedByTemplate_Should_BeTrue(string name)
        {
            string template = "CV";

            bool result = this.cvNameMatcher.IsMatch(template, name);

            result.Should().BeTrue();
        }

        #endregion Should not valid
    }
}
