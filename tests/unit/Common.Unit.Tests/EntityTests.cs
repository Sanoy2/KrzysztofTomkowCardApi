using System;
using Xunit;
using FluentAssertions;

namespace Common.Unit.Tests
{
    public class EntityTests
    {
        private class SomeClass : Entity
        {
            public SomeClass()
            {

            }
        }


        [Fact]
        public void Ctor_IfClassBasedOnEntityClass_ShouldHaveIdInitialized()
        {
            SomeClass someObject = new SomeClass();

            someObject.Id.Should().NotBe(Guid.Empty);
        }
    }
}