using Common;
using Quotations.Models;
using Quotations.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quotations.Persistence.Fakes
{
    public class FakeAuthorsRepository : IAuthorsRepository
    {
        private List<Author> authors;

        public FakeAuthorsRepository()
        {
            authors = new List<Author>();

            var author1 = new Author("Saul Goodman");
            author1.AddQuotation("You better call Saul!", Language.eng);
            author1.AddQuotation("Justice for all", Language.eng);
            author1.AddQuotation("Do you remember a Slipping Jimmy?", Language.eng);

            var author2 = new Author("Heisenberg");
            author2.AddQuotation("I am the one who knocks!", Language.eng);

            var author3 = new Author("Nocny Kochanek");
            author3.AddQuotation("To był koń na białym rycerzu!", Language.pl);

            this.authors.Add(author1);
            this.authors.Add(author2);
            this.authors.Add(author3);
        }

        public IEnumerable<Author> Get()
        {
            return this.authors.ToList();
        }

        public Author Get(string name)
        {
            return this.authors.First(n => n.Name.ToLowerInvariant().Trim() == name.ToLowerInvariant().Trim());
        }

        public Author Get(Guid authorId)
        {
            return this.authors.Single(n => n.Id == authorId);
        }

        public Author Save(Author author)
        {
            if(this.authors.Any(n => n.Equals(author)))
            {
                return author;
            }

            this.authors.Add(author);

            return author;
        }
    }
}
