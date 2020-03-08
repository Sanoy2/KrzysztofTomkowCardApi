using System;
using Common;

namespace Quotations.Models
{
    public class Quotation
    {
        public int Id { get; }
        public Language Language { get; }
        public Author Author { get; }
        public int AuthorId { get; }
        public string Content { get; }

        protected Quotation() { }

        public Quotation(Author author, string content, Language language)
        {
            this.Author = author ??
                throw new ArgumentNullException(nameof(author));
            this.AuthorId = author.Id;
            this.Content = content;
            this.Language = language;
        }
    }
}