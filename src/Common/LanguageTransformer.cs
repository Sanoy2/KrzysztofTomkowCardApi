using System;

namespace Common
{
    public class LanguageTransformer : ILanguageTransformer
    {
        public Language Transform(string languageCode)
        {
            string formattedText = languageCode.ToLower().Trim();

            switch (formattedText)
            {
                case "en":
                case "eng":
                case "en-en":
                case "en-us":
                case "en-uk":
                case "english":
                    return Language.eng;

                case "pl":
                case "pol":
                case "pl-pl":
                case "polish":
                case "polski":
                    return Language.pl;

                default:
                    throw new ArgumentException("Given language is not supported", nameof(languageCode));
            }
        }
    }
}