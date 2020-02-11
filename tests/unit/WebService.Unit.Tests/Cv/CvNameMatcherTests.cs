using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace WebService.Unit.Tests.Cv
{
    public class CvNameMatcherTests
    {
        [Fact]
        public void Test()
        {
            true.Should().BeTrue();
        }

        [Fact]
        public void Test2()
        {
            true.Should().BeFalse();
        }
    }
}
