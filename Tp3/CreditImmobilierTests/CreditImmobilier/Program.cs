using System;

namespace CreditImmobilier
{
    class Program
    {
        static void Main(string[] args)
        {
            IConsole consoleWrapper = new ConsoleWrapper();
            InterfaceUtilisateur interfaceUtilisateur = new InterfaceUtilisateur(consoleWrapper);

            interfaceUtilisateur.AfficheMessageBienvenue();
        }
    }
}
