using Common;
using FluentAssertions;
using Quotations.Models;
using Quotations.Models.Domain;
using Xunit;

namespace Quotations.Unit.Tests.ModelsTests
{
    public class AuthorTests
    {
        private readonly string name;

        private readonly Author author;

        public AuthorTests()
        {
            this.name = "John Doe";

            this.author = new Author(name);
        }

        [Fact]
        public void Equals_NameEqualAndNoQuotations_ShouldBeTrue()
        {
            Author otherAuthor = new Author(this.name);
            bool areEqual;

            areEqual = this.author.Equals(otherAuthor);

            areEqual.Should().BeTrue();
        }

        [Fact]
        public void Equals_NameOtherAndNoQuotations_ShouldBeFalse()
        {
            Author otherAuthor = new Author("Mr X");
            bool areEqual;

            areEqual = this.author.Equals(otherAuthor);

            areEqual.Should().BeFalse();
        }

        [Fact]
        public void Equals_NameEqualAndTheSameOneQuotation_ShouldBeTrue()
        {
            string content = "Some content. Why not?";
            Language language = Language.eng;

            Author otherAuthor = new Author(this.name);

            this.author.AddQuotation(content, language);
            otherAuthor.AddQuotation(content, language);

            bool areEqual;

            areEqual = this.author.Equals(otherAuthor);

            areEqual.Should().BeTrue();
        }

        [Fact]
        public void Equals_NameEqualAndCalledOneHasOneQuotation_ShouldBeFalse()
        {
            string content = "Some content. Why not?";
            Language language = Language.eng;

            Author otherAuthor = new Author(this.name);

            this.author.AddQuotation(content, language);

            bool areEqual;

            areEqual = this.author.Equals(otherAuthor);

            areEqual.Should().BeFalse();
        }

        [Fact]
        public void Equals_NameEqualAndcomparedOneHasOneQuotation_ShouldBeFalse()
        {
            string content = "Some content. Why not?";
            Language language = Language.eng;

            Author otherAuthor = new Author(this.name);

            otherAuthor.AddQuotation(content, language);

            bool areEqual;

            areEqual = this.author.Equals(otherAuthor);

            areEqual.Should().BeFalse();
        }

        [Fact]
        public void Equals_NameEqualAndBothHasTwoQuotationsSameAddOrder_ShouldBeTrue()
        {
            string content1 = "Some content. Why not?";
            Language language1 = Language.eng;

            string content2 = "Trochê treœci. Czemu nie?";
            Language language2 = Language.pl;

            Author otherAuthor = new Author(this.name);

            this.author.AddQuotation(content1, language1);
            otherAuthor.AddQuotation(content1, language1);

            this.author.AddQuotation(content2, language2);
            otherAuthor.AddQuotation(content2, language2);

            bool areEqual;

            areEqual = this.author.Equals(otherAuthor);

            areEqual.Should().BeTrue();
        }

        [Fact]
        public void Equals_NameEqualAndBothHasTwoQuotationsDifferentAddOrder_ShouldBeTrue()
        {
            string content1 = "Some content. Why not?";
            Language language1 = Language.eng;

            string content2 = "Trochê treœci. Czemu nie?";
            Language language2 = Language.pl;

            Author otherAuthor = new Author(this.name);

            this.author.AddQuotation(content1, language1);
            otherAuthor.AddQuotation(content1, language1);

            otherAuthor.AddQuotation(content2, language2);
            this.author.AddQuotation(content2, language2);

            bool areEqual;

            areEqual = this.author.Equals(otherAuthor);

            areEqual.Should().BeTrue();
        }

        [Fact]
        public void Equals_NameEqualAndBothHaveOtherQuotations_ShouldBeFalse()
        {
            string content1 = "Some content. Why not?";
            Language language1 = Language.eng;

            string content2 = "Trochê treœci. Czemu nie?";
            Language language2 = Language.pl;

            Author otherAuthor = new Author(this.name);

            this.author.AddQuotation(content1, language1);
            otherAuthor.AddQuotation(content2, language2);

            bool areEqual;

            areEqual = this.author.Equals(otherAuthor);

            areEqual.Should().BeFalse();
        }

        [Fact]
        public void Equals_NameEqualAndBothHaveTwoOtherQuotations_ShouldBeFalse()
        {
            string content1 = "Some content. Why not?";
            Language language1 = Language.eng;
            string content2 = "Trochê treœci. Czemu nie?";
            Language language2 = Language.pl;
            string content3 = "To be or not to be?";
            Language language3 = Language.eng;
            string content4 = "I am the one who knocks!";
            Language language4 = Language.eng;

            Author otherAuthor = new Author(this.name);

            this.author.AddQuotation(content1, language1);
            this.author.AddQuotation(content2, language2);

            otherAuthor.AddQuotation(content3, language3);
            otherAuthor.AddQuotation(content4, language4);

            bool areEqual;

            areEqual = this.author.Equals(otherAuthor);

            areEqual.Should().BeFalse();
        }

        [Fact]
        public void Equals_NameEqualAndOneQuotationMissing_ShouldBeFalse()
        {
            string content1 = "Some content. Why not?";
            Language language1 = Language.eng;

            string content2 = "Trochê treœci. Czemu nie?";
            Language language2 = Language.pl;

            Author otherAuthor = new Author(this.name);

            this.author.AddQuotation(content1, language1);
            otherAuthor.AddQuotation(content1, language1);
            otherAuthor.AddQuotation(content2, language2);

            bool areEqual;

            areEqual = this.author.Equals(otherAuthor);

            areEqual.Should().BeFalse();
        }


        [Fact]
        public void GetHashCode_NoQuotation_ShouldAlwaysProduceTheSameResult()
        {
            int hashCode1 = this.author.GetHashCode();
            int hashCode2 = this.author.GetHashCode();
            int hashCode3 = this.author.GetHashCode();

            hashCode1.Should().Be(hashCode2).And.Be(hashCode3);
        }

        [Fact]
        public void GetHashCode_1Qutation_ShouldAlwaysProduceTheSameResult()
        {
            this.author.AddQuotation("To be or not to be?", Language.eng);

            int hashCode1 = this.author.GetHashCode();
            int hashCode2 = this.author.GetHashCode();
            int hashCode3 = this.author.GetHashCode();

            hashCode1.Should().Be(hashCode2).And.Be(hashCode3);
        }

        [Fact]
        public void GetHashCode_NoQuptation_ObjectWithTheSameFieldValues_ShouldHaveTheSameHashCode()
        {
            Author otherAuthor = new Author(this.name);

            int quotationHashCode = this.author.GetHashCode();
            int otherObjectHashCode;

            otherObjectHashCode = otherAuthor.GetHashCode();

            quotationHashCode.Should().Be(otherObjectHashCode);
        }

        [Fact]
        public void GetHashCode_1Quotation_ObjectWithTheSameFieldValues_ShouldHaveTheSameHashCode()
        {
            string quotation = "To be or not to be?";
            Language language = Language.eng;

            Author otherAuthor = new Author(this.name);

            this.author.AddQuotation(quotation, language);
            otherAuthor.AddQuotation(quotation, language);

            int quotationHashCode = this.author.GetHashCode();
            int otherObjectHashCode;

            otherObjectHashCode = otherAuthor.GetHashCode();

            quotationHashCode.Should().Be(otherObjectHashCode);
        }

        [Fact]
        public void GetHashCode_1Quotation_ObjectDifferentQuotation_ShouldHaveDifferentHashCode()
        {
            string quotation1 = "To be or not to be?";
            string quotation2 = "Better call Saul!";
            Language language = Language.eng;

            Author otherAuthor = new Author(this.name);

            this.author.AddQuotation(quotation1, language);
            otherAuthor.AddQuotation(quotation2, language);

            int quotationHashCode = this.author.GetHashCode();
            int otherObjectHashCode;

            otherObjectHashCode = otherAuthor.GetHashCode();

            quotationHashCode.Should().NotBe(otherObjectHashCode);
        }

        [Fact]
        public void GetHashCode_2Quotation_SameOrder_ObjectWithTheSameFieldValues_ShouldHaveTheSameHashCode()
        {
            string quotation1 = "To be or not to be?";
            string quotation2 = "Better call Saul!";
            Language language = Language.eng;

            Author otherAuthor = new Author(this.name);

            this.author.AddQuotation(quotation1, language);
            otherAuthor.AddQuotation(quotation1, language);

            this.author.AddQuotation(quotation2, language);
            otherAuthor.AddQuotation(quotation2, language);

            int quotationHashCode = this.author.GetHashCode();
            int otherObjectHashCode;

            otherObjectHashCode = otherAuthor.GetHashCode();

            quotationHashCode.Should().Be(otherObjectHashCode);
        }

        [Fact]
        public void GetHashCode_2Quotation_DifferentOrder_ObjectWithTheSameFieldValues_ShouldHaveTheSameHashCode()
        {
            string quotation1 = "To be or not to be?";
            string quotation2 = "Better call Saul!";
            Language language = Language.eng;

            Author otherAuthor = new Author(this.name);

            this.author.AddQuotation(quotation1, language);
            otherAuthor.AddQuotation(quotation2, language);

            this.author.AddQuotation(quotation2, language);
            otherAuthor.AddQuotation(quotation1, language);

            int quotationHashCode = this.author.GetHashCode();
            int otherObjectHashCode;

            otherObjectHashCode = otherAuthor.GetHashCode();

            quotationHashCode.Should().Be(otherObjectHashCode);
        }

        [Fact]
        public void GetHashCode_OtherQuotationNumber_ObjectWithTheSameFieldValues_ShouldHaveDifferentHashCode()
        {
            string quotation1 = "To be or not to be?";
            string quotation2 = "Better call Saul!";
            Language language = Language.eng;

            Author otherAuthor = new Author(this.name);

            this.author.AddQuotation(quotation1, language);
            otherAuthor.AddQuotation(quotation1, language);

            this.author.AddQuotation(quotation2, language);

            int quotationHashCode = this.author.GetHashCode();
            int otherObjectHashCode;

            otherObjectHashCode = otherAuthor.GetHashCode();

            quotationHashCode.Should().NotBe(otherObjectHashCode);
        }
    }
}