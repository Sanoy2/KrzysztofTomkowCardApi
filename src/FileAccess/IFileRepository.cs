using System.Threading.Tasks;

namespace FileAccess
{
    public interface IFileRepository
    {
        byte[] GetFileAsBytes(string physicalPath);
        Task<byte[]> GetFileAsBytesAsync(string physicalPath);
    }
}
