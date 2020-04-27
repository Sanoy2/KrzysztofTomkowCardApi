using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Common.Unit.Tests
{
    public class LanguageTests
    {
        [Fact]
        public void GetHashCode_OtherLanguages_ShouldHaveOtherHashCode()
        {
            Language eng = Language.eng;
            Language pl = Language.pl;

            int engHashCode = eng.GetHashCode();
            int plHashCode = pl.GetHashCode();

            engHashCode.Should().NotBe(plHashCode);
        }

        [Fact]
        public void GetHashCode_SameLanguages_ShouldHaveSameHashCode()
        {
            Language eng1 = Language.eng;
            Language eng2 = Language.eng;

            int eng1HashCode = eng1.GetHashCode();
            int eng2HashCode = eng2.GetHashCode();

            eng1HashCode.Should().Be(eng2HashCode);
        }
    }
}
