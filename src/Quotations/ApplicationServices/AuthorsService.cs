using System;
using System.Linq;
using Common;
using Quotations.Models;
using Quotations.Persistence;

namespace Quotations.ApplicationServices
{
    public class AuthorsService : IAuthorsService
    {
        private readonly IAuthorsRepository authorsRepository;
        private readonly ILanguageTransformer languageTransformer;

        public AuthorsService(IAuthorsRepository authorsRepository, ILanguageTransformer languageTransformer)
        {
            this.authorsRepository = authorsRepository ?? throw new ArgumentNullException(nameof(authorsRepository));
            this.languageTransformer = languageTransformer ?? throw new ArgumentNullException(nameof(languageTransformer));
        }
        public int AddQuotation(int authorId, string text, string languageCode)
        {
            Author author = this.authorsRepository.Get(authorId) ?? throw new ArgumentException("Not found author of given Id", nameof(authorId));

            Language language = this.languageTransformer.Transform(languageCode);

            // Quotation quotation = author.AddQuotation(text, language);

            // return quotation.Id;

            throw new NotImplementedException();
        }

        public int Create(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (this.authorsRepository.Get().Where(n => n.Name == name).Any())
            {
                throw new ArgumentException("Author of given name already exists", nameof(name));
            }

            // Author newAuthor = new Author(name);

            // this.authorsRepository.Save(newAuthor);

            // return newAuthor.Id;

            throw new NotImplementedException();

        }
    }
}