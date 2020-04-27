using System.Linq;
using Quotations.Models;

namespace Quotations.ApplicationServices
{
    public interface IQuotationsService
    {
        IQueryable<Quotation> GetRandom(string language);
    }
}