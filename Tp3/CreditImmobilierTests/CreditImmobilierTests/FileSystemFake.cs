using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditImmobilierTests
{
    public class FileSystemFake : IFileSystem
    {
        private Dictionary<string, string> _files = new();

        public void WriteAllText(string path, string contents)
        {
            _files[path] = contents;
        }

        public string ReadAllText(string path)
        {
            if (_files.ContainsKey(path))
            {
                return _files[path];
            }

            throw new FileNotFoundException($"Le fichier {path} n'existe pas.");
        }
    }

}
