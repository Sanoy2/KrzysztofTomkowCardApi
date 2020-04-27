using System;
using System.Linq;
using Quotations.Models;

namespace Quotations.Persistence
{
    public interface IAuthorsRepository
    {
        IQueryable<Author> Get();

        Author Get(string name);

        Author Get(Guid authorId);

        Author Save(Author author);
    }
}