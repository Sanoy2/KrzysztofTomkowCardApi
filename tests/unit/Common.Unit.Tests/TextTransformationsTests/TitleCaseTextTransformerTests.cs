using Xunit;

using FluentAssertions;

using Common.TextTransformations;
using System;

namespace Common.Unit.Tests.TextTransformationsTests
{
    public class TitleCaseTextTransformerTests
    {
        private readonly ITitleCaseTextTransformer transformer;

        public TitleCaseTextTransformerTests()
        {
            this.transformer = new TitleCaseTextTransformer();
        }

        [Fact]
        public void When_Null_Then_ThrowArgumentNullException()
        {
            string text = null;

            Action act = () =>
            {
                this.transformer.Transform(text);
            };

            act.Should().ThrowExactly<ArgumentNullException>();
        }

        [Fact]
        public void When_EmptyString_Then_DoNotThrowArgumentNullException()
        {
            string text = string.Empty;

            Action act = () =>
            {
                this.transformer.Transform(text);
            };

            act.Should().NotThrow<ArgumentNullException>();
        }

        [Fact]
        public void When_StringIsNotEmpty_Then_DoNotThrowNotImplementedException()
        {
            string text = "fancy text";

            Action act = () =>
            {
                this.transformer.Transform(text);
            };

            act.Should().NotThrow<NotImplementedException>();
        }

        [Fact]
        public void When_EmptyString_Then_EmptyString()
        {
            string text = string.Empty;
            string expectedText = string.Empty;

            string transformedWord = this.transformer.Transform(text);

            transformedWord.Should().Be(expectedText);
        }

        [Fact]
        public void When_A_Then_A()
        {
            string text = "A";
            string expectedText = "A";

            string transformedWord = this.transformer.Transform(text);

            transformedWord.Should().Be(expectedText);
        }

        [Fact]
        public void When_a_Then_A()
        {
            string text = "a";
            string expectedText = "A";

            string transformedWord = this.transformer.Transform(text);

            transformedWord.Should().Be(expectedText);
        }

        [Fact]
        public void When_aa_Then_Aa()
        {
            string text = "aa";
            string expectedText = "Aa";

            string transformedWord = this.transformer.Transform(text);

            transformedWord.Should().Be(expectedText);
        }

        [Fact]
        public void When_aaA_Then_Aaa()
        {
            string text = "aaA";
            string expectedText = "Aaa";

            string transformedWord = this.transformer.Transform(text);

            transformedWord.Should().Be(expectedText);
        }

        [Fact]
        public void When_aaA_a_Then_Aaa_A()
        {
            string text = "aaA a";
            string expectedText = "Aaa A";

            string transformedWord = this.transformer.Transform(text);

            transformedWord.Should().Be(expectedText);
        }

        [Fact]
        public void When_a_a_Then_A_A()
        {
            string text = "a a";
            string expectedText = "A A";

            string transformedWord = this.transformer.Transform(text);

            transformedWord.Should().Be(expectedText);
        }

        [Fact]
        public void When_aaA_aa_Then_Aaa_Aa()
        {
            string text = "aaA aa";
            string expectedText = "Aaa Aa";

            string transformedWord = this.transformer.Transform(text);

            transformedWord.Should().Be(expectedText);
        }

        [Fact]
        public void When_aaA___aa_Then_Aaa_Aa()
        {
            string text = "aaA   aa";
            string expectedText = "Aaa Aa";

            string transformedWord = this.transformer.Transform(text);

            transformedWord.Should().Be(expectedText);
        }

        [Fact]
        public void When_WhitespaceOnLeft_Then_NoWhitespaceOnLeft()
        {
            string text = "   aaa";
            string expectedText = "Aaa";

            string transformedWord = this.transformer.Transform(text);

            transformedWord.Should().Be(expectedText);
        }

        [Fact]
        public void When_WhitespaceOnRight_Then_NoWhitespaceOnRight()
        {
            string text = "aaa   ";
            string expectedText = "Aaa";

            string transformedWord = this.transformer.Transform(text);

            transformedWord.Should().Be(expectedText);
        }

        [Fact]
        public void When_WhitespaceOnBothSides_Then_Trimmed()
        {
            string text = "   aaa   ";
            string expectedText = "Aaa";

            string transformedWord = this.transformer.Transform(text);

            transformedWord.Should().Be(expectedText);
        }

        [Fact]
        public void When_PolishLetter_Then_ShouldWork()
        {
            string text = "ą ę ś ć";
            string expectedText = "Ą Ę Ś Ć";

            string transformedWord = this.transformer.Transform(text);

            transformedWord.Should().Be(expectedText);
        }

        [Theory]
        [InlineData("Mike $word", "Mike $word")]
        [InlineData("Ants!", "Ants!")]
        [InlineData("Sid meier's", "Sid Meier's")]
        [InlineData("$?&!", "$?&!")]
        public void When_SpecialCharacterInText_Then_NotRemoved(string text, string expectedText)
        {
            string transformedWord = this.transformer.Transform(text);

            transformedWord.Should().Be(expectedText);
        }
    }
}