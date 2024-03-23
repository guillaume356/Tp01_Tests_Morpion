using CreditImmobilier;
using Moq;
using Xunit;

namespace CreditImmobilierTests
{
    public class InterfaceUtilisateurTests
    {
        [Fact]
        public void AfficheMessageBienvenue_AfficheMessageCorrect()
        {
            // Arranger
            var consoleMock = new Mock<IConsole>();
            var interfaceUtilisateur = new InterfaceUtilisateur(consoleMock.Object);

            // Agir
            interfaceUtilisateur.AfficheMessageBienvenue();

            // Assert
            consoleMock.Verify(x => x.WriteLine("Bonjour, Bienvenue dans votre simulateur de crédit immobilier :) Veuillez entrer le montant que vous souhaitez emprunter"), Times.Once());
        }
    }
}