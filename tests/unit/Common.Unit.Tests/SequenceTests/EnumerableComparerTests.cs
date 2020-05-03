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
        public void Int_Null_Null_ShouldThrowArgumentNullException()
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
        public void Int_Empty_Null_ShouldThrowArgumentNullException()
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
        public void Int_Null_Empty_ShouldThrowArgumentNullException()
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
        public void Int_Empty_Empty_ShouldBeTrue()
        {
            IEnumerable<int> collection1 = Enumerable.Empty<int>();
            IEnumerable<int>  collection2 = Enumerable.Empty<int>();

            bool result = this.EnumerableComparer.IsContentTheSame(collection1, collection2);

            result.Should().BeTrue();
        }

        #endregion

        #region False

        [Fact]
        public void Int_1_Empty_ShouldBeFalse()
        {
            IEnumerable<int> collection1 = new int[] { 1 };
            IEnumerable<int> collection2 = Enumerable.Empty<int>();

            bool result = this.EnumerableComparer.IsContentTheSame(collection1, collection2);

            result.Should().BeFalse();
        }

        [Fact]
        public void Int_Empty_5_ShouldBeFalse()
        {
            IEnumerable<int> collection1 = Enumerable.Empty<int>();
            IEnumerable<int> collection2 = new int[] { 5 };

            bool result = this.EnumerableComparer.IsContentTheSame(collection1, collection2);

            result.Should().BeFalse();
        }

        #endregion

        #endregion

        #region Class



        #endregion
    }
}
