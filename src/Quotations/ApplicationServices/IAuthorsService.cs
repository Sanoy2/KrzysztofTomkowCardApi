using Common;

namespace Quotations.ApplicationServices
{
    public interface IAuthorsService
    {
        int Create(string name);

        int AddQuotation(int authorId, string text, string language);
    }
}