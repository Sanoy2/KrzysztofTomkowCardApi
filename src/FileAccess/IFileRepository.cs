using System.Threading.Tasks;

namespace FileAccess
{
    public interface IFileRepository
    {
        byte[] GetFileAsBytes(string filename);
        Task<byte[]> GetFileAsBytesAsync(string filename);
    }
}
