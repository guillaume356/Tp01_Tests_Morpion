using Xunit;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace CreditImmobilier.Tests
{
    public class CreateurCSVTests
    {
        [Fact]
        public void GenererCSV_CreeContenuCSVAttendu()
        {
            var mensualites = new List<Mensualite>
    {
        new Mensualite(1, 500.0, 99500.0),
        new Mensualite(2, 500.0, 99000.0),
    };
            string path = Path.GetTempFileName();
            double coutTotal = 1000.0;

            var sb = new StringBuilder();
            sb.AppendLine($"Coût total du crédit,{coutTotal.ToString("F2", CultureInfo.InvariantCulture)}");
            sb.AppendLine("Numéro de la mensualité,Capital remboursé,Capital restant dû");
            foreach (var mensualite in mensualites)
            {
                sb.AppendLine($"{mensualite.Numero},{mensualite.CapitalRembourse.ToString("F2", CultureInfo.InvariantCulture)},{mensualite.CapitalRestantDu.ToString("F2", CultureInfo.InvariantCulture)}");
            }
            string contenuCSVAttendu = sb.ToString();

            CreateurCSV.GenererCSV(path, mensualites, coutTotal);

            string contenuCSV = File.ReadAllText(path);
            Assert.Equal(contenuCSVAttendu, contenuCSV);

            File.Delete(path);
        }

    }
}
