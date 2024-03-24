using System;

namespace CreditImmobilier
{
    class Program
    {
        static void Main(string[] args)
        {
            IConsole consoleWrapper = new ConsoleWrapper();
            InterfaceUtilisateur interfaceUtilisateur = new InterfaceUtilisateur(consoleWrapper);
            
                if (!InterfaceUtilisateur.VerifierArguments(args) || !InterfaceUtilisateur.SontdesNombreValide(args))
                {
                    consoleWrapper.WriteLine("Veuillez prendre 3 arguments et vérifiez que ces derniers soient des nombres");
                    return;
                } 
                else
                {

                }

        }
    }

}
