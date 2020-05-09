using System;
using System.Collections.Generic;
using System.Text;

namespace Quotations.Models.DbModels
{
    public class QuotationsDbModel
    {
        public Guid Id { get; set; }
        public Guid AuthorId { get; set; }
        public string Content { get; set; }
        public string Language { get; set; }
    }
}
