using System;
using System.Globalization;

namespace CreditImmobilier
{
    class Program
    {
        static void Main(string[] args)
        {
            IConsole consoleWrapper = new ConsoleWrapper();
            InterfaceUtilisateur interfaceUtilisateur = new InterfaceUtilisateur(consoleWrapper);

            if (!InterfaceUtilisateur.VerifierArguments(args))
            {
                consoleWrapper.WriteLine("Usage: dotnet run <montantEmprunte> <dureeMois> <tauxNominal>");
                return;
            }

            if (!InterfaceUtilisateur.SontdesNombreValide(args))
            {
                consoleWrapper.WriteLine("Veuillez vérifier que les trois arguments soient des nombres valides.");
                return;
            }

            double montantEmprunte = double.Parse(args[0], CultureInfo.InvariantCulture);
            int dureeMois = int.Parse(args[1], CultureInfo.InvariantCulture);
            double tauxNominal = double.Parse(args[2], CultureInfo.InvariantCulture);

            Credit credit = new Credit(montantEmprunte, dureeMois, tauxNominal);
            double mensualite = CalculateurCredit.CalculerMensualite(credit);

            consoleWrapper.WriteLine($"La mensualité pour votre prêt est de: {mensualite} euros.");
        }
    }
    

}
