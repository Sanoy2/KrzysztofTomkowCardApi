using System;

namespace Common.TextTransformations
{
    public class TitleCaseTextTransformer : ITextTransformer
    {
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

            var splited = text.Split();
            string result = "";
            foreach (var word in splited)
            {
                if (string.IsNullOrWhiteSpace(word) == false)
                {
                    result = result + " " + TransformWord(word);
                }
            }

            return result.Trim();
        }

        private string TransformWord(string word)
        {
            return word.Substring(0, 1).ToUpper() + word.Remove(0, 1).ToLower();
        }
    }
}