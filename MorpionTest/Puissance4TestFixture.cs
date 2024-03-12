using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MorpionApp;
using Xunit;

namespace MorpionTest
{
    public class Puissance4TestFixture
    {
        public PuissanceQuatre puissanceQuatre;

        public Puissance4TestFixture()
        {
            ConsoleGameView gameView = new ConsoleGameView();
            puissanceQuatre = new PuissanceQuatre(gameView);
        }

        public void ResetGrille()
        {
            puissanceQuatre.grille = new char[4, 7];
        }

        public void SetColonneVictorieuse(char joueur, int colonne)
        {
            for (int ligne = 0; ligne < 4; ligne++)
            {
                puissanceQuatre.grille[ligne, colonne] = joueur;
            }
        }

        public void SetLigneVictorieuse(char joueur, int ligne)
        {
            for (int colonne = 0; colonne < 4; colonne++)
            {
                puissanceQuatre.grille[ligne, colonne] = joueur;
            }
        }

        public void SetDiagonaleVictorieuse(char joueur)
        {
            for (int i = 0; i < 4; i++)
            {
                puissanceQuatre.grille[i, i] = joueur;
            }
        }

        public void SetDiagonaleInverseVictorieuse(char joueur)
        {
            for (int i = 0; i < 4; i++)
            {
                puissanceQuatre.grille[3 - i, i] = joueur;
            }
        }

        public void RemplirGrilleSansGagnant()
        {
            char[] joueurs = { 'X', 'O' };
            int joueurIndex = 0;

            for (int ligne = 0; ligne < 4; ligne++)
            {
                for (int colonne = 0; colonne < 7; colonne++)
                {
                    puissanceQuatre.grille[ligne, colonne] = joueurs[joueurIndex];
                    joueurIndex = 1 - joueurIndex;
                }
            }
        }
    }
}
