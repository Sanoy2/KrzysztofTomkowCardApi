using FluentAssertions;

using Xunit;

namespace WebService.Unit.Tests
{
    public class Failtest
    {
        [Fact]
        public void Fail()
        {
            true.Should().BeFalse();
        }
    }
}