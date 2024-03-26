using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditImmobilierTests
{
    public class InputHandlerTest
    {

        [Theory]
        [InlineData("100000", true)]
        [InlineData("49999", false)]
        public void InputMontant_Validation(string montant, bool isValid)
        {
            string[] args = { montant, "240", "1.5" };
            InputHandler inputHandler = new InputHandler(args);

            if (isValid)
            {
                double result = inputHandler.InputMontant();
                Assert.True(result > 0);
            }
            else
            {
                Assert.Throws<ArgumentException>(() => inputHandler.InputMontant());
            }
        }

        [Theory]
        [InlineData("240", true)]
        [InlineData("107", false)]
        [InlineData("301", false)]
        public void InputDuree_Validation(string duree, bool isValid)
        {
            string[] args = { "100000", duree, "1.5" };
            InputHandler inputHandler = new InputHandler(args);

            if (isValid)
            {
                int result = inputHandler.InputDuree();
                Assert.InRange(result, 108, 300);
            }
            else
            {
                Assert.Throws<ArgumentException>(() => inputHandler.InputDuree());
            }
        }



    }
}
