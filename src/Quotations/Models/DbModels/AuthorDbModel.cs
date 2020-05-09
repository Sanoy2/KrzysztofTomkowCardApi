using System;
using System.Collections.Generic;
using System.Text;

namespace Quotations.Models.DbModels
{
    public class AuthorDbModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<QuotationsDbModel> Quotations { get; set; }
    }
}
