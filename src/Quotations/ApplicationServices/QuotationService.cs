using Common;
using Common.Sequence.Extensions;
using Quotations.Models;
using Quotations.Models.Dto;
using Quotations.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quotations.ApplicationServices
{
    public class QuotationService : IQuotationsService
    {
        private readonly IAuthorsRepository authorsRepository;
        private readonly ILanguageTransformer languageTransformer;

        public QuotationService(
            IAuthorsRepository authorsRepository,
            ILanguageTransformer languageTransformer)
        {
            this.authorsRepository = authorsRepository ?? throw new ArgumentNullException(nameof(authorsRepository));
            this.languageTransformer = languageTransformer ?? throw new ArgumentNullException(nameof(languageTransformer));
        }

        public QuotationDto GetRandom(string languageCode)
        {
            QuotationDto quotationDto = new QuotationDto();

            Language language = this.languageTransformer.Transform(languageCode);

            Author randomAuthor = this.authorsRepository.Get().PickRandom(n => n.Quotations.Any(m => m.Language == language));

            Quotation randomQuotation = randomAuthor.Quotations.PickRandom(n => n.Language == language);

            quotationDto.AuthorName = randomAuthor.Name;
            quotationDto.Content = randomQuotation.Content;

            return quotationDto;
        }
    }
}
