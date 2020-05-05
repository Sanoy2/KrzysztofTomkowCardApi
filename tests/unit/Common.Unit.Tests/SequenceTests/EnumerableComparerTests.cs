using Common.Sequence.Implementations;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Common.Unit.Tests.SequenceTests
{
    public class EnumerableComparerTests
    {
        public EnumerableComparer EnumerableComparer { get; }

        public EnumerableComparerTests()
        {
            this.EnumerableComparer = new EnumerableComparer();
        }

        #region Simple type
        #region Exceptions
        [Fact]
        public void Int_Null_AND_Null_ShouldThrowArgumentNullException()
        {
            IEnumerable<int> collection1 = null;
            IEnumerable<int> collection2 = null;

            Action act = () =>
            {
                this.EnumerableComparer.IsContentTheSame(collection1, collection2);
            };

            act.Should().ThrowExactly<ArgumentNullException>();
        }

        [Fact]
        public void Int_Empty_AND_Null_ShouldThrowArgumentNullException()
        {
            IEnumerable<int> collection1 = Enumerable.Empty<int>();
            IEnumerable<int> collection2 = null;

            Action act = () =>
            {
                this.EnumerableComparer.IsContentTheSame(collection1, collection2);
            };

            act.Should().ThrowExactly<ArgumentNullException>();
        }

        [Fact]
        public void Int_Null_AND_Empty_ShouldThrowArgumentNullException()
        {
            IEnumerable<int> collection1 = null;
            IEnumerable<int> collection2 = Enumerable.Empty<int>();

            Action act = () =>
            {
                this.EnumerableComparer.IsContentTheSame(collection1, collection2);
            };

            act.Should().ThrowExactly<ArgumentNullException>();
        }

        #endregion

        #region True

        [Fact]
        public void Int_Empty_AND_Empty_ShouldBeTrue()
        {
            IEnumerable<int> collection1 = Enumerable.Empty<int>();
            IEnumerable<int>  collection2 = Enumerable.Empty<int>();

            bool result = this.EnumerableComparer.IsContentTheSame(collection1, collection2);

            result.Should().BeTrue();
        }

        [Fact]
        public void Int_1_AND_1_ShouldBeTrue()
        {
            IEnumerable<int> collection1 = new int[] { 1 }; 
            IEnumerable<int> collection2 = new int[] { 1 };

            bool result = this.EnumerableComparer.IsContentTheSame(collection1, collection2);

            result.Should().BeTrue();
        }

        [Fact]
        public void Int_1_3_AND_1_3_ShouldBeTrue()
        {
            IEnumerable<int> collection1 = new int[] { 1, 3 };
            IEnumerable<int> collection2 = new int[] { 1, 3 };

            bool result = this.EnumerableComparer.IsContentTheSame(collection1, collection2);

            result.Should().BeTrue();
        }

        [Fact]
        public void Int_1_3_AND_3_1_ShouldBeTrue()
        {
            IEnumerable<int> collection1 = new int[] { 1, 3 };
            IEnumerable<int> collection2 = new int[] { 3, 1 };

            bool result = this.EnumerableComparer.IsContentTheSame(collection1, collection2);

            result.Should().BeTrue();
        }

        [Fact]
        public void Int_1_3_3_9_AND_1_3_3_9_ShouldBeTrue()
        {
            IEnumerable<int> collection1 = new int[] { 1, 3, 3, 9};
            IEnumerable<int> collection2 = new int[] { 1, 3, 3, 9};

            bool result = this.EnumerableComparer.IsContentTheSame(collection1, collection2);

            result.Should().BeTrue();
        }

        [Fact]
        public void Int_1_3_3_9_AND_9_3_1_3_ShouldBeTrue()
        {
            IEnumerable<int> collection1 = new int[] { 1, 3, 3, 9 };
            IEnumerable<int> collection2 = new int[] { 9, 3, 1, 3 };

            bool result = this.EnumerableComparer.IsContentTheSame(collection1, collection2);

            result.Should().BeTrue();
        }

        #endregion

        #region False

        [Fact]
        public void Int_1__AND_Empty_ShouldBeFalse()
        {
            IEnumerable<int> collection1 = new int[] { 1 };
            IEnumerable<int> collection2 = Enumerable.Empty<int>();

            bool result = this.EnumerableComparer.IsContentTheSame(collection1, collection2);

            result.Should().BeFalse();
        }

        [Fact]
        public void Int_Empty_AND_5_ShouldBeFalse()
        {
            IEnumerable<int> collection1 = Enumerable.Empty<int>();
            IEnumerable<int> collection2 = new int[] { 5 };

            bool result = this.EnumerableComparer.IsContentTheSame(collection1, collection2);

            result.Should().BeFalse();
        }

        [Fact]
        public void Int_5_1_AND_5_ShouldBeFalse()
        {
            IEnumerable<int> collection1 = new int[] { 5, 1 };
            IEnumerable<int> collection2 = new int[] { 5 };

            bool result = this.EnumerableComparer.IsContentTheSame(collection1, collection2);

            result.Should().BeFalse();
        }

        [Fact]
        public void Int_1_3_4_AND_1_3_ShouldBeFalse()
        {
            IEnumerable<int> collection1 = new int[] { 1, 3, 4 };
            IEnumerable<int> collection2 = new int[] { 1, 3 };

            bool result = this.EnumerableComparer.IsContentTheSame(collection1, collection2);

            result.Should().BeFalse();
        }

        [Fact]
        public void Int_1_3_AND_1_3_4_ShouldBeFalse()
        {
            IEnumerable<int> collection1 = new int[] { 1, 3 };
            IEnumerable<int> collection2 = new int[] { 1, 3, 4 };

            bool result = this.EnumerableComparer.IsContentTheSame(collection1, collection2);

            result.Should().BeFalse();
        }

        [Fact]
        public void Int_1_3_3_AND_1_3_4_ShouldBeFalse()
        {
            IEnumerable<int> collection1 = new int[] { 1, 3, 3 };
            IEnumerable<int> collection2 = new int[] { 1, 3, 4 };

            bool result = this.EnumerableComparer.IsContentTheSame(collection1, collection2);

            result.Should().BeFalse();
        }

        [Fact]
        public void Int_1_3_4_AND_1_3_3_ShouldBeFalse()
        {
            IEnumerable<int> collection1 = new int[] { 1, 3, 4 };
            IEnumerable<int> collection2 = new int[] { 1, 3, 3 };

            bool result = this.EnumerableComparer.IsContentTheSame(collection1, collection2);

            result.Should().BeFalse();
        }

        #endregion

        #endregion

        #region Class

        [Fact]
        public void Int_ObjectSame_ShouldBeTrue()
        {
            IEnumerable<SimpleClass> collection1 = new List<SimpleClass>() { new SimpleClass("John Doe", 9.4d) }; 
            IEnumerable<SimpleClass> collection2 = new List<SimpleClass>() { new SimpleClass("John Doe", 9.4d) };

            bool result = this.EnumerableComparer.IsContentTheSame(collection1, collection2);

            result.Should().BeTrue();
        }

        [Fact]
        public void Int_TwoObjectSame_SameOrder_ShouldBeTrue()
        {
            IEnumerable<SimpleClass> collection1 = new List<SimpleClass>() { new SimpleClass("John Doe", 9.4d), new SimpleClass("JB", 10.23d) };
            IEnumerable<SimpleClass> collection2 = new List<SimpleClass>() { new SimpleClass("John Doe", 9.4d), new SimpleClass("JB", 10.23d) };

            bool result = this.EnumerableComparer.IsContentTheSame(collection1, collection2);

            result.Should().BeTrue();
        }

        [Fact]
        public void Int_TwoObjectSame_DifferentOrder_ShouldBeTrue()
        {
            IEnumerable<SimpleClass> collection1 = new List<SimpleClass>() { new SimpleClass("John Doe", 9.4d), new SimpleClass("JB", 10.23d) };
            IEnumerable<SimpleClass> collection2 = new List<SimpleClass>() { new SimpleClass("JB", 10.23d), new SimpleClass("John Doe", 9.4d) };

            bool result = this.EnumerableComparer.IsContentTheSame(collection1, collection2);

            result.Should().BeTrue();
        }

        #region SimpleClassImplementation

        private class SimpleClass
        {
            public string Name { get; protected set; }
            public double Points { get; protected set; }
            public int SomethingThatDoesNotMatter { get; protected set; }

            public SimpleClass(string name, double points)
            {
                this.Name = name;
                this.Points = points;
                this.SomethingThatDoesNotMatter = 99;
            }

            public override bool Equals(object obj)
            {
                if(obj == null) return false;
                if((obj is SimpleClass) == false) return false;

                SimpleClass instance = obj as SimpleClass;

                return this.Name == instance.Name && this.Points == instance.Points;
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    int hash = 29;

                    hash = hash * 17 + this.Name.GetHashCode();
                    hash = hash * 17 + this.Points.GetHashCode();

                    return hash;
                }
            }
        }

        #endregion

        #endregion
    }
}
