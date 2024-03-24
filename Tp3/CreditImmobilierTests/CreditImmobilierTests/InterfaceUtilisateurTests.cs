using CreditImmobilier;
using Moq;
using Xunit;

namespace CreditImmobilierTests
{
    public class InterfaceUtilisateurTests
    {
        [Theory]
        [InlineData(new string[] { "100000", "240", "1.5" }, true)] 
        [InlineData(new string[] { "100000", "240" }, false)] 
        [InlineData(new string[] { "100000", "240", "1.5", "extra" }, false)] 
        public void VerifierArguments_NombreArgumentsCorrect(string[] args, bool expected)
        {
            var resultat = InterfaceUtilisateur.VerifierArguments(args);
            Assert.Equal(expected, resultat);
        }

        [Theory]
        [InlineData(new string[] { "100000", "240", "1.5" }, true)]
        [InlineData(new string[] { "100000.5", "240.54", "1.5" }, true)]
        [InlineData(new string[] { "100000.5", "240", "1" }, true)]
        [InlineData(new string[] { "100000", "240.56", "1" }, true)]
        [InlineData(new string[] { "100000", "240", "1" }, true)]
        [InlineData(new string[] { "100000", "abc", "1.5" }, false)]
        [InlineData(new string[] { "100000", "!@#", "1.5" }, false)]
        public void EstUnNombreValide_TousElementsSontNombres(string[] args, bool expected)
        {
            var resultat = InterfaceUtilisateur.SontdesNombreValide(args);
            Assert.Equal(expected, resultat);
        }
    }
}