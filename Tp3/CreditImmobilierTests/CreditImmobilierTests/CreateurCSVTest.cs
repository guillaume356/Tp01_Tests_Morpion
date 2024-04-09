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

            double coutTotalInitial = 500.0;
            var mensualites = new List<Mensualite>
            {
                new Mensualite(1, 200.0, 800.0, 50.0, 250.0),
                new Mensualite(2, 200.0, 600.0, 45.0, 245.0)
            };
            string filePath = "test.csv";

            StringBuilder expectedContent = new StringBuilder();
            expectedContent.AppendLine($"Cout total du credit;{coutTotalInitial.ToString("F2", CultureInfo.InvariantCulture)}");
            expectedContent.AppendLine("Numero;Capital Rembourse;Capital Restant Du;Amortissement;Interet;Mensualite;Cout Total");
            double capitalRembourseCumulatif = 0;
            foreach (var mensualite in mensualites)
            {
                capitalRembourseCumulatif += mensualite.CapitalRembourse;
                expectedContent.AppendLine($"{mensualite.Numero};{capitalRembourseCumulatif.ToString("F2", CultureInfo.InvariantCulture)};{mensualite.CapitalRestantDu.ToString("F2", CultureInfo.InvariantCulture)};{mensualite.Interet.ToString("F2", CultureInfo.InvariantCulture)};{mensualite.MensualiteTotal.ToString("F2", CultureInfo.InvariantCulture)};{coutTotalInitial.ToString("F2", CultureInfo.InvariantCulture)}");
            }

            createurCSV.GenererCSV(filePath, mensualites, coutTotalInitial);

            string actualContent = fakeFileSystem.ReadAllText(filePath);
            Assert.Equal(expectedContent.ToString().Trim(), actualContent.Trim());
        }
    }
}
