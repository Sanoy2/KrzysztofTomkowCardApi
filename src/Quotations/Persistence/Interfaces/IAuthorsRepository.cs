using System;
using System.Collections.Generic;
using System.Linq;
using Quotations.Models;

namespace Quotations.Persistence.Interfaces
{
    public interface IAuthorsRepository
    {
        IEnumerable<Author> Get();

        Author Get(string name);

        Author Get(Guid authorId);

        Author Save(Author author);
    }
}