using System.Collections.Generic;
using System.Linq;

using Common;

namespace Quotations.Models
{
    public class Author : Entity
    {
        private List<Quotation> quotations = new List<Quotation>();
        public IEnumerable<Quotation> Quotations { get; }
        public string Name { get; }

        public Author(string name, long id) : base(id)
        {
            this.Name = name;
        }

        public Quotation AddQuotation(Quotation quotation)
        {
            this.quotations.Add(quotation);

            return quotation;
        }
    }
}