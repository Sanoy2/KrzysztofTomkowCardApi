using System;
using Common;

namespace Quotations.ApplicationServices
{
    public interface IAuthorsService
    {
        int Create(string name);

        Guid AddQuotation(Guid authorId, string text, string languageCode);
    }
}