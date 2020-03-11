namespace FileAccess.Integration.Tests.Helpers
{
    public interface IFileCreator
    {
        void CreateFile();
        void CreateFile(string name);
        void CreateFile(string name, string extension);
    }
}