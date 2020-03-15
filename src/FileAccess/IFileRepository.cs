using System.IO;
using System.Threading.Tasks;

namespace FileAccess
{
    public interface IFileRepository
    {
        byte[] GetFileAsBytes(string physicalPath);
        Task<byte[]> GetFileAsBytesAsync(string physicalPath);
        MemoryStream GetFileAsMemoryStream(string physicalPath);
        Task<MemoryStream> GetFileAsMemoryStreamAsync(string physicalPath);
    }
}
