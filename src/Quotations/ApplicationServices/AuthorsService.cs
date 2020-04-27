using System;
using System.Linq;
using Common;
using Quotations.DomainServices;
using Quotations.Factories;
using Quotations.Models;
using Quotations.Persistence;

namespace Quotations.ApplicationServices
{
    public class AuthorsService : IAuthorsService
    {
        private readonly IAuthorsRepository authorsRepository;
        private readonly IAuthorFactory authorFactory;
        private readonly IQuotationDomainService quotationDomainService;

        public AuthorsService(
            IAuthorsRepository authorsRepository, 
            IAuthorFactory authorFactory,
            IQuotationDomainService quotationDomainService)
        {
            this.authorsRepository = authorsRepository ?? throw new ArgumentNullException(nameof(authorsRepository));
            this.authorFactory = authorFactory ?? throw new ArgumentNullException(nameof(authorFactory));
            this.quotationDomainService = quotationDomainService ?? throw new ArgumentNullException(nameof(quotationDomainService));
        }
        public Guid AddQuotation(Guid authorId, string text, string languageCode)
        {
            Author author = this.authorsRepository.Get(authorId) ?? throw new ArgumentNullException("Not found author of given Id: ", nameof(authorId));

            Quotation quotation = this.quotationDomainService.Create(author, text, languageCode);

            this.authorsRepository.Save(author);

            return quotation.Id;
        }

        public Guid Create(string name)
        {
            Author newAuthor = this.authorFactory.Create(name);

            if (this.authorsRepository.Get(newAuthor.Name) != null)
            {
                throw new ValidationException($"Author with name {newAuthor.Name} already exists", nameof(name));
            }

            this.authorsRepository.Save(newAuthor);

            return newAuthor.Id;
        }
    }
}