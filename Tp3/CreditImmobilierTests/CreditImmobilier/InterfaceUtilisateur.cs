using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditImmobilier
{
    public class InterfaceUtilisateur
    {
        private readonly IConsole console;

        public InterfaceUtilisateur(IConsole console)
        {
            this.console = console;
        }

        public bool VerifierArguments(string[] args)
        {
            return args.Length != 3;
        }
    }
}
