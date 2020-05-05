using Common.Sequence.Implementations;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Common.Unit.Tests.SequenceTests
{
    public class RandomElementPickerTests
    {
        private readonly RandomElementPicker picker;

        public RandomElementPickerTests()
        {
            this.picker = new RandomElementPicker();
        }

        #region Without Func

        [Fact]
        public void IntCollectionEmpty_Should_Return0()
        {
            int expectedResult = 0;
            IEnumerable<int> collection = new List<int>();

            int result = this.picker.PickRandom(collection);

            result.Should().Be(expectedResult);
        }

        [Fact]
        public void StringCollectionEmpty_Should_ReturnEmptyString()
        {
            string expectedResult = string.Empty;
            IEnumerable<string> collection = new List<string>();

            string result = this.picker.PickRandom(collection);

            result.Should().Be(expectedResult);
        }

        [Fact]
        public void SimpleClassCollectionEmpty_Should_ReturnNull()
        {
            IEnumerable<SimpleClass> collection = new List<SimpleClass>();

            SimpleClass result = this.picker.PickRandom(collection);

            result.Should().BeNull();
        }

        [Fact]
        public void IntCollection_5_Should_Return5()
        {
            int expectedResult = 5;
            List<int> collection = new List<int>();
            collection.Add(5);

            int result = this.picker.PickRandom(collection);

            result.Should().Be(expectedResult);
        }

        [Fact]
        public void IntCollection_5_12_9283_Should_Return_5_or_12_or_9283()
        {
            int expectedResult1 = 5;
            int expectedResult2 = 12;
            int expectedResult3 = 9283;

            List<int> collection = new List<int>();
            collection.Add(5);
            collection.Add(12);
            collection.Add(9283);

            int result = this.picker.PickRandom(collection);

            result.Should().BeOneOf(expectedResult1, expectedResult2, expectedResult3);
        }

        [Fact]
        public void IntCollection_5_12_9283_Repeats_100_Should_ReturnEach_AtLeastOnce()
        {
            int expectedResult1 = 5;
            int expectedResult2 = 12;
            int expectedResult3 = 9283;

            List<int> collection = new List<int>();
            collection.Add(5);
            collection.Add(12);
            collection.Add(9283);

            bool returnedResult1 = false;
            bool returnedResult2 = false;
            bool returnedResult3 = false;

            for (int i = 0; i < 100; i++)
            {
                int pickedValue = this.picker.PickRandom(collection);
                if (pickedValue == expectedResult1) returnedResult1 = true;
                if (pickedValue == expectedResult2) returnedResult2 = true;
                if (pickedValue == expectedResult3) returnedResult3 = true;
            }

            returnedResult1.Should().BeTrue();
            returnedResult2.Should().BeTrue();
            returnedResult3.Should().BeTrue();
        }

        #endregion

        #region Func
        #endregion

        #region Simple class

        private class SimpleClass
        {
            public string Name { get; }
            public int Rating { get; }

            public SimpleClass(string name, int rating)
            {
                this.Name = name;
                this.Rating = rating;
            }

            public override bool Equals(object obj)
            {
                SimpleClass instance = obj as SimpleClass;

                return this.Name == instance.Name && this.Rating == instance.Rating;
            }
        }

        #endregion
    }
}
