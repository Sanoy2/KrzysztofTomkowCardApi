using System;
using System.Collections.Generic;
using System.Text;

namespace Quotations.Exceptions
{
    public class AuthorNotFoundException : Exception
    {
        public AuthorNotFoundException() : base()
        {
        }

        public AuthorNotFoundException(string message) : base(message)
        {
        }
    }
}
