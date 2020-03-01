using System.IO;
using System.Threading.Tasks;

namespace FileAccess
{
    public class FileRepository : IFileRepository
    {
        public byte[] GetFileAsBytes(string physicalPath)
        {
            return GetFileAsBytesAsync(physicalPath).Result;
        }

        public async Task<byte[]> GetFileAsBytesAsync(string physicalPath)
        {
            byte[] result;

            using (FileStream SourceStream = System.IO.File.Open(physicalPath, FileMode.Open))
            {
                result = new byte[SourceStream.Length];
                await SourceStream.ReadAsync(result, 0, (int)SourceStream.Length);
            }

            return result;
        }

        public MemoryStream GetFileAsMemoryStream(string physicalPath)
        {
            return this.GetFileAsMemoryStreamAsync(physicalPath).Result;
        }

        public async Task<MemoryStream> GetFileAsMemoryStreamAsync(string physicalPath)
        {
            var memory = new MemoryStream();
            using (var stream = new FileStream(physicalPath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }

            memory.Position = 0;

            return memory;
        }
    }
}
