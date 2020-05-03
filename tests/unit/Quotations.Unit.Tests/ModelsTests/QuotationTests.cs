using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

using FluentAssertions;
using Quotations.Models;
using Common;

namespace Quotations.Unit.Tests.ModelsTests
{
    public class QuotationTests
    {
        private readonly Guid authorId;
        private readonly string content;
        private Language language;

        private readonly Quotation quotation;

        public QuotationTests()
        {
            this.authorId = Guid.NewGuid();
            this.content = "To be or not to be?";
            this.language = Language.eng;

            this.quotation = new Quotation(this.authorId, this.content, this.language);
        }

        [Fact]
        public void Equals_EverythingEqual_ShouldBeTrue()
        {
            Quotation otherQuotation = new Quotation(this.authorId, this.content, this.language);
            bool areEqual;

            areEqual = this.quotation.Equals(otherQuotation);

            areEqual.Should().BeTrue();
        }

        [Fact]
        public void Equals_OtherContent_ShouldBeFalse()
        {
            Quotation otherQuotation = new Quotation(this.authorId, "Veni, vidi, vici.", this.language);
            bool areEqual;

            areEqual = this.quotation.Equals(otherQuotation);

            areEqual.Should().BeFalse();
        }

        [Fact]
        public void Equals_OtherLanguage_ShouldBeFalse()
        {
            Quotation otherQuotation = new Quotation(this.authorId, this.content, Language.pl);
            bool areEqual;

            areEqual = this.quotation.Equals(otherQuotation);

            areEqual.Should().BeFalse();
        }

        [Fact]
        public void GetHashCode_ShouldAlwaysProduceTheSameResult()
        {
            int hashCode1 = this.quotation.GetHashCode();
            int hashCode2 = this.quotation.GetHashCode();
            int hashCode3 = this.quotation.GetHashCode();

            hashCode1.Should().Be(hashCode2).And.Be(hashCode3);
        }

        [Fact]
        public void GetHashCode_ObjectWithTheSameFieldValues_ShouldHaveTheSameHashCode()
        {
            Quotation otherQuotation = new Quotation(this.authorId, this.content, this.language);

            int quotationHashCode = this.quotation.GetHashCode();
            int otherObjectHashCode;

            otherObjectHashCode = otherQuotation.GetHashCode();

            quotationHashCode.Should().Be(otherObjectHashCode);
        }
    }
}