using System;
using System.Linq;
using Common;
using Quotations.Factories;
using Quotations.Models;
using Quotations.Persistence;

namespace Quotations.ApplicationServices
{
    public class AuthorsService : IAuthorsService
    {
        private readonly IAuthorsRepository authorsRepository;
        private readonly IAuthorFactory authorFactory;
        private readonly ILanguageTransformer languageTransformer;

        public AuthorsService(IAuthorsRepository authorsRepository, IAuthorFactory authorFactory, ILanguageTransformer languageTransformer)
        {
            this.authorsRepository = authorsRepository ?? throw new ArgumentNullException(nameof(authorsRepository));
            this.authorFactory = authorFactory ?? throw new ArgumentNullException(nameof(authorFactory));
            this.languageTransformer = languageTransformer ?? throw new ArgumentNullException(nameof(languageTransformer));
        }
        public Guid AddQuotation(Guid authorId, string text, string languageCode)
        {
            Author author = this.authorsRepository.Get(authorId) ?? throw new ArgumentException("Not found author of given Id", nameof(authorId));

            Language language = this.languageTransformer.Transform(languageCode);

            // Quotation quotation = author.AddQuotation(text, language);

            // return quotation.Id;

            throw new NotImplementedException();
        }

        public int Create(string name)
        {
            Author newAuthor = this.authorFactory.Create(name);

            throw new NotImplementedException();
        }
    }
}