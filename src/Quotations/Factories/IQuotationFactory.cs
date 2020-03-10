using Common;
using Quotations.Models;

namespace Quotations.Factories
{
    // should have authors repository injected??
    // maybe I should have static id that is incremented each time I assign new id ??

    public interface IQuotationFactory
    {
        Quotation Create(long authorId, string content, Language language, long id);
    }
}