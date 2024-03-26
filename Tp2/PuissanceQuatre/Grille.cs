using MorpionApp.Interfaces;
using System;

namespace MorpionApp
{
    public class Grille : IGrille
    {
        private char[,] grille;

        public char[,] GrilleMatrice
        {
            get { return grille; }
        }

        public int Lignes
        {
            get { return grille.GetLength(0); }
        }

        public int Colonnes
        {
            get { return grille.GetLength(1); }
        }

        public Grille(int lignes, int colonnes)
        {
            grille = new char[lignes, colonnes];
            InitialiserGrille();
        }

        public void InitialiserGrille()
        {
            for (int i = 0; i < grille.GetLength(0); i++)
            {
                for (int j = 0; j < grille.GetLength(1); j++)
                {
                    grille[i, j] = ' ';
                }
            }
        }

        public char GetValeurCase(int ligne, int colonne)
        {
            return grille[ligne, colonne];
        }

        public void SetValeurCase(int ligne, int colonne, char valeur)
        {
            grille[ligne, colonne] = valeur;
        }
    }
}
