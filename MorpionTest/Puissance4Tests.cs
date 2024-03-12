using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MorpionTest
{
    public class Puissance4Tests : IClassFixture<Puissance4TestFixture>
    {
        private readonly Puissance4TestFixture _fixture;

        public Puissance4Tests(Puissance4TestFixture fixture)
        {
            _fixture = fixture;
            _fixture.ResetGrille();
        }

        [Theory]
        [InlineData('X', 0)] 
        [InlineData('O', 1)] 
        public void VerifVictoire_Verticale(char joueur, int colonne)
        {
            _fixture.ResetGrille();
            _fixture.SetColonneVictorieuse(joueur, colonne);
            bool victoire = _fixture.puissanceQuatre.verifVictoire(joueur);
            Assert.True(victoire, $"Le joueur {joueur} devrait avoir gagné verticalement dans la colonne {colonne + 1}.");
        }

        [Theory]
        [InlineData('X', 0)] 
        [InlineData('O', 1)] 
        public void VerifVictoire_Horizontale(char joueur, int ligne)
        {
            _fixture.ResetGrille();
            _fixture.SetLigneVictorieuse(joueur, ligne);
            bool victoire = _fixture.puissanceQuatre.verifVictoire(joueur);
            Assert.True(victoire, $"Le joueur {joueur} devrait avoir gagné horizontalement dans la ligne {ligne + 1}.");
        }

        [Theory]
        [InlineData('X')]
        [InlineData('O')]
        public void VerifVictoire_DiagonalePrincipale(char joueur)
        {
            _fixture.ResetGrille();
            _fixture.SetDiagonaleVictorieuse(joueur);
            bool victoire = _fixture.puissanceQuatre.verifVictoire(joueur);
            Assert.True(victoire, $"Le joueur {joueur} devrait avoir gagné sur la diagonale principale.");
        }

        [Theory]
        [InlineData('X')]
        [InlineData('O')]
        public void VerifVictoire_DiagonaleInverse(char joueur)
        {
            _fixture.ResetGrille();
            _fixture.SetDiagonaleInverseVictorieuse(joueur);
            bool victoire = _fixture.puissanceQuatre.verifVictoire(joueur);
            Assert.True(victoire, $"Le joueur {joueur} devrait avoir gagné sur la diagonale inverse.");
        }


    }
}
