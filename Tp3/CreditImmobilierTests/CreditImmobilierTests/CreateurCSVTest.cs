using Xunit;
using System.Collections.Generic;
using System.Globalization;
using CreditImmobilierTests;
using System.Text;

namespace CreditImmobilier.Tests
{
    public class CreateurCSVTests
    {
        [Fact]
        public void GenererCSV_CreeFichierAvecContenuCorrect()
        {
            var fakeFileSystem = new FileSystemFake();
            var createurCSV = new CreateurCSV(fakeFileSystem);

            double coutTotal = 1000.0;
            var mensualites = new List<Mensualite>
            {
                new Mensualite(1, 200.0, 800.0, 50.0, 250.0),
                new Mensualite(2, 200.0, 600.0, 45.0, 245.0)
            };
            string filePath = "test.csv";

            StringBuilder expectedContent = new StringBuilder();
            expectedContent.AppendLine($"Cout total du credit;{coutTotal.ToString("F2", CultureInfo.InvariantCulture)}");
            expectedContent.AppendLine("Numero;Capital Rembourse;Capital Restant Du;Amortissement;Interet;Mensualite;Cout Total");
            foreach (var mensualite in mensualites)
            {
                expectedContent.AppendLine($"{mensualite.Numero};{mensualite.CapitalRembourse.ToString("F2", CultureInfo.InvariantCulture)};{mensualite.CapitalRestantDu.ToString("F2", CultureInfo.InvariantCulture)};{mensualite.CapitalRembourse.ToString("F2", CultureInfo.InvariantCulture)};{mensualite.Interet.ToString("F2", CultureInfo.InvariantCulture)};{mensualite.MensualiteTotal.ToString("F2", CultureInfo.InvariantCulture)};{coutTotal.ToString("F2", CultureInfo.InvariantCulture)}");
            }

            createurCSV.GenererCSV(filePath, mensualites, coutTotal);

            string actualContent = fakeFileSystem.ReadAllText(filePath);
            Assert.Equal(expectedContent.ToString().Trim(), actualContent.Trim());
        }
    }
}
