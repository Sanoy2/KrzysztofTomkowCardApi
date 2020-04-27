using Common;
using Quotations.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quotations.DomainServices
{
    public interface IQuotationDomainService
    {
        Quotation Create(Author author, string text, string languageCode);
    }
}
