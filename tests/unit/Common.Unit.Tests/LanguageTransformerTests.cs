using Xunit;

using FluentAssertions;

using Common;
using System;

namespace Common.Unit.Tests
{
    public class LanguageTransformerTests
    {
        private readonly ILanguageTransformer transformer;

        public LanguageTransformerTests()
        {
            this.transformer = new LanguageTransformer();
        }

        [Theory]
        [InlineData("pol")]
        [InlineData("pl")]
        [InlineData("polski")]
        [InlineData("POL")]
        [InlineData("PL")]
        [InlineData("POLSKI")]
        [InlineData("Pol")]
        [InlineData("Pl")]
        [InlineData("Polski")]
        [InlineData("PoLsKi")]
        [InlineData("   pol")]
        [InlineData("   pol   ")]
        [InlineData("pol   ")]
        [InlineData("pl-pl")]
        public void IfValidPolishCodeGiven_PlEnumShouldBeReturned(string code)
        {
            Language expectedLanguage = Language.pl;

            Language obtainedLanguage = this.transformer.Transform(code);

            obtainedLanguage.Should().Be(expectedLanguage);
        }

        [Theory]
        [InlineData("eng")]
        [InlineData("en")]
        [InlineData("english")]
        [InlineData("ENG")]
        [InlineData("EN")]
        [InlineData("ENGLISH")]
        [InlineData("Eng")]
        [InlineData("En")]
        [InlineData("English")]
        [InlineData("\neng")]
        [InlineData("\teng   ")]
        [InlineData("eng   \n   ")]
        [InlineData("en-en")]
        [InlineData("en-us")]
        [InlineData("en-uk")]
        public void IfValidEnglishCodeGiven_EngEnumShouldBeReturned(string code)
        {
            Language expectedLanguage = Language.eng;

            Language obtainedLanguage = this.transformer.Transform(code);

            obtainedLanguage.Should().Be(expectedLanguage);
        }

        [Theory]
        [InlineData("")]
        [InlineData("dpa")]
        [InlineData("///")]
        [InlineData("es")]
        [InlineData("fr")]
        [InlineData("it")]
        [InlineData("\n")]
        [InlineData("\t")]
        public void IfUnsupportedCodeGiver_ShouldThrowExceptionWithMessage(string code)
        {
            Action act = () =>
            {
                this.transformer.Transform(code);
            };

            act.Should().ThrowExactly<ValidationException>();
        }
    }
}