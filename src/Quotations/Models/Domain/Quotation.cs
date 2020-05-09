using System;
using Common;

namespace Quotations.Models.Domain
{
    public class Quotation : Entity, IEquatable<Quotation>
    {
        public Guid AuthorId { get; }
        public Language Language { get; }        
        public string Content { get; protected set; }

        protected Quotation() { }

        public Quotation(Guid authorId, string content, Language language)
        {
            this.AuthorId = authorId; 
            this.Content = content;
            this.Language = language;
        }

        public override bool Equals(object obj)
        {
            bool typeMatch = base.EqualsType<Quotation>(obj);

            if(typeMatch == false)
            {
                return false;
            }

            Quotation quotation = obj as Quotation;

            return this.Language == quotation.Language && this.Content == quotation.Content;
        }

        public override int GetHashCode()
        {
            unchecked 
            {
                int hash = 1827809;

                hash = hash * 382883 + this.Language.GetHashCode();
                hash = hash * 382883 + this.Content.GetHashCode();

                return hash;
            }
        }

        public bool Equals(Quotation other)
        {
            return this.Equals(other as object);
        }
    }
}