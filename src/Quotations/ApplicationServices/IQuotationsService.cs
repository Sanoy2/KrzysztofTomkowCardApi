using System.Linq;
using Quotations.Models;
using Quotations.Models.Dto;

namespace Quotations.ApplicationServices
{
    public interface IQuotationsService
    {
        QuotationDto GetRandom(string language);
    }
}