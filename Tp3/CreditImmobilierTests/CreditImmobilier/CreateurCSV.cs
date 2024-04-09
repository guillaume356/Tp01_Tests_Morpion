using CreditImmobilierTests;
using System.Globalization;
using System.Text;
namespace CreditImmobilier
{
    public class CreateurCSV
    {
        private readonly IFileSystem _fileSystem;

        public CreateurCSV(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

       public void GenererCSV(string filePath, List<Mensualite> mensualites, double coutTotalInitial)
        {
            StringBuilder csvContent = new StringBuilder();
            double coutTotal = coutTotalInitial;
            double capitalRembourseCumulatif = 0;
    
            csvContent.AppendLine($"Cout total du credit;{coutTotalInitial.ToString("F2", CultureInfo.InvariantCulture)}");
            csvContent.AppendLine("Numero;Capital Rembourse;Capital Restant Du;Amortissement;Interet;Mensualite;Cout Total");

            foreach (var mensualite in mensualites)
            {
                coutTotal -= mensualite.MensualiteTotal;

                StringBuilder line = new StringBuilder();

                capitalRembourseCumulatif += mensualite.CapitalRembourse;

                line.Append($"{mensualite.Numero};");
                line.Append(capitalRembourseCumulatif.ToString("F2", CultureInfo.InvariantCulture) + ";");
                line.Append(mensualite.CapitalRestantDu.ToString("F2", CultureInfo.InvariantCulture) + ";");
                line.Append(mensualite.Interet.ToString("F2", CultureInfo.InvariantCulture) + ";");
                line.Append(mensualite.MensualiteTotal.ToString("F2", CultureInfo.InvariantCulture) + ";");
                line.Append($"{coutTotal.ToString("F2", CultureInfo.InvariantCulture)}");
        
                csvContent.AppendLine(line.ToString());
            }

            _fileSystem.WriteAllText(filePath, csvContent.ToString());
        }

    }
}
