using CreditImmobilier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditImmobilierTests
{
    public class CalculateurCreditTest
    {

        [Theory]
        [InlineData(100000, 240, 1.5, 482.55)]
        public void Credit_CalculerMensualite_RetourneValeurCorrecte(double montantEmprunte, int dureeMois, double tauxNominal, double result)
        {
            Credit credit = new Credit(montantEmprunte, dureeMois, tauxNominal);
            double mensualite = CalculateurCredit.CalculerMensualite(credit);
            Assert.Equal(result, mensualite, 2);
        }

        [Theory]
        [InlineData(100000, 200, 2.5, 482.55)]
        [InlineData(400000, 150, 1.6, 4852.55)]
        [InlineData(300000, 200, 4.5, 482.55)]
        [InlineData(500000, 100, 2.5, 4822.55)]
        [InlineData(1100000, 0121, 0.5, 481.55)]
        [InlineData(5500000, 258, 5.5, 4825.55)]

        public void Credit_CalculerMensualite_RetourneValeurIncorrecte(double montantEmprunte, int dureeMois, double tauxNominal, double result)
        {
            Credit credit = new Credit(montantEmprunte, dureeMois, tauxNominal);
            double mensualite = CalculateurCredit.CalculerMensualite(credit);
            Assert.NotEqual(result, mensualite, 2);
        }
    }
}
