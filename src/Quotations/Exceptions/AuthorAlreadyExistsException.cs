using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quotations.Exceptions
{
    public class AuthorAlreadyExistsException : ValidationException
    {
        public AuthorAlreadyExistsException()
        {
        }

        public AuthorAlreadyExistsException(string message) : base(message)
        {
        }

        public AuthorAlreadyExistsException(string message, string variableName) : base(message, variableName)
        {
        }
    }
}
