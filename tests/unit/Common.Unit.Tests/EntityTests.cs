using System;
using Xunit;
using FluentAssertions;

namespace Common.Unit.Tests
{
    public class EntityTests
    {
        private class SomeClass : Entity
        {
            public SomeClass(long id) : base(id)
            {

            }
        }

        [Theory]
        [InlineData(1)]
        [InlineData(112)]
        [InlineData(812646)]
        [InlineData(int.MaxValue)]
        [InlineData(long.MaxValue)]
        public void Ctor_WhenId_Positive_ShouldNotThrowException(long id)
        {
            SomeClass someObject = new SomeClass(id);
        }

        public void Ctor_WhenId_0_ShouldThrowArgumentException()
        {
            long id = 0;

            Action act = () =>
            {
                SomeClass someObject = new SomeClass(id);
            };

            act.Should().ThrowExactly<ArgumentException>();
        }

        public void Ctor_WhenId_Negative_ShouldThrowArgumentException()
        {
            long id = -12;

            Action act = () =>
            {
                SomeClass someObject = new SomeClass(id);
            };

            act.Should().ThrowExactly<ArgumentException>();
        }
    }
}