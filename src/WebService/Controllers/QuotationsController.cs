using Microsoft.AspNetCore.Mvc;
using Quotations.ApplicationServices;
using Quotations.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.Controllers
{
    public class QutationsController : AbstractController
    {
        private readonly IQuotationsService quotationsService;

        public QutationsController(IQuotationsService quotationsService)
        {
            this.quotationsService = quotationsService;
        }

        [HttpGet]
        [Route("/{languageCode}")]
        public QuotationDto RandomQuotation([FromRoute] string languageCode = "eng")
        {
            QuotationDto quotation = this.quotationsService.GetRandom(languageCode);
            return quotation;
        }
    }
}
