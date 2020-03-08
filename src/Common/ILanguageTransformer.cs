namespace Common
{
    public interface ILanguageTransformer
    {
        Language Transform(string languageCode);
    }
}