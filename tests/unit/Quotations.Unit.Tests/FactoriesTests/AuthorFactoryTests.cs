using System;
using Common;
using Common.TextTransformations;
using NSubstitute;
using Quotations.Factories;
using FluentAssertions;
using Xunit;
using Quotations.Models;

namespace Quotations.Unit.Tests.FactoriesTests
{
    public class AuthorFactoryTests
    {
        private readonly ITitleCaseTextTransformer titleCaseTransformer;
        private readonly AuthorFactory factory;
        
        public AuthorFactoryTests()
        {
            this.titleCaseTransformer = new TitleCaseTextTransformer();
            this.factory = new AuthorFactory(this.titleCaseTransformer);
        }

        [Fact]
        public void Ctor_If_TitleCaseTransformerDependency_IsNull_Should_ThrowArgumentNullException()
        {
            Action act = () =>
            {
                IAuthorFactory factory = new AuthorFactory(null);
            };

            act.Should().ThrowExactly<ArgumentNullException>();
        }

        [Fact]
        public void Create_If_NameIsNull_Should_ThrowArgumentNullException()
        {
            string name = null;

            Action act = () =>
            {
                this.factory.Create(name);
            };

            act.Should().ThrowExactly<ValidationException>();
        }

        [Fact]
        public void Create_If_NameIsEmpty_Should_ThrowArgumentNullException()
        {
            string name = string.Empty;

            Action act = () =>
            {
                this.factory.Create(name);
            };

            act.Should().ThrowExactly<ValidationException>();
        }

        [Theory]
        [InlineData(" ")]
        [InlineData("\t")]
        [InlineData(" \n")]
        [InlineData("\n\t")]
        [InlineData("\n\t\n ")]
        [InlineData("          ")]
        public void Create_If_NameIsWhitespace_Should_ThrowArgumentNullException(string whitespace)
        {
            string name = whitespace;

            Action act = () =>
            {
                this.factory.Create(name);
            };

            act.Should().ThrowExactly<ValidationException>();
        }

        [Theory]
        [InlineData("0")]
        [InlineData("1235")]
        [InlineData("\t 124")]
        [InlineData("127 \n\n")]
        [InlineData("158275")]
        [InlineData("158275      ")]
        [InlineData("991282726182")]
        [InlineData("991282 726182")]
        public void Create_If_NameContainsDigitsOnly_Should_ThrowArgumentException(string whitespace)
        {
            string name = whitespace;

            Action act = () =>
            {
                this.factory.Create(name);
            };

            act.Should().ThrowExactly<ValidationException>();
        }

        [Fact]
        public void Create_If_NameContains1Word_Should_NotThrow()
        {
            string name = "Molier";

            Action act = () =>
            {
                this.factory.Create(name);
            };

            act.Should().NotThrow();
        }

        [Fact]
        public void Create_If_NameContains2Words_Should_NotThrow()
        {
            string name = "Unknown Author";

            Action act = () =>
            {
                this.factory.Create(name);
            };

            act.Should().NotThrow();
        }

        [Fact]
        public void Create_If_NameContains7Words_Should_NotThrow()
        {
            string name = "Somebody nobody no one ever said that";

            Action act = () =>
            {
                this.factory.Create(name);
            };

            act.Should().NotThrow();
        }

        [Fact]
        public void Create_If_NameContains1Word_Should_BeSavedInTitleCase()
        {
            string name = "plato";
            string expectedName = "Plato";

            Author author = this.factory.Create(name);

            author.Name.Should().Be(expectedName);
        }

        [Fact]
        public void Create_If_NameContains2Word_Should_BeSavedInTitleCase()
        {
            string name = "mark twain";
            string expectedName = "Mark Twain";

            Author author = this.factory.Create(name);

            author.Name.Should().Be(expectedName);
        }

        [Fact]
        public void Create_If_NameContains2Word_Should_BeSavedInTitleCase_PolishLettersIncluded()
        {
            string name = "jegomość tąpszęłski";
            string expectedName = "Jegomość Tąpszęłski";

            Author author = this.factory.Create(name);

            author.Name.Should().Be(expectedName);
        }

        [Fact]
        public void Create_If_NameContains2WordLastName_Should_BeSavedInTitleCase_BothLastNamesProperlyFormatted()
        {
            string name = "Someone first-last";
            string expectedName = "Someone First-Last";

            Author author = this.factory.Create(name);

            author.Name.Should().Be(expectedName);
        }
    }
}