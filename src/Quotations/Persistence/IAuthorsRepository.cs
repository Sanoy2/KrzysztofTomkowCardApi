using System.Linq;
using Quotations.Models;

namespace Quotations.Persistence
{
    public interface IAuthorsRepository
    {
        Author Save(Author author);

        IQueryable<Author> Get();

        Author Get(int authorId);
    }
}