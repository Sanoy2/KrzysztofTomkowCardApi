using System;
using Quotations.Models;
using Quotations.Persistence;

namespace Quotations.Factories
{
    public class AuthorFactory : IAuthorFactory
    {
        private readonly IAuthorsRepository authorRepistory;
        public AuthorFactory(IAuthorsRepository authorRepistory)
        {
            this.authorRepistory = authorRepistory ?? throw new ArgumentNullException(nameof(authorRepistory));
        }

        public Author Create(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}