using System;
using Common;

namespace Quotations.Models
{
    public class Quotation : Entity
    {
        public Language Language { get; }
        public Author Author { get; }
        public string Content { get; }

        public Quotation(Author author, string content, Language language, long id) : base(id)
        {
            this.Author = author ??
                throw new ArgumentNullException(nameof(author));
            this.Content = content;
            this.Language = language;
        }
    }
}