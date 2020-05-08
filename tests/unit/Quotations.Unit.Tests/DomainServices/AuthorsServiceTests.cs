using FluentAssertions;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Quotations.ApplicationServices;
using Quotations.DomainServices;
using Quotations.Exceptions;
using Quotations.Factories;
using Quotations.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Quotations.Unit.Tests.DomainServices
{
    public class AuthorsServiceTests
    {
        private readonly Guid authorId;
        private readonly string text;
        private readonly string languageCode;

        private readonly AuthorsService authorsService;
        private readonly IAuthorsRepository authorsRepository;
        private readonly IAuthorFactory authorFactory;
        private readonly IQuotationDomainService quotationsDomainService;

        public AuthorsServiceTests()
        {
            this.authorId = Guid.Parse("0f8fad5b-d9cb-469f-a165-70867728950e");
            this.text = "Content";
            this.languageCode = "en";

            this.authorsRepository = Substitute.For<IAuthorsRepository>();
            this.authorFactory = Substitute.For<IAuthorFactory>();
            this.quotationsDomainService = Substitute.For<IQuotationDomainService>();
            this.authorsService = new AuthorsService(
                this.authorsRepository,
                this.authorFactory,
                this.quotationsDomainService);
        }

        [Fact]
        public void AddQuotation_IfAuthorNotFound_ShouldThrowAuthorNotFoundException()
        {
            this.authorsRepository.Get(Arg.Any<Guid>()).ReturnsNull();

            Action act = () =>
            {
                this.authorsService.AddQuotation(this.authorId, this.text, this.languageCode); 
            };

            act.Should().ThrowExactly<AuthorNotFoundException>();
        }

        //[Fact]
        //public void AddQuotation_IfDataValid_ShouldCallDomainServiceCreate()
        //{
        //    Author author = new Author("John Doe");
        //    this.authorsRepository.Get(this.authorId).Returns(author);
        //    Quotation quotation = new Quotation(this.authorId, this.text, Common.Language.eng);
        //    this.quotationsDomainService.Create(author, this.text, this.languageCode).Returns(quotation);

        //    this.authorsService.AddQuotation(this.authorId, this.text, this.languageCode);

        //    this.quotationsDomainService.Received().Create(author, this.text, this.languageCode);
        //}

        //[Fact]
        //public void AddQuotation_IfDataValid_ShouldCalRepositorySave()
        //{
        //    Author author = new Author("John Doe");
        //    this.authorsRepository.Get(this.authorId).Returns(author);
        //    Quotation quotation = new Quotation(this.authorId, this.text, Common.Language.eng);
        //    this.quotationsDomainService.Create(author, this.text, this.languageCode).Returns(quotation);

        //    this.authorsService.AddQuotation(this.authorId, this.text, this.languageCode);

        //    this.authorsRepository.Received().Save(author);
        //}
    }
}
