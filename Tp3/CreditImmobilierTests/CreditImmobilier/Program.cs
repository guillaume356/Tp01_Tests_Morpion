using CreditImmobilierTests;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace CreditImmobilier
{
    class Program
    {
        static void Main(string[] args)
        {
            IConsole console = new ConsoleWrapper();
            
            IFileSystem fileSystem = new RealFileSystem(); 

            try
            {
                InputHandler inputHandler = new InputHandler(args);
                double montant = inputHandler.InputMontant();
                int duree = inputHandler.InputDuree();
                double taux = double.Parse(args[2], CultureInfo.InvariantCulture);

                Credit credit = new Credit(montant, duree, taux);
                List<Mensualite> mensualites = CalculateurCredit.GenererPlanAmortissement(credit);
                double coutTotal = CalculateurCredit.CalculerCoutTotal(credit);

                string filePath = "mensualites.csv";
                CreateurCSV createurCSV = new CreateurCSV(fileSystem); 
                createurCSV.GenererCSV(filePath, mensualites, coutTotal);

                console.WriteLine($"Fichier CSV généré avec succès : {filePath}");
            }
            catch (ArgumentException ex)
            {
                console.WriteLine($"Erreur: {ex.Message}");
            }
        }
    }
}
