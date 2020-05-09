using System;
using System.Collections.Generic;
using System.Linq;

using Common;
using Common.Sequence.Extensions;

namespace Quotations.Models.Domain
{
    public class Author : Entity
    {
        private List<Quotation> quotations = new List<Quotation>();
        public IEnumerable<Quotation> Quotations { get => this.quotations.ToList(); private set => this.quotations = value.ToList(); }
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

        public Quotation GetRandom(Language language)
        {
            return this.Quotations.PickRandom(n => n.Language == language);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 152897;

                hash = hash * 55252961 + this.Name.GetHashCode();
                foreach (var quotation in this.Quotations.OrderBy(n => n.Content).ThenBy(n => n.Language))
                {
                    hash = hash * 55252961 + quotation.GetHashCode();
                }

                return hash;
            }
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

            return this.Quotations.IsContentTheSame(author.Quotations);
        }
    }
}