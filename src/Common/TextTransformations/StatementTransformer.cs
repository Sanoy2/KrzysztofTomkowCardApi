using System;
using System.Linq;

namespace Common.TextTransformations
{
    public class StatementTransformer : IStatementTransformer
    {
        private readonly char[] endLineChars = { '.', '?', '!' };

        public string Transform(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            if (string.IsNullOrWhiteSpace(text))
            {
                return string.Empty;
            }

            return this.TransformSingleStatement(text);
        }

        private bool DoesEndWithDotOrOtherEndStatementCharacter(string text)
        {
            return endLineChars.Contains(text.Last());
        }

        private string StartWithUppercase(string text)
        {
            return text.Substring(0, 1).ToUpper() + text.Remove(0, 1).ToLower();
        }

        private string EndStatementWithDot(string text)
        {
            return $"{text}.";
        }

        private string TransformSingleStatement(string text)
        {
            if (DoesEndWithDotOrOtherEndStatementCharacter(text) == false)
            {
                text = EndStatementWithDot(text);
            }

            return StartWithUppercase(text);
        }
    }
}