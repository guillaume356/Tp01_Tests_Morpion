using CreditImmobilier;
using Moq;
using Xunit;

namespace CreditImmobilierTests
{
    public class InterfaceUtilisateurTests
    {
        [Theory]
        [InlineData(new string[] { "100000", "240", "1.5" }, true)] // Cas valide
        [InlineData(new string[] { "100000", "240" }, false)] // Moins de 3 arguments
        [InlineData(new string[] { "100000", "240", "1.5", "extra" }, false)] // Plus de 3 arguments
        public void VerifierArguments_NombreArgumentsCorrect(string[] args, bool expected)
        {
            var consoleMock = new Mock<IConsole>();
            var interfaceUtilisateur = new InterfaceUtilisateur(consoleMock.Object);
            var resultat = interfaceUtilisateur.VerifierArguments(args);
            Assert.Equal(expected, resultat);
        }
    }
}