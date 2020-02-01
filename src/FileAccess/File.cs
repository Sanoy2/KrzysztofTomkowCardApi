namespace FileAccess
{
    public class File
    {
        public int Id { get; protected set; }
        public string Filename { get; protected set; }

        protected File()
        {

        }

        public File(string filename)
        {
            this.Filename = filename;
        }
    }
}
