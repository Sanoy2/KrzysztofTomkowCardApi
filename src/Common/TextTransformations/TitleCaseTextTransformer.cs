using System;
using System.Text;

namespace Common.TextTransformations
{
    public class TitleCaseTextTransformer : ITitleCaseTextTransformer
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
            if (word.Contains("-"))
            {
                var builder = new StringBuilder();
                string[] subwords = word.Split('-');
                foreach (string subword in subwords)
                {
                    string transformedSubWord = this.TransformWord(subword);
                    builder.Append($"{transformedSubWord}-");
                }

                string mergedSubwords = builder.ToString();
                return mergedSubwords.Substring(0, mergedSubwords.Length - 1);
            }

            return word.Substring(0, 1).ToUpper() + word.Remove(0, 1).ToLower();
        }
    }
}