using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class ValidationException : ArgumentException
    {
        public ValidationException() : base()
        {

        }

        public ValidationException(string message) : base(message)
        {

        }

        public ValidationException(string message, string variableName) : base(message, variableName)
        {

        }
    }
}
