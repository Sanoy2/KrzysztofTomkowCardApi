using System;
using Common;

namespace Quotations.Models
{
    public class Quotation : Entity
    {
        public Language Language { get; }
        public Author Author { get; }
        public string Content { get; }

        protected Quotation() { }

        public Quotation(Author author, string content, Language language)
        {
            this.Author = author ??
                throw new ArgumentNullException(nameof(author));
            this.Content = content;
            this.Language = language;
        }
    }
}