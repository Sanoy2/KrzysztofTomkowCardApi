using Quotations.Models;

namespace Quotations.Factories
{
    // should have repository injected??
    // maybe I should have static id that is incremented each time I assign new id ??
    public interface IAuthorFactory
    {
        Author Create(string name);
    }
}