using System.Collections.Generic;
using System.Linq;

using Common;

namespace Quotations.Models
{
    public class Author : Entity
    {
        private List<Quotation> quotations = new List<Quotation>();
        public IEnumerable<Quotation> Quotations { get => this.quotations.ToList(); }
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
            bool typeMatch = base.EqualsType<Author>(obj);

            if (typeMatch == false)
            {
                return false;
            }

            Author author = obj as Author;

            if(this.Name != author.Name)
            {
                return false;
            }

            if(!this.Quotations.Any() && !author.Quotations.Any())
            {
                return true;
            }

            if( this.Quotations.Count() != author.Quotations.Count())
            {
                return false;
            }

            var thisOrdered = this.Quotations.OrderBy(n => n.Content).ThenBy(n => n.AuthorId).ToList();
            var otherOrdered = author.Quotations.OrderBy(n => n.Content).ThenBy(n => n.AuthorId).ToList();
            int i = 0;

            foreach (var thisItem in thisOrdered)
            {
                thisItem.Equals(otherOrdered[i]);
                i++;
            }

            return this.Quotations.First().Equals(author.Quotations.First());
        }
    }
}