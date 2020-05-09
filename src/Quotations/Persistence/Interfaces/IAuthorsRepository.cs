using System;
using System.Collections.Generic;
using System.Linq;
using Quotations.Models;
using Quotations.Models.Domain;

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