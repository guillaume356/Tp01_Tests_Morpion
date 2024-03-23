using System;

namespace CreditImmobilier
{
    class Program
    {
        static void Main(string[] args)
        {
            IConsole consoleWrapper = new ConsoleWrapper();
            InterfaceUtilisateur interfaceUtilisateur = new InterfaceUtilisateur(consoleWrapper);
            
                if (interfaceUtilisateur.VerifierArguments(args))
                {
                    consoleWrapper.WriteLine("Usage: RealEstateCredit <amount> <duration in months> <nominal rate>");
                    return;
                }

        }
    }

}
