using Common;
using Common.TextTransformations;
using Quotations.Models;
using Quotations.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quotations.DomainServices
{
    public class QuotationDomainService : IQuotationDomainService
    {
        public ILanguageTransformer languageTransformer { get; }
        public ITextTransformer textTransformer { get; }

        public QuotationDomainService(ILanguageTransformer languageTransformer, IStatementTransformer textTransformer)
        {
            this.languageTransformer = languageTransformer ?? throw new ArgumentNullException(nameof(languageTransformer));
            this.textTransformer = textTransformer ?? throw new ArgumentNullException(nameof(textTransformer));
        }

        public Quotation Create(Author author, string text, string languageCode)
        {
            Language language = this.languageTransformer.Transform(languageCode);

            Quotation quotation = author.AddQuotation(text, language);

            return quotation;
        }
    }
}
