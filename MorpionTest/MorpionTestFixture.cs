using MorpionApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MorpionTest
{
    public class MorpionTestFixture
    {
        public Morpion morpion { get; private set; }

        public MorpionTestFixture()
        {
            morpion = new Morpion();
        }

        public void ResetGrille()
        {
            morpion.grille = new char[3, 3];
        }

        public void SetLigneVictorieuse(char joueur, int ligne)
        {
            for (int col = 0; col < 3; col++)
            {
                morpion.grille[ligne, col] = joueur;
            }
        }

        public void SetColonneVictorieuse(char joueur, int colonne)
        {
            for (int ligne = 0; ligne < 3; ligne++)
            {
                morpion.grille[ligne, colonne] = joueur;
            }
        }

        public void SetDiagonaleVictorieuse(char joueur)
        {
            for (int i = 0; i < 3; i++)
            {
                morpion.grille[i, i] = joueur;
            }
        }

        public void SetDiagonaleInverseVictorieuse(char joueur)
        {
            for (int i = 0; i < 3; i++)
            {
                morpion.grille[i, 2 - i] = joueur;
            }
        }
    }
}

