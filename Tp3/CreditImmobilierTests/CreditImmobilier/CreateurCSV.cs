using System.Globalization;
using System.Text;

namespace CreditImmobilier
{
    public static class CreateurCSV
    {
        public static void GenererCSV(string filePath, List<Mensualite> mensualites, double coutTotal)
        {
            StringBuilder csvContent = new StringBuilder();

            csvContent.AppendLine($"Cout total du credit;{coutTotal.ToString("F2", CultureInfo.InvariantCulture)}");

            csvContent.AppendLine("Numero;Capital Rembourse;Capital Restant Du;Amortissement;Interet;Mensualite;Cout Total");


            foreach (var mensualite in mensualites)
            {
                StringBuilder line = new StringBuilder();
                line.Append(mensualite.Numero.ToString(CultureInfo.InvariantCulture) + ";");
                line.Append(mensualite.CapitalRembourse.ToString("F2", CultureInfo.InvariantCulture) + ";");
                line.Append(mensualite.CapitalRestantDu.ToString("F2", CultureInfo.InvariantCulture) + ";");
                line.Append(mensualite.CapitalRembourse.ToString("F2", CultureInfo.InvariantCulture) + ";");
                line.Append(mensualite.Interet.ToString("F2", CultureInfo.InvariantCulture) + ";");
                line.Append(mensualite.MensualiteTotal.ToString("F2", CultureInfo.InvariantCulture) + ";");
                line.Append(coutTotal.ToString("F2", CultureInfo.InvariantCulture));
                csvContent.AppendLine(line.ToString());
            }

            File.WriteAllText(filePath, csvContent.ToString());
        }
    }
}
