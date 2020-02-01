using System.IO;
using System.Threading.Tasks;

namespace FileAccess
{
    public class FileRepository : IFileRepository
    {
        private readonly IPathProvider pathProvider;

        public FileRepository(IPathProvider pathProvider)
        {
            this.pathProvider = pathProvider;
        }

        public byte[] GetFileAsBytes(string filename)
        {
            string path = pathProvider.GetFilePath(filename);
            return System.IO.File.ReadAllBytes(path);
        }

        public async Task<byte[]> GetFileAsBytesAsync(string filename)
        {
            string path = pathProvider.GetFilePath(filename);
            byte[] result;

            using (FileStream SourceStream = System.IO.File.Open(path, FileMode.Open))
            {
                result = new byte[SourceStream.Length];
                await SourceStream.ReadAsync(result, 0, (int)SourceStream.Length);
            }

            return result;
        }
    }
}
