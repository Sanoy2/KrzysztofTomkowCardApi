using Common;
using FluentAssertions;
using Quotations.Models;
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
    }
}