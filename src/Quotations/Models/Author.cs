using System.Collections.Generic;
using Common;

namespace Quotations.Models
{
    public class Author
    {
        public int Id { get; }
        private List<Quotation> quotations = new List<Quotation>();
        public IEnumerable<Quotation> Quotations { get; }
        public string Name { get; }

        public Quotation AddQuotation(string content, Language language)
        {
            var quotation = new Quotation(this, content, language);
            this.quotations.Add(quotation);

            return quotation;
        }
    }
}