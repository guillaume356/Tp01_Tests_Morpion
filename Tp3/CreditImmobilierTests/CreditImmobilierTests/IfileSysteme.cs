using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditImmobilierTests
{
    public interface IFileSystem
    {
        void WriteAllText(string path, string contents);
        string ReadAllText(string path);
    }

}
