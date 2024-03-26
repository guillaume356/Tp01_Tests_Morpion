using CreditImmobilier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditImmobilierTests
{
    public class CreditTests
    {

        [Theory]
        [InlineData(100000, 240, 1.5)]
        [InlineData(200000, 180, 2.5)]
        [InlineData(300000, 360, 3.0)]
        public void Credit_Constructor_InitializesPropertiesCorrectly(double montantEmprunte, int dureeMois, double tauxNominal)
        {
            
            var credit = new Credit(montantEmprunte, dureeMois, tauxNominal);

            
            Assert.Equal(montantEmprunte, credit.MontantEmprunte);
            Assert.Equal(dureeMois, credit.DureeMois);
            Assert.Equal(tauxNominal, credit.TauxNominal);
        }

    }

}
