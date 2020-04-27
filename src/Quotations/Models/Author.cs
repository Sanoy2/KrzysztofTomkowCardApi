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

        protected Author() { }

        public Author(string name)
        {
            this.Name = name;
        }

        public Quotation AddQuotation(string content, Language language)
        {
            Quotation quotation = new Quotation(this.Id, content, language);

            if(this.quotations.Contains(quotation))
            {
                return this.quotations.First(n => n.Equals(quotation));
            }

            this.quotations.Add(quotation);

            return quotation;
        }

        public override int GetHashCode()
        {
            throw new System.NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            throw new System.NotImplementedException();
        }
    }
}