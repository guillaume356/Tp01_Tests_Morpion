using CreditImmobilier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditImmobilierTests
{
    public class MensualiteTest
    {

        [Theory]
        [InlineData(1, 1000.00, 99000.00)]
        [InlineData(2, 1000.00, 98000.00)]
        [InlineData(3, 1000.00, 97000.00)]
        public void Mensualite_Constructor_InitializesPropertiesCorrectly(int numero, double capitalRembourse, double capitalRestantDu)
        {
            
            var mensualite = new Mensualite(numero, capitalRembourse, capitalRestantDu,0,0);

            
            Assert.Equal(numero, mensualite.Numero);
            Assert.Equal(capitalRembourse, mensualite.CapitalRembourse);
            Assert.Equal(capitalRestantDu, mensualite.CapitalRestantDu);
        }


    }
}
