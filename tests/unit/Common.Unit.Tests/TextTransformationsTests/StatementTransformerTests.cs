using System;
using Common.TextTransformations;
using FluentAssertions;
using Xunit;

namespace Common.Unit.Tests.TextTransformationsTests
{
    public class StatementTransformerTests
    {
        private readonly IStatementTransformer transformer;

        public StatementTransformerTests()
        {
            this.transformer = new StatementTransformer();
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
        public void When_A_Then_Adot()
        {
            string text = "A";
            string expectedText = "A.";

            string transformedWord = this.transformer.Transform(text);

            transformedWord.Should().Be(expectedText);
        }

        [Fact]
        public void When_Adot_Then_Adot()
        {
            string text = "A.";
            string expectedText = "A.";

            string transformedWord = this.transformer.Transform(text);

            transformedWord.Should().Be(expectedText);
        }

        [Fact]
        public void When_AaAadot_Then_Aaaadot()
        {
            string text = "AaAa.";
            string expectedText = "Aaaa.";

            string transformedWord = this.transformer.Transform(text);

            transformedWord.Should().Be(expectedText);
        }

        [Theory]
        [InlineData("", "")]
        [InlineData(" ", "")]
        [InlineData("sHakE that!", "Shake that!")]
        [InlineData("to be or not to be", "To be or not to be.")]
        [InlineData("to be or not to be?", "To be or not to be?")]
        // [InlineData("THAT WAS 6.7 POINTS", "That was 6.7 points.")]

        public void TransformedAndExpected_Should_BeEqual_OneStatement(string text, string expectedText)
        {
            string transformedWord = this.transformer.Transform(text);

            transformedWord.Should().Be(expectedText);
        }

        // [Fact]
        // public void WhenTwoStatement_Then_EachTransformedAsSeparateStatement()
        // {
        //     string text = "hey you! what you want from me?";
        //     string expectedText = "Hey you! What you want from me?";

        //     string transformedWord = this.transformer.Transform(text);

        //     transformedWord.Should().Be(expectedText);
        // }

        // [Theory]
        // [InlineData("how are you? I'm OK", "How are you? I'm OK.")]

        // public void TransformedAndExpected_Should_BeEqual_TwoStatements(string text, string expectedText)
        // {
        //     string transformedWord = this.transformer.Transform(text);

        //     transformedWord.Should().Be(expectedText);
        // }
    }
}