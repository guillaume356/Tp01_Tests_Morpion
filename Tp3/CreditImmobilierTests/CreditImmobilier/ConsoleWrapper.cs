using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditImmobilier
{
    public class ConsoleWrapper : IConsole
    {
        public void WriteLine(string message) => Console.WriteLine(message);
        public string ReadLine() => Console.ReadLine();
    }
}
