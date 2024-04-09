using CreditImmobilierTests;
using System.IO;

namespace CreditImmobilier
{
    public class RealFileSystem : IFileSystem
    {
        public void WriteAllText(string path, string content)
        {
            File.WriteAllText(path, content);
        }

        public string ReadAllText(string path)
        {
            return File.ReadAllText(path);
        }
    }
}
