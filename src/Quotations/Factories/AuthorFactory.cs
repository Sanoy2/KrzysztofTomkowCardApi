using System;
using System.Text.RegularExpressions;
using Common;
using Common.TextTransformations;
using Quotations.Models;
using Quotations.Persistence;

namespace Quotations.Factories
{
    public class AuthorFactory : IAuthorFactory
    {
        private readonly ITitleCaseTextTransformer titleCaseTransformer;

        public AuthorFactory(ITitleCaseTextTransformer titleCaseTransformer)
        {
            this.titleCaseTransformer = titleCaseTransformer ?? throw new ArgumentNullException(nameof(titleCaseTransformer));
        }

        public Author Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ValidationException("Author's name cannot be empty", nameof(name));
            }

            bool containsDigitsOnly = !Regex.IsMatch(name, @"\p{L}+");

            if (containsDigitsOnly)
            {
                throw new ValidationException("Author's name should contain letters only", nameof(name));
            }

            string titleCaseName = this.titleCaseTransformer.Transform(name);

            return new Author(titleCaseName);
        }
    }
}