using System;
using Xunit;
using FluentAssertions;

namespace Common.Unit.Tests
{
    public class EntityTests
    {
        [Fact]
        public void Ctor_IfClassBasedOnEntityClass_ShouldHaveIdInitialized()
        {
            SomeEntity someEntity = new SomeEntity();

            someEntity.Id.Should().NotBe(Guid.Empty);
        }

        [Fact]
        public void Equals_WhenCompareToNull_ShouldBeFalse()
        {
            bool result;
            SomeEntity someEntity = new SomeEntity();

            result = someEntity.Equals(null);

            result.Should().BeFalse(); 
        }

        [Fact]
        public void Equals_WhenCompareToItself_ShouldBeFalse()
        {
            bool result;
            SomeEntity someEntity = new SomeEntity();

            result = someEntity.Equals(someEntity);

            result.Should().BeFalse();
        }

        [Fact]
        public void Equals_WhenCompareSameObject_ShouldBeFalse()
        {
            bool result;
            SomeEntity someEntity = new SomeEntity();
            SomeEntity someOtherClass = someEntity;

            result = someEntity.Equals(someOtherClass);

            result.Should().BeFalse();
        }

        [Fact]
        public void Equals_WhenCompareToOtherType_ShouldBeFalse()
        {
            bool result;
            SomeEntity someEntity = new SomeEntity();
            OtherClass otherClass = new OtherClass();

            result = someEntity.Equals(otherClass);

            result.Should().BeFalse();
        }

        [Fact]
        public void Equals_WhenCompareToOtherEntity_ShouldBeFalse()
        {
            bool result;
            SomeEntity someEntity = new SomeEntity();
            OtherEntity someOtherEntity = new OtherEntity();

            result = someEntity.Equals(someOtherEntity);

            result.Should().BeFalse();
        }

        [Fact]
        public void Equals_WhenCompareToOtherEntityWithTheSameType_ShouldBeFalse()
        {
            bool result;
            SomeEntity someEntity = new SomeEntity();
            SomeEntity someOtherEntity = new SomeEntity();

            result = someEntity.Equals(someOtherEntity);

            result.Should().BeTrue();
        }

        private class SomeEntity : Entity
        {
            public int SomeIntProperty { get; set; }
            public int SomeStringProperty { get; set; }

            public override bool Equals(object obj)
            {
                bool typeMatch = base.EqualsType<SomeEntity>(obj);

                return typeMatch;
            }

            public override int GetHashCode()
            {
                throw new NotImplementedException();
            }
        }

        private class OtherEntity : Entity
        {
            public override bool Equals(object obj)
            {
                throw new NotImplementedException();
            }

            public override int GetHashCode()
            {
                throw new NotImplementedException();
            }
        }

        private class OtherClass
        {
            public int SingleProperty { get; set; }
        }
    }
}