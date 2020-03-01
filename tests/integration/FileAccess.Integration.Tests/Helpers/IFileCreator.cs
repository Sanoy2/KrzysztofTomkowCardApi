namespace FileAccess.Integration.Tests.Helpers
{
    public interface IFileCreator
    {
        void CreateFile(string name, string extension);
    }
}