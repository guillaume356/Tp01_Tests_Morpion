using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MorpionApp;

namespace MorpionTest
{
    public class MorpionTests : IClassFixture<MorpionTestFixture>
    {
        private readonly MorpionTestFixture _fixture;

        public MorpionTests(MorpionTestFixture fixture)
        {
            _fixture = fixture;
            _fixture.ResetGrille();
        }

        [Theory]
        [InlineData('X', 0)]
        [InlineData('O', 1)]
        [InlineData('X', 2)]
        public void VerifVictoire_Horizontale(char joueur, int ligne)
        {
            _fixture.SetLigneVictorieuse(joueur, ligne);
            bool victoire = _fixture.morpion.verifVictoire(joueur);
            Assert.True(victoire, $"Le joueur {joueur} devrait avoir gagné horizontalement à la ligne {ligne + 1}.");
        }

        [Theory]
        [InlineData('X', 0)]
        [InlineData('O', 1)] 
        [InlineData('X', 2)] 
        public void VerifVictoire_Verticale(char joueur, int colonne)
        {
            _fixture.SetColonneVictorieuse(joueur, colonne);
            bool victoire = _fixture.morpion.verifVictoire(joueur);
            Assert.True(victoire, $"Le joueur {joueur} devrait avoir gagné verticalement dans la colonne {colonne + 1}.");
        }

        [Theory]
        [InlineData('X')]
        [InlineData('O')]
        public void VerifVictoire_DiagonalePrincipale(char joueur)
        {
            _fixture.SetDiagonaleVictorieuse(joueur);
            bool victoire = _fixture.morpion.verifVictoire(joueur);
            Assert.True(victoire, $"Le joueur {joueur} devrait avoir gagné sur la diagonale principale.");
        }

        [Theory]
        [InlineData('X')]
        [InlineData('O')]
        public void VerifVictoire_DiagonaleInverse(char joueur)
        {
            _fixture.SetDiagonaleInverseVictorieuse(joueur);
            bool victoire = _fixture.morpion.verifVictoire(joueur);
            Assert.True(victoire, $"Le joueur {joueur} devrait avoir gagné sur la diagonale inverse.");
        }

        [Fact]
        public void VerifVictoire_GrillePleineSansVictoire_RetourneFaux()
        {
            char[,] grilleTest = new char[,] {
        { 'X', 'O', 'X' },
        { 'X', 'X', 'O' },
        { 'O', 'X', 'O' }
    };
            _fixture.morpion.grille = grilleTest;

            bool victoireX = _fixture.morpion.verifVictoire('X');
            bool victoireO = _fixture.morpion.verifVictoire('O');

            Assert.False(victoireX, "Ne devrait pas détecter une victoire pour X dans une grille pleine sans alignement victorieux.");
            Assert.False(victoireO, "Ne devrait pas détecter une victoire pour O dans une grille pleine sans alignement victorieux.");
        }

        [Fact]
        public void VerifVictoire_GrilleVide_RetourneFaux()
        {
            _fixture.ResetGrille();

            bool victoire = _fixture.morpion.verifVictoire('X');
            Assert.False(victoire, "Ne devrait pas détecter une victoire sur une grille vide.");
        }

        [Fact]
        public void VerifVictoire_MoinsDeTroisSymbolesAlignes_RetourneFaux()
        {
            _fixture.morpion.grille[0, 0] = 'X';
            _fixture.morpion.grille[1, 1] = 'X';

            bool victoire = _fixture.morpion.verifVictoire('X');
            Assert.False(victoire, "Ne devrait pas détecter une victoire avec moins de trois symboles alignés.");
        }



    }
}
