using System.Globalization;
using System.Text;

namespace CreditImmobilier
{
    public static class CreateurCSV
    {
        public static void GenererCSV(string filePath, List<Mensualite> mensualites, double coutTotal)
        {
            StringBuilder csvContent = new StringBuilder();

            csvContent.AppendLine($"Coût total du crédit,{coutTotal.ToString("F2", CultureInfo.InvariantCulture)}");

            csvContent.AppendLine("Numéro de la mensualité,Capital remboursé,Capital restant dû");


            foreach (var mensualite in mensualites)
            {
                string line = string.Format("{0},{1},{2}",
                    mensualite.Numero,
                    mensualite.CapitalRembourse.ToString("F2", CultureInfo.InvariantCulture),
                    mensualite.CapitalRestantDu.ToString("F2", CultureInfo.InvariantCulture));
                csvContent.AppendLine(line);
            }

            File.WriteAllText(filePath, csvContent.ToString());
        }
    }
}
